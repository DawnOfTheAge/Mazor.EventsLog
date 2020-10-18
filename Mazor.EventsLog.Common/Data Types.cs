using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Mazor.EventsLog.Common
{
    public class EventsLogDatabase
    {
        public EventsLogDatabase()
        {
            CriminalEventsRecordsList = new List<CriminalEvent>();
        }

        public List<CriminalEvent> CriminalEventsRecordsList { get; set; }
        public Street StreetsList { get; set; }
        public CriminalEventTypes CriminalEventTypesList { get; set; }
        public SpecialLocations SpecialLocationsList { get; set; }
        public LawEnforcementUnits LawEnforcementUnitsList { get; set; }
        public CamerasLocations CameraLocationsList { get; set; }
    }

    public class LawEnforcementUnit
    {
        public LawEnforcementUnit(string name)
        {
            Name = name;
            Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
    }

    public class LawEnforcementUnits
    {
        public LawEnforcementUnits()
        {
            LawEnforcementUnitsList = new List<LawEnforcementUnit>();
        }

        public List<LawEnforcementUnit> LawEnforcementUnitsList { get; set; }

        public bool AddLawEnforcementUnit(string lawEnforcementUnitName, out string result)
        {
            result = string.Empty;

            try
            {
                if (LawEnforcementUnitsList == null)
                {
                    result = "רשימת גורמי אכיפה לא קיימת";

                    return false;
                }

                if (LawEnforcementUnitExists(lawEnforcementUnitName))
                {
                    result = $"שם גורם אכיפה קיים: {lawEnforcementUnitName}";

                    return false;
                }

                LawEnforcementUnitsList.Add(new LawEnforcementUnit(lawEnforcementUnitName));

                return true;
            }
            catch (Exception e)
            {
                result = e.Message;

                return false;
            }
        }

        private bool LawEnforcementUnitExists(string lawEnforcementUnitName)
        {
            try
            {
                if ((LawEnforcementUnitsList == null) || (LawEnforcementUnitsList.Count == 0))
                {
                    return false;
                }

                LawEnforcementUnit lawEnforcementUnitExists = LawEnforcementUnitsList.Where(lawEnforcementUnit => lawEnforcementUnit.Name.Trim() == lawEnforcementUnitName.Trim()).First();

                return (lawEnforcementUnitExists != null);
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool DeleteLawEnforcementUnit(Guid lawEnforcementUnitId, out string result)
        {
            result = string.Empty;

            try
            {
                if ((LawEnforcementUnitsList == null) || (LawEnforcementUnitsList.Count == 0))
                {
                    result = "רשימת גורמי אכיפה ריקה";

                    return false;
                }

                LawEnforcementUnitsList.Remove(LawEnforcementUnitsList.Where(lawEnforcementUnit => lawEnforcementUnit.Id == lawEnforcementUnitId).First());

                return true;
            }
            catch (Exception e)
            {
                result = e.Message;

                return false;
            }
        }

        public List<LawEnforcementUnit> GetLawEnforcementUnits()
        {
            return LawEnforcementUnitsList;
        }
    }

    public class CameraLocation
    {
        public CameraLocation(string name, double latitude, double longtitude)
        {
            Name = name;
            Longtitude = longtitude;
            Latitude = latitude;
            Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public double Longtitude { get; set; }
        public double Latitude { get; set; }
    }

    public class CamerasLocations
    {
        public CamerasLocations()
        {
            CamerasLocationsList = new List<CameraLocation>();
        }

        public List<CameraLocation> CamerasLocationsList { get; set; }

        public bool AddCameraLocation(string cameraLocationName, double latitudeout, double longtitude, string result)
        {
            result = string.Empty;

            try
            {
                if (CamerasLocationsList == null)
                {
                    result = "רשימת מצלמות לא קיימת";

                    return false;
                }

                if (CameraLocationExists(cameraLocationName))
                {
                    result = $"שם מצלמה קיים: {cameraLocationName}";

                    return false;
                }

                CamerasLocationsList.Add(new CameraLocation(cameraLocationName, latitudeout, longtitude));

                return true;
            }
            catch (Exception e)
            {
                result = e.Message;

                return false;
            }
        }

        private bool CameraLocationExists(string cameraLocationName)
        {
            try
            {
                if ((CamerasLocationsList == null) || (CamerasLocationsList.Count == 0))
                {
                    return false;
                }

                CameraLocation cameraLocationExists = CamerasLocationsList.Where(cameraLocation => cameraLocation.Name.Trim() == cameraLocationName.Trim()).First();

                return (cameraLocationExists != null);
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool DeleteCameraLocation(Guid cameraLocationId, out string result)
        {
            result = string.Empty;

            try
            {
                if ((CamerasLocationsList == null) || (CamerasLocationsList.Count == 0))
                {
                    result = "רשימת המצלמות ריקה";

                    return false;
                }

                CamerasLocationsList.Remove(CamerasLocationsList.Where(cameraLocation => cameraLocation.Id == cameraLocationId).First());

                return true;
            }
            catch (Exception e)
            {
                result = e.Message;

                return false;
            }
        }

        public bool GetLocation(Guid cameraLocationId, out double latitude, out double longtitude, out string result)
        {
            result = string.Empty;

            longtitude = 0;
            latitude = 0;

            try
            {
                CameraLocation cameraLocationExists = CamerasLocationsList.Where(cameraLocation => cameraLocation.Id == cameraLocationId).First();

                longtitude = cameraLocationExists.Longtitude;
                latitude = cameraLocationExists.Latitude;

                return true;
            }
            catch (Exception e)
            {
                result = e.Message;

                return false;
            }
        }

        public List<CameraLocation> GetCamerasLocations()
        {
            return CamerasLocationsList;
        }
    }

    public class SpecialLocation
    {
        public SpecialLocation(string name, double latitude, double longtitude)
        {
            Name = name;
            Longtitude = longtitude;
            Latitude = latitude;
            Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public double Longtitude { get; set; }
        public double Latitude { get; set; }
    }

    public class SpecialLocations
    {
        public SpecialLocations()
        {
            SpecialLocationsList = new List<SpecialLocation>();
        }

        public List<SpecialLocation> SpecialLocationsList { get; set; }

        public bool AddSpecialLocation(string specialLocationName, double latitudeout, double longtitude, string result)
        {
            result = string.Empty;

            try
            {
                if (SpecialLocationsList == null)
                {
                    result = "רשימת מיקומים קבועים לא קיימת";

                    return false;
                }

                if (SpecialLocationExists(specialLocationName))
                {
                    result = $"שם מיקום קבוע קיים: {specialLocationName}";

                    return false;
                }

                SpecialLocationsList.Add(new SpecialLocation(specialLocationName, latitudeout, longtitude));

                return true;
            }
            catch (Exception e)
            {
                result = e.Message;

                return false;
            }
        }

        private bool SpecialLocationExists(string specialLocationName)
        {
            try
            {
                if ((SpecialLocationsList == null) || (SpecialLocationsList.Count == 0))
                {
                    return false;
                }

                SpecialLocation specialLocationExists = SpecialLocationsList.Where(specialLocation => specialLocation.Name.Trim() == specialLocationName.Trim()).First();

                return (specialLocationExists != null);
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool DeleteSpecialLocation(Guid specialLocationId, out string result)
        {
            result = string.Empty;

            try
            {
                if ((SpecialLocationsList == null) || (SpecialLocationsList.Count == 0))
                {
                    result = "רשימת הרחובות ריקה";

                    return false;
                }

                SpecialLocationsList.Remove(SpecialLocationsList.Where(specialLocation => specialLocation.Id == specialLocationId).First());

                return true;
            }
            catch (Exception e)
            {
                result = e.Message;

                return false;
            }
        }

        public bool GetLocation(Guid specialLocationId, out double latitude, out double longtitude ,out string result)
        {
            result = string.Empty;

            longtitude = 0;
            latitude = 0;

            try
            {
                SpecialLocation specialLocationExists = SpecialLocationsList.Where(specialLocation => specialLocation.Id == specialLocationId).First();

                longtitude = specialLocationExists.Longtitude;
                latitude = specialLocationExists.Latitude;

                return true;
            }
            catch (Exception e)
            {
                result = e.Message;

                return false;
            }
        }

        public List<SpecialLocation> GetSpecialLocations()
        {
            return SpecialLocationsList;
        }
    }

    public class Street
    {
        public Street(string name)
        {
            Name = name;
            Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
    }

    public class Streets
    {
        public Streets()
        {
            StreetsList = new List<Street>();
        }

        public List<Street> StreetsList { get; set; }

        public bool AddStreet(string streetName, out string result)
        {
            result = string.Empty;

            try
            {
                if (StreetsList == null)
                {
                    result = "רשימת הרחובות לא קיימת";

                    return false;
                }

                if (StreetExists(streetName))
                {
                    result = $"שם רחוב קיים: {streetName}";

                    return false;
                }

                StreetsList.Add(new Street(streetName));

                return true;
            }
            catch (Exception e)
            {
                result = e.Message;

                return false;
            }
        }

        private bool StreetExists(string streetName)
        {
            try
            {
                if ((StreetsList == null) || (StreetsList.Count == 0))
                {
                    return false;
                }

                Street streetExists = StreetsList.Where(street => street.Name.Trim() == streetName.Trim()).First();

                return (streetExists != null);
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool DeleteStreet(Guid streetId, out string result)
        {
            result = string.Empty;

            try
            {
                if ((StreetsList == null) || (StreetsList.Count == 0))
                {
                    result = "רשימת הרחובות ריקה";

                    return false;
                }

                StreetsList.Remove(StreetsList.Where(street => street.Id == streetId).First());

                return true;
            }
            catch (Exception e)
            {
                result = e.Message;

                return false;
            }
        }

        public List<Street> GetStreets()
        {
            return StreetsList;
        }
    }

    public class CriminalEventType1
    {
        public CriminalEventType1(string name)
        {
            Name = name;
            Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
    }

    public class CriminalEventTypes
    {
        public CriminalEventTypes()
        {
            CriminalEventTypesList = new List<CriminalEventType1>();
        }

        public List<CriminalEventType1> CriminalEventTypesList { get; set; }

        public bool AddCriminalEventType(string criminalEventTypeName, out string result)
        {
            result = string.Empty;

            try
            {
                if (CriminalEventTypesList == null)
                {
                    result = "רשימת סוגי אירוע לא קיימת";

                    return false;
                }

                if (CriminalEventTypeExists(criminalEventTypeName))
                {
                    result = $"שם אירוע קיים: {criminalEventTypeName}";

                    return false;
                }

                CriminalEventTypesList.Add(new CriminalEventType1(criminalEventTypeName));

                return true;
            }
            catch (Exception e)
            {
                result = e.Message;

                return false;
            }
        }

        private bool CriminalEventTypeExists(string criminalEventTypeName)
        {
            try
            {
                if ((CriminalEventTypesList == null) || (CriminalEventTypesList.Count == 0))
                {
                    return false;
                }

                CriminalEventType1 criminalEventTypeExists = CriminalEventTypesList.Where(criminalEventType => criminalEventType.Name.Trim() == criminalEventTypeName.Trim()).First();

                return (criminalEventTypeExists != null);
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool DeleteCriminalEventType(Guid streetId, out string result)
        {
            result = string.Empty;

            try
            {
                if ((CriminalEventTypesList == null) || (CriminalEventTypesList.Count == 0))
                {
                    result = "רשימת סוגי אירוע ריקה";

                    return false;
                }

                CriminalEventTypesList.Remove(CriminalEventTypesList.Where(criminalEventType => criminalEventType.Id == streetId).First());

                return true;
            }
            catch (Exception e)
            {
                result = e.Message;

                return false;
            }
        }

        public List<CriminalEventType1> GetCriminalEventTypes()
        {
            return CriminalEventTypesList;
        }
    }

    public class CriminalEvent : EventArgs
    {
        public CriminalEvent()
        { 
        }

        public CriminalEvent(CriminalEventType type, 
                             Guid id, 
                             int houseNumber,
                             DateTime time,
                             string street,
                             string family, 
                             string description,
                             string whatWasStolen,
                             string arrivalDirection,
                             string whoArrivedAfterTheEvent)
        {
            Type = type;
            Id = id;
            HouseNumber = houseNumber;
            Time = time;
            Street = street;
            Family = family;
            Description = description;
            WhatWasStolen = whatWasStolen;
            ArrivalDirection = arrivalDirection;
            WhoArrivedAfterTheEvent = whoArrivedAfterTheEvent;
        }

        public CriminalEventType Type { get; set; }

        public Guid Id { get; set; }
        public int HouseNumber { get; set; }

        public DateTime Time { get; set; }

        public string Street { get; set; }
        public string Family { get; set; }
        public string Description { get; set; }
        public string WhatWasStolen { get; set; }
        public string ArrivalDirection { get; set; }
        public string WhoArrivedAfterTheEvent { get; set; }
    }

    public class SearchFilter : EventArgs
    {
        #region Constructors

        public SearchFilter(List<CriminalEventType> inCriminalEventTypes)
        {
            CriminalEventTypes = inCriminalEventTypes;
            CriminalEventTypesSearchOn = true;

            KeyWordsSearchOn = false;
            TimeFilterOn = false;
            DateFilterOn = false;
            DaysFilterOn = false;
            KeyWordsSearchAddressOn = false;
            KeyWordsSearchFamilyOn = false;

            Logic = QueryLogic.Unknown;
        }

        public SearchFilter(List<string> inKeyWordsSearch)
        {
            KeyWordsSearch = inKeyWordsSearch;
            KeyWordsSearchOn = true;

            TimeFilterOn = false;
            DateFilterOn = false;
            DaysFilterOn = false;
            CriminalEventTypesSearchOn = false;
            KeyWordsSearchAddressOn = false;
            KeyWordsSearchFamilyOn = false;

            Logic = QueryLogic.Unknown;
        }

        public SearchFilter(DaysFilter inDays)
        {
            Days = inDays;
            DaysFilterOn = true;

            TimeFilterOn = false;
            DateFilterOn = false;
            KeyWordsSearchOn = false;
            CriminalEventTypesSearchOn = false;
            KeyWordsSearchAddressOn = false;
            KeyWordsSearchFamilyOn = false;

            Logic = QueryLogic.Unknown;
        }

        public SearchFilter(TimeFilter inTime)
        {
            Time = inTime;
            TimeFilterOn = true;
            
            DaysFilterOn = false;
            DateFilterOn = false;
            KeyWordsSearchOn = false;
            CriminalEventTypesSearchOn = false;
            KeyWordsSearchAddressOn = false;
            KeyWordsSearchFamilyOn = false;
   
            Logic = QueryLogic.Unknown;
        }

        public SearchFilter(DateFilter inDate)
        {
            Date = inDate;
            DateFilterOn = true;
            
            TimeFilterOn = false;
            DaysFilterOn = false;
            KeyWordsSearchOn = false;
            CriminalEventTypesSearchOn = false;
            KeyWordsSearchAddressOn = false;
            KeyWordsSearchFamilyOn = false;

            Logic = QueryLogic.Unknown;
        }

        public SearchFilter(DaysFilter inDays, TimeFilter inTime, DateFilter inDate)
        {
            Days = inDays;
            Time = inTime;
            Date = inDate;

            DaysFilterOn = (inDays == null) ? false : true;
            TimeFilterOn = (inTime == null) ? false : true;
            DateFilterOn = (inDate == null) ? false : true;
            KeyWordsSearchOn = false;
            CriminalEventTypesSearchOn = false;
            KeyWordsSearchAddressOn = false;
            KeyWordsSearchFamilyOn = false;
 
            Logic = QueryLogic.Unknown;
        }

        public SearchFilter(List<CriminalEventType> inCriminalEventTypes, 
                            List<string> inKeyWordsSearchAddress, 
                            List<string> inKeyWordsSearchFamily,
                            DaysFilter inDays, 
                            TimeFilter inTime, 
                            DateFilter inDate,
                            QueryLogic logic)
        {
            Days = inDays;
            Time = inTime;
            Date = inDate;

            DaysFilterOn = (inDays == null) ? false : true;
            TimeFilterOn = (inTime == null) ? false : true;
            DateFilterOn = (inDate == null) ? false : true;            

            KeyWordsSearchAddress = inKeyWordsSearchAddress;
            KeyWordsSearchAddressOn = (KeyWordsSearchAddress != null);

            KeyWordsSearchFamily = inKeyWordsSearchFamily;
            KeyWordsSearchFamilyOn = (KeyWordsSearchFamily != null);

            CriminalEventTypes = inCriminalEventTypes;
            CriminalEventTypesSearchOn = (CriminalEventTypes != null);

            Logic = logic;
        }

        #endregion

        public QueryLogic Logic { get; set; }

        public bool DaysFilterOn { get; set; }
        public bool TimeFilterOn { get; set; }
        public bool DateFilterOn { get; set; }
        public bool KeyWordsSearchOn { get; set; }
        public bool KeyWordsSearchAddressOn { get; set; }
        public bool KeyWordsSearchFamilyOn { get; set; }
        public bool CriminalEventTypesSearchOn { get; set; }

        public DaysFilter Days { get; set; }
        public TimeFilter Time { get; set; }
        public DateFilter Date { get; set; }

        public KeyWordSearchType KwsType { get; set; }

        public List<string> KeyWordsSearch { get; set; }
        public List<string> KeyWordsSearchAddress { get; set; }
        public List<string> KeyWordsSearchFamily { get; set; }

        public List<CriminalEventType> CriminalEventTypes { get; set; }
    }

    public class DaysFilter
    {
        public DaysFilter()
        {
            Days = new List<DayOfWeek>();
        }

        public DaysFilter(List<DayOfWeek> inDays)
        {
            Days = inDays;
        }

        public List<DayOfWeek> Days { get; set; }
    }

    public class TimeFilter
    {
        public TimeFilter()
        {
        }

        public TimeFilter(bool inFromTo, DateTime inTime)
        {
            FromTo = inFromTo;
            Time = inTime;
        }

        public TimeFilter(bool inFromTo, DateTime inTimeFrom, DateTime inTimeTo)
        {
            FromTo = inFromTo;
            TimeFrom = inTimeFrom;
            TimeTo = inTimeTo;
        }

        public DateTime Time { get; set; }
        public DateTime TimeFrom { get; set; }
        public DateTime TimeTo { get; set; }

        public bool FromTo { get; set; }
    }

    public class DateFilter
    {
        public DateFilter()
        {
        }

        public DateFilter(bool inFromTo, DateTime inDate)
        {
            FromTo = inFromTo;
            Date = inDate;
        }

        public DateFilter(bool inFromTo, DateTime inDateFrom, DateTime inDateTo)
        {
            FromTo = inFromTo;
            DateFrom = inDateFrom;
            DateTo = inDateTo;
        }

        public DateTime Date { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }

        public bool FromTo { get; set; }
    }

    public class ConfigurationInformation : EventArgs
    {
        public ConfigurationInformation()
        {
            JsonFileName = Constants.CITY;
            JsonFilePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            LogFilePath = string.Empty;

            LogToFile = false;
        }

        public ConfigurationInformation(string jsonFileName,  string jsonFilePath, string logFilePath, bool logToFile)
        {
            JsonFileName = jsonFileName;
            JsonFilePath = jsonFilePath;
            LogFilePath = logFilePath;

            LogToFile = logToFile;
        }

        public string JsonFileName { get; set; }
        public string JsonFilePath { get; set; }
        public string LogFilePath { get; set; }

        public bool LogToFile { get; set; }
    }

    public class LocationServiceInformation
    {
        public LocationServiceInformation()
        {
            Country = string.Empty;
            City = string.Empty;
            LocationServiceUrl = string.Empty;
            BingKey = string.Empty;
        }

        public LocationServiceInformation(string country, string city, string bingKey, string locationServiceUrl)
        {
            Country = country;
            City = city;
            LocationServiceUrl = locationServiceUrl;
            BingKey = bingKey;
        }

        public string Country { get; set; }
        public string City { get; set; }
        public string LocationServiceUrl { get; set; }
        public string BingKey { get; set; }
    }

    public class MapInitialInformation
    {
        public MapInitialInformation()
        {
            ZoomLevel = 0;
        }

        public MapInitialInformation(int zoomLevel)
        {
            ZoomLevel = zoomLevel;
        }

        public int ZoomLevel { get; set; }
    }
}
