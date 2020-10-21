using System;
using System.Collections.Generic;
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
            Settings = new EventsLogSettings();
            CriminalEventsRecordsList = new List<CriminalEvent>();
            StreetsList = new Streets();
            CriminalEventTypesList = new CriminalEventTypes();
            SpecialLocationsList = new SpecialLocations();
            LawEnforcementUnitsList = new LawEnforcementUnits();
            CameraLocationsList = new CamerasLocations();
            TrainingUnitsList = new TrainingUnits();
        }

        public EventsLogSettings Settings { get; set; }
        public List<CriminalEvent> CriminalEventsRecordsList { get; set; }
        public Streets StreetsList { get; set; }
        public CriminalEventTypes CriminalEventTypesList { get; set; }
        public SpecialLocations SpecialLocationsList { get; set; }
        public LawEnforcementUnits LawEnforcementUnitsList { get; set; }
        public CamerasLocations CameraLocationsList { get; set; }
        public TrainingUnits TrainingUnitsList { get; set; }
    }

    #region Settings

    public class EventsLogSettings
    {
        public EventsLogSettings()
        {
            JsonFileName = "EventsLog";
            JsonFilePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            LogFilePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            LogToFile = false;
        }

        public string JsonFileName { get; set; }
        public string JsonFilePath { get; set; }
        public string LogFilePath { get; set; }
        public bool LogToFile { get; set; }

        public LocationServiceInformation LocationService { get; set; }
        public MapInitialInformation Map { get; set; }
        public string PingTestAddress { get; set; }
        public int PingTestIntervalInSeconds { get; set; }
    }

    #endregion

    #region Training Units

    public class UnitData
    {
        public ContactDetails Details { get; set; }
        public TimeGap Dates { get; set; }
        public TimeGap Hours { get; set; }
    }

    public class TrainingUnit
    {
        public TrainingUnit(string name, UnitData trainingUnitData)
        {
            Name = name;
            Id = Guid.NewGuid();
            Details = trainingUnitData;
        }

        public TrainingUnit(Guid id, string name, UnitData trainingUnitData)
        {
            Name = name;
            Id = id;
            Details = trainingUnitData;
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public UnitData Details { get; set; }
    }

    public class TrainingUnits : ICrud<TrainingUnit>
    {
        public TrainingUnits()
        {
            ItemsList = new List<TrainingUnit>();
        }

        public List<TrainingUnit> ItemsList { get; set; }

        public bool Add(string trainingUnitName, object data, out Guid newId, out string result)
        {
            result = string.Empty;
            newId = Guid.Empty;

            try
            {
                if (ItemsList == null)
                {
                    result = "רשימת גורמי אכיפה לא קיימת";

                    return false;
                }

                if (Exists(trainingUnitName))
                {
                    result = $"שם גורם אכיפה קיים: {trainingUnitName}";

                    return false;
                }

                DataWithGuidContainer container = (DataWithGuidContainer)data;
                List<object> dataList = (List<object>)(container.Data);
                UnitData trainingUnitData = (UnitData)(dataList[0]);

                if (container.Id == Guid.Empty)
                {
                    ItemsList.Add(new TrainingUnit(trainingUnitName, trainingUnitData));
                    newId = ItemsList[ItemsList.Count - 1].Id;
                }
                else
                {
                    ItemsList.Add(new TrainingUnit(container.Id, trainingUnitName, trainingUnitData));
                }

                return true;
            }
            catch (Exception e)
            {
                result = e.Message;

                return false;
            }
        }

        public bool Exists(string trainingUnitName)
        {
            try
            {
                if ((ItemsList == null) || (ItemsList.Count == 0))
                {
                    return false;
                }

                TrainingUnit trainingUnitExists = ItemsList.Where(trainingUnit => trainingUnit.Name.Trim() == trainingUnitName.Trim()).First();

                return (trainingUnitExists != null);
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Delete(Guid trainingUnitId, out string result)
        {
            result = string.Empty;

            try
            {
                if ((ItemsList == null) || (ItemsList.Count == 0))
                {
                    result = "רשימת גורמי אכיפה ריקה";

                    return false;
                }

                ItemsList.Remove(ItemsList.Where(trainingUnit => trainingUnit.Id == trainingUnitId).First());

                return true;
            }
            catch (Exception e)
            {
                result = e.Message;

                return false;
            }
        }

        public List<TrainingUnit> GetItemsList()
        {
            return ItemsList;
        }
    }

    #endregion

    #region Law Enforcement Units

    public class LawEnforcementUnit
    {
        public LawEnforcementUnit(string name, ContactDetails contactDetails)
        {
            Name = name;
            Id = Guid.NewGuid();
            Details = contactDetails;
        }

        public LawEnforcementUnit(Guid id, string name, ContactDetails contactDetails)
        {
            Id = id;
            Name = name;
            Details = contactDetails;
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public ContactDetails Details { get; set; }
    }

    public class LawEnforcementUnits : ICrud<LawEnforcementUnit>
    {
        public LawEnforcementUnits()
        {
            ItemsList = new List<LawEnforcementUnit>();
        }

        public List<LawEnforcementUnit> ItemsList { get; set; }

        public bool Add(string lawEnforcementUnitName, object data, out Guid newId, out string result)
        {
            result = string.Empty;
            newId = Guid.Empty;

            try
            {
                if (ItemsList == null)
                {
                    result = "רשימת גורמי אכיפה לא קיימת";

                    return false;
                }

                if (Exists(lawEnforcementUnitName))
                {
                    result = $"שם גורם אכיפה קיים: {lawEnforcementUnitName}";

                    return false;
                }

                DataWithGuidContainer container = (DataWithGuidContainer)data;
                List<object> dataList = (List<object>)(container.Data);
                ContactDetails contactDetails = (ContactDetails)(dataList[0]);

                if (container.Id == Guid.Empty)
                {
                    ItemsList.Add(new LawEnforcementUnit(lawEnforcementUnitName, contactDetails));
                    newId = ItemsList[ItemsList.Count - 1].Id;
                }
                else
                {
                    ItemsList.Add(new LawEnforcementUnit(container.Id, lawEnforcementUnitName, contactDetails));
                }

                return true;
            }
            catch (Exception e)
            {
                result = e.Message;

                return false;
            }
        }

        public bool Exists(string lawEnforcementUnitName)
        {
            try
            {
                if ((ItemsList == null) || (ItemsList.Count == 0))
                {
                    return false;
                }

                LawEnforcementUnit lawEnforcementUnitExists = ItemsList.Where(lawEnforcementUnit => lawEnforcementUnit.Name.Trim() == lawEnforcementUnitName.Trim()).First();

                return (lawEnforcementUnitExists != null);
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Delete(Guid lawEnforcementUnitId, out string result)
        {
            result = string.Empty;

            try
            {
                if ((ItemsList == null) || (ItemsList.Count == 0))
                {
                    result = "רשימת גורמי אכיפה ריקה";

                    return false;
                }

                ItemsList.Remove(ItemsList.Where(lawEnforcementUnit => lawEnforcementUnit.Id == lawEnforcementUnitId).First());

                return true;
            }
            catch (Exception e)
            {
                result = e.Message;

                return false;
            }
        }

        public List<LawEnforcementUnit> GetItemsList()
        {
            return ItemsList;
        }
    }

    #endregion

    #region Cameras Locations

    public class CameraLocation
    {
        public CameraLocation(string name, LocationPoint LocationPoint)
        {
            Name = name;
            Point = LocationPoint;
            Id = Guid.NewGuid();
        }

        public CameraLocation(Guid id, string name, LocationPoint LocationPoint)
        {
            Name = name;
            Point = LocationPoint;
            Id = id;
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public LocationPoint Point { get; set; }
    }

    public class CamerasLocations : ICrud<CameraLocation>
    {
        public CamerasLocations()
        {
            ItemsList = new List<CameraLocation>();
        }

        public List<CameraLocation> ItemsList { get; set; }

        public bool Add(string cameraLocationName, object data, out Guid newId, out string result)
        {
            result = string.Empty;
            newId = Guid.Empty;

            try
            {
                if (ItemsList == null)
                {
                    result = "רשימת מצלמות לא קיימת";

                    return false;
                }

                if (Exists(cameraLocationName))
                {
                    result = $"שם מצלמה קיים: {cameraLocationName}";

                    return false;
                }

                DataWithGuidContainer container = (DataWithGuidContainer)data;
                List<object> dataList = (List<object>)(container.Data);
                LocationPoint locationPoint = (LocationPoint)(dataList[0]);

                if (container.Id == Guid.Empty)
                {
                    ItemsList.Add(new CameraLocation(cameraLocationName, locationPoint));
                    newId = ItemsList[ItemsList.Count - 1].Id;
                }
                else
                {
                    ItemsList.Add(new CameraLocation(container.Id, cameraLocationName, locationPoint));
                }

                return true;
            }
            catch (Exception e)
            {
                result = e.Message;

                return false;
            }
        }

        public bool Exists(string cameraLocationName)
        {
            try
            {
                if ((ItemsList == null) || (ItemsList.Count == 0))
                {
                    return false;
                }

                CameraLocation cameraLocationExists = ItemsList.Where(cameraLocation => cameraLocation.Name.Trim() == cameraLocationName.Trim()).First();

                return (cameraLocationExists != null);
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Delete(Guid cameraLocationId, out string result)
        {
            result = string.Empty;

            try
            {
                if ((ItemsList == null) || (ItemsList.Count == 0))
                {
                    result = "רשימת המצלמות ריקה";

                    return false;
                }

                ItemsList.Remove(ItemsList.Where(cameraLocation => cameraLocation.Id == cameraLocationId).First());

                return true;
            }
            catch (Exception e)
            {
                result = e.Message;

                return false;
            }
        }

        public bool GetLocation(Guid cameraLocationId, out LocationPoint point, out string result)
        {
            result = string.Empty;

            point = null;

            try
            {
                CameraLocation cameraLocationExists = ItemsList.Where(cameraLocation => cameraLocation.Id == cameraLocationId).First();

                point = cameraLocationExists.Point;

                return true;
            }
            catch (Exception e)
            {
                result = e.Message;

                return false;
            }
        }

        public List<CameraLocation> GetItemsList()
        {
            return ItemsList;
        }
    }

    #endregion

    #region Special Locations

    public class SpecialLocation
    {
        public SpecialLocation(string name, LocationPoint point)
        {
            Name = name;
            Point = point;
            Id = Guid.NewGuid();
        }

        public SpecialLocation(Guid id, string name, LocationPoint point)
        {
            Name = name;
            Point = point;
            Id = id;
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public LocationPoint Point { get; set; }
    }

    public class SpecialLocations : ICrud<SpecialLocation>
    {
        public SpecialLocations()
        {
            ItemsList = new List<SpecialLocation>();
        }

        public List<SpecialLocation> ItemsList { get; set; }

        public bool Add(string specialLocationName, object data, out Guid newId, out string result)
        {
            result = string.Empty;
            newId = Guid.Empty;

            try
            {
                if (ItemsList == null)
                {
                    result = "רשימת מיקומים קבועים לא קיימת";

                    return false;
                }

                if (Exists(specialLocationName))
                {
                    result = $"שם מיקום קבוע קיים: {specialLocationName}";

                    return false;
                }

                DataWithGuidContainer container = (DataWithGuidContainer)data;
                List<object> dataList = (List<object>)(container.Data);
                LocationPoint locationPoint = (LocationPoint)(dataList[0]);

                if (container.Id == Guid.Empty)
                {
                    ItemsList.Add(new SpecialLocation(specialLocationName, locationPoint));
                    newId = ItemsList[ItemsList.Count - 1].Id;
                }
                else
                {
                    ItemsList.Add(new SpecialLocation(container.Id, specialLocationName, locationPoint));
                }

                return true;
            }
            catch (Exception e)
            {
                result = e.Message;

                return false;
            }
        }

        public bool Exists(string specialLocationName)
        {
            try
            {
                if ((ItemsList == null) || (ItemsList.Count == 0))
                {
                    return false;
                }

                SpecialLocation specialLocationExists = ItemsList.Where(specialLocation => specialLocation.Name.Trim() == specialLocationName.Trim()).First();

                return (specialLocationExists != null);
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Delete(Guid specialLocationId, out string result)
        {
            result = string.Empty;

            try
            {
                if ((ItemsList == null) || (ItemsList.Count == 0))
                {
                    result = "רשימת הרחובות ריקה";

                    return false;
                }

                ItemsList.Remove(ItemsList.Where(specialLocation => specialLocation.Id == specialLocationId).First());

                return true;
            }
            catch (Exception e)
            {
                result = e.Message;

                return false;
            }
        }

        public bool GetLocation(Guid specialLocationId, out LocationPoint point, out string result)
        {
            result = string.Empty;

            point = null;

            try
            {
                SpecialLocation specialLocationExists = ItemsList.Where(specialLocation => specialLocation.Id == specialLocationId).First();

                point = specialLocationExists.Point;

                return true;
            }
            catch (Exception e)
            {
                result = e.Message;

                return false;
            }
        }

        public List<SpecialLocation> GetItemsList()
        {
            return ItemsList;
        }
    }

    #endregion

    #region Arrival Directions

    public class ArrivalDirection
    {
        public ArrivalDirection(string name)
        {
            Name = name;
            Id = Guid.NewGuid();
        }

        public ArrivalDirection(Guid id, string name)
        {
            Name = name;
            Id = id;
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
    }

    public class ArrivalDirections : ICrud<ArrivalDirection>
    {
        public ArrivalDirections()
        {
            ItemsList = new List<ArrivalDirection>();
        }

        public List<ArrivalDirection> ItemsList { get; set; }

        public bool Add(string arrivalDirectionName, object data, out Guid newId, out string result)
        {
            result = string.Empty;
            newId = Guid.Empty;

            try
            {
                if (ItemsList == null)
                {
                    result = "רשימת כווני הגעה לא קיימת";

                    return false;
                }

                if (Exists(arrivalDirectionName))
                {
                    result = $"שם כוון הגעה קיים: {arrivalDirectionName}";

                    return false;
                }

                if (data == null)
                {
                    ItemsList.Add(new ArrivalDirection(arrivalDirectionName));
                    newId = ItemsList[ItemsList.Count - 1].Id;
                }
                else
                {
                    DataWithGuidContainer container = (DataWithGuidContainer)data;
                    ItemsList.Add(new ArrivalDirection(container.Id, arrivalDirectionName));
                }

                return true;
            }
            catch (Exception e)
            {
                result = e.Message;

                return false;
            }
        }

        public bool Exists(string arrivalDirectionName)
        {
            try
            {
                if ((ItemsList == null) || (ItemsList.Count == 0))
                {
                    return false;
                }

                ArrivalDirection arrivalDirectionExists = ItemsList.Where(arrivalDirection => arrivalDirection.Name.Trim() == arrivalDirectionName.Trim()).First();

                return (arrivalDirectionExists != null);
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Delete(Guid arrivalDirectionId, out string result)
        {
            result = string.Empty;

            try
            {
                if ((ItemsList == null) || (ItemsList.Count == 0))
                {
                    result = "רשימת כווני הגעה ריקה";

                    return false;
                }

                ItemsList.Remove(ItemsList.Where(arrivalDirection => arrivalDirection.Id == arrivalDirectionId).First());

                return true;
            }
            catch (Exception e)
            {
                result = e.Message;

                return false;
            }
        }

        public List<ArrivalDirection> GetItemsList()
        {
            return ItemsList;
        }
    }

    #endregion

    #region Streets

    public class Street
    {
        public Street(string name)
        {
            Name = name;
            Id = Guid.NewGuid();
        }

        public Street(Guid id, string name)
        {
            Name = name;
            Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
    }

    public class Streets : ICrud<Street>
    {
        public Streets()
        {
            ItemsList = new List<Street>();
        }

        public List<Street> ItemsList { get; set; }

        public bool Add(string streetName, object data, out Guid newId, out string result)
        {
            result = string.Empty;
            newId = Guid.Empty;

            try
            {
                if (ItemsList == null)
                {
                    result = "רשימת הרחובות לא קיימת";

                    return false;
                }

                if (Exists(streetName))
                {
                    result = $"שם רחוב קיים: {streetName}";

                    return false;
                }

                if (data == null)
                {
                    ItemsList.Add(new Street(streetName));
                    newId = ItemsList[ItemsList.Count - 1].Id;
                }
                else
                {
                    DataWithGuidContainer container = (DataWithGuidContainer)data;
                    ItemsList.Add(new Street(container.Id, streetName));
                }

                return true;
            }
            catch (Exception e)
            {
                result = e.Message;

                return false;
            }
        }

        public bool Exists(string streetName)
        {
            try
            {
                if ((ItemsList == null) || (ItemsList.Count == 0))
                {
                    return false;
                }

                Street streetExists = ItemsList.Where(street => street.Name.Trim() == streetName.Trim()).First();

                return (streetExists != null);
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Delete(Guid streetId, out string result)
        {
            result = string.Empty;

            try
            {
                if ((ItemsList == null) || (ItemsList.Count == 0))
                {
                    result = "רשימת הרחובות ריקה";

                    return false;
                }

                ItemsList.Remove(ItemsList.Where(street => street.Id == streetId).First());

                return true;
            }
            catch (Exception e)
            {
                result = e.Message;

                return false;
            }
        }

        public List<Street> GetItemsList()
        {
            return ItemsList;
        }
    }

    #endregion

    #region Criminal Event Types

    public class CriminalEventType1
    {
        public CriminalEventType1(string name)
        {
            Name = name;
            Id = Guid.NewGuid();
        }

        public CriminalEventType1(Guid id, string name)
        {
            Name = name;
            Id = id;
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
    }

    public class CriminalEventTypes : ICrud<CriminalEventType1>
    {
        public CriminalEventTypes()
        {
            ItemsList = new List<CriminalEventType1>();
        }

        public List<CriminalEventType1> ItemsList { get; set; }

        public bool Add(string criminalEventTypeName, object data, out Guid newId, out string result)
        {
            result = string.Empty;
            newId = Guid.Empty;

            try
            {
                if (ItemsList == null)
                {
                    result = "רשימת סוגי אירוע לא קיימת";

                    return false;
                }

                if (Exists(criminalEventTypeName))
                {
                    result = $"שם אירוע קיים: {criminalEventTypeName}";

                    return false;
                }                

                if (data == null)
                {
                    ItemsList.Add(new CriminalEventType1(criminalEventTypeName));
                    newId = ItemsList[ItemsList.Count - 1].Id;
                }
                else
                {
                    DataWithGuidContainer container = (DataWithGuidContainer)data;
                    ItemsList.Add(new CriminalEventType1(container.Id, criminalEventTypeName));
                }

                return true;
            }
            catch (Exception e)
            {
                result = e.Message;

                return false;
            }
        }

        public bool Exists(string criminalEventTypeName)
        {
            try
            {
                if ((ItemsList == null) || (ItemsList.Count == 0))
                {
                    return false;
                }

                CriminalEventType1 criminalEventTypeExists = ItemsList.Where(criminalEventType => criminalEventType.Name.Trim() == criminalEventTypeName.Trim()).First();

                return (criminalEventTypeExists != null);
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Delete(Guid streetId, out string result)
        {
            result = string.Empty;

            try
            {
                if ((ItemsList == null) || (ItemsList.Count == 0))
                {
                    result = "רשימת סוגי אירוע ריקה";

                    return false;
                }

                ItemsList.Remove(ItemsList.Where(criminalEventType => criminalEventType.Id == streetId).First());

                return true;
            }
            catch (Exception e)
            {
                result = e.Message;

                return false;
            }
        }

        public List<CriminalEventType1> GetItemsList()
        {
            return ItemsList;
        }
    }

    #endregion

    #region Criminal Events

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

    #endregion
}
