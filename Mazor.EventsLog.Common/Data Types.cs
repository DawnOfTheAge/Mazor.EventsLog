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

        public ConfigurationInformation(string jsonFileName, string jsonFilePath, string logFilePath, bool logToFile)
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

    public class LocationPoint
    {
        public LocationPoint()
        {
            Latitude = 0;
            Longitude = 0;
        }

        public LocationPoint(double latitude, double longtitude)
        {
            Latitude = latitude;
            Longitude = longtitude;
        }

        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }

    public class ContactDetails
    {
        public ContactDetails()
        {
            ContactPerson = string.Empty;
            Phone = string.Empty;
            Email = string.Empty;
        }

        public ContactDetails(string contactPerson, string phone, string email)
        {
            ContactPerson = contactPerson;
            Phone = phone;
            Email = email;
        }

        public string ContactPerson { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
    }

    public class TimeGap
    {
        public DateTime From { get; set; }
        public DateTime To { get; set; }
    }

    public class DataWithIdContainer
    {
        public DataWithIdContainer(List<object> data)
        {
            Id = Constants.NONE;
            Data = data;
        }

        public DataWithIdContainer(int id, List<object> data)
        {
            Id = id;
            Data = data;
        }

        public int Id { get; set; }
        public List<object> Data { get; set; }
    }
}
