using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
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

        public event AuditMessage Audit;

        #endregion

        #region Data Members

        private List<CriminalEvent> criminalEvents;

        private LocationServiceInformation locationServiceInformation;

        #endregion

        #region Constructor

        public frmMap(LocationServiceInformation inLocationServiceInformation, List<CriminalEvent> inCriminalEvents)
        {
            InitializeComponent();

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

                bingMap.ZoomLevel = 16;
                bingMap.CenterPoint = new GeoPoint(32.05013752290418, 34.925114988891636);

                return true;
            }
            catch (Exception e)
            {
                result = e.Message;

                return false;
            }
        }
        
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

                    mapPushpin = new MapPushpin() { Location = new GeoPoint(longtitude, latitude), Image = Properties.Resources.PushPin, ToolTipPattern = CriminalEventToolTip(criminalEvent) };
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

        private void OnAudit(string message, AuditSeverity severity)
        {
            if (Audit != null)
            {
                Audit(message, severity);
            }
        }        
    }
}
