using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.Map;
using DevExpress.Utils;
using DevExpress.XtraMap;
using GMap.NET;
using GMap.NET.MapProviders;
using Mazor.EventsLog.Common;
using Mazor.EventsLog.GIS.Bing;

namespace Mazor.EventsLog
{
    public partial class frmMap : Form
    {
        #region Events

        public event EventHandler Save; 
        public event AuditMessage Audit;

        #endregion

        #region Data Members

        private List<CriminalEvent> criminalEvents;

        private LocationServiceInformation locationServiceInformation;

        private MapInitialInformation mapInitialInformation;

        #endregion

        #region Constructor

        public frmMap(MapInitialInformation inMapInitialInformation, LocationServiceInformation inLocationServiceInformation, List<CriminalEvent> inCriminalEvents)
        {
            InitializeComponent();

            mapInitialInformation = inMapInitialInformation;
            locationServiceInformation = inLocationServiceInformation;
            criminalEvents = inCriminalEvents;
        }

        #endregion

        private void frmMap_Load(object sender, EventArgs e)
        {
            string result;

            try
            {
                Location = Cursor.Position;

                tabMaps.TabPages.Remove(tabGMap);

                if (!SetBingMap(out result))
                {
                    OnAudit($"שגיאת טעינת מפת בינג: {result}", AuditSeverity.Error);

                    return;
                }

                if (!CriminalEventsToBingMap(out result))
                {
                    OnAudit($"שגיאת טעינת אירועים למפת בינג: {result}", AuditSeverity.Warning);
                }
            }
            catch (Exception ex)
            {
                OnAudit($"שגיאת טעינת מפה: {ex.Message}", AuditSeverity.Error);
            }
        }

        #region Bing

        private bool SetBingMap(out string result)
        {
            result = string.Empty;

            try
            {
                BingMapDataProvider bingMapDataProvider = new BingMapDataProvider();
                bingMapDataProvider.BingKey = locationServiceInformation.BingKey;

                ImageTilesLayer imageTilesLayer = new ImageTilesLayer();
                imageTilesLayer.DataProvider = bingMapDataProvider;
                bingMap.Layers.Add(imageTilesLayer);

                bingMap.ZoomLevel = mapInitialInformation.ZoomLevel;
                bingMap.CenterPoint = new GeoPoint(mapInitialInformation.Latitude, mapInitialInformation.Longtitude);

                bingMap.MapItemDoubleClick += BingMap_MapItemDoubleClick;
                bingMap.MouseDown += BingMap_MouseDown;

                return true;
            }
            catch (Exception e)
            {
                result = e.Message;

                return false;
            }
        }

        #region Bing Map Events

        private void BingMap_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                if (e.Button.IsLeft())
                {
                    CoordPoint point = bingMap.ScreenPointToCoordPoint(Cursor.Position);
                }
            }
            catch (Exception ex)
            {
                OnAudit($"שגיאת קליק עכבר למפת בינג: {ex.Message}", AuditSeverity.Warning);
            }
        }

        private void BingMap_MapItemDoubleClick(object sender, MapItemClickEventArgs e)
        {
            try
            {
                if (e.MouseArgs.Button == MouseButtons.Left && e.Item is MapPushpin)
                {
                    MapPushpin mapPushpin = (MapPushpin)(e.Item);

                    if (mapPushpin.Information is CriminalEvent)
                    {
                        CriminalEvent criminalEvent = (CriminalEvent)(mapPushpin.Information);

                        frmAddUpdateCriminalRecord showCriminalRecord = new frmAddUpdateCriminalRecord(criminalEvent);
                        showCriminalRecord.Save += ShowCriminalRecord_Save;
                        showCriminalRecord.Audit += ShowCriminalRecord_Audit;
                        showCriminalRecord.Show();
                    }
                }
            }
            catch (Exception ex)
            {
                OnAudit($"שגיאת קליק ל גורם במפת בינג: {ex.Message}", AuditSeverity.Warning);
            }
        }

        private void ShowCriminalRecord_Audit(string message, AuditSeverity severity)
        {
            OnAudit(message, severity);
        }

        private void ShowCriminalRecord_Save(object sender, EventArgs e)
        {
            OnSave(sender, e);
        }

        #endregion

        private bool CriminalEventsToBingMap(out string result)
        {
            double longtitude;
            double latitude;

            result = string.Empty;

            try
            {
                if ((criminalEvents == null) || (criminalEvents.Count == 0))
                {
                    result = "אין אירועים להצגה";

                    return false;
                }

                LocationService locationService = new LocationService(locationServiceInformation.LocationServiceUrl,
                                                                      locationServiceInformation.BingKey,
                                                                      locationServiceInformation.Country,
                                                                      locationServiceInformation.City);

                VectorItemsLayer vectorItemsLayer = new VectorItemsLayer();
                MapItemStorage mapItemStorage = new MapItemStorage();

                MapPushpin mapPushpin;

                foreach (CriminalEvent criminalEvent in criminalEvents)
                {
                    string houseNumber = (criminalEvent.HouseNumber != 0) ? criminalEvent.HouseNumber.ToString() : string.Empty;
                    string address = $"{criminalEvent.Street} {houseNumber}";
                    address = address.Trim();

                    if (string.IsNullOrEmpty(address))
                    {
                        continue;
                    }

                    if (!locationService.AddressToLongtitudeLatitude($"{address}", out longtitude, out latitude, out result))
                    {
                        OnAudit($"לא נמצא מיקום ל: {address}", AuditSeverity.Warning);

                        continue;
                    }

                    mapPushpin = new MapPushpin() { Location = new GeoPoint(longtitude, latitude), 
                                                    Image = Properties.Resources.PushPin, 
                                                    ToolTipPattern = CriminalEventToolTip(criminalEvent),
                                                    Information = criminalEvent };
                    mapItemStorage.Items.Add(mapPushpin);
                }

                vectorItemsLayer.Data = mapItemStorage;

                bingMap.Layers.Add(vectorItemsLayer);

                return true;
            }
            catch (Exception e)
            {
                result = e.Message;

                return false;
            }
        }

        #endregion

        #region GMap

        private bool SetGMap(out string result)
        {
            result = string.Empty;

            try
            {
                GMapProvider.Language = LanguageType.Hebrew;
                gmap.MapProvider = GMapProviders.BingHybridMap;
                GMaps.Instance.Mode = AccessMode.ServerAndCache;
                gmap.Position = new PointLatLng(32.05013752290418, 34.925114988891636);

                gmap.DragButton = MouseButtons.Left;
                gmap.MinZoom = 2;
                gmap.MaxZoom = 18;
                gmap.Zoom = 16;

                //gmap.Bearing = 0;
                gmap.CanDragMap = true;

                gmap.ShowCenter = false;

                return true;
            }
            catch (Exception e)
            {
                result = e.Message;

                return false;
            }
        }

        #endregion

        private string CriminalEventToolTip(CriminalEvent criminalEvent)
        {
            if (criminalEvent == null)
            {
                return string.Empty;
            }

            string criminalEventDescription;

            criminalEventDescription = $"אירוע: {Utils.GetEnumDescription(criminalEvent.Type)}";
            criminalEventDescription += Environment.NewLine;
            criminalEventDescription += $"כתובת: {criminalEvent.Street + " " + criminalEvent.HouseNumber}";
            criminalEventDescription += Environment.NewLine;
            criminalEventDescription += $"תיאור: {criminalEvent.Description}";

            return criminalEventDescription;
        }

        private void OnSave(object sender, EventArgs e)
        {
            if (Save != null)
            {
                Save(sender, e);
            }
        }

        private void OnAudit(string message, AuditSeverity severity)
        {
            if (Audit != null)
            {
                Audit(message, severity);
            }
        }        
    }
}
