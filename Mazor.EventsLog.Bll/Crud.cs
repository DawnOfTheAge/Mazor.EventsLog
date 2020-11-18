using General.Database.Common;
using General.Database.SqlServer;
using Mazor.EventsLog.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Mazor.EventsLog.Bll
{
    public class Crud
    {
        #region Data Members

        private EventsLogDatabase eventsLogDatabase;

        private string JsonFilePath;

        private IRepositoryDatabase _repositoryDatabase;

        #endregion

        #region Constructor

        public Crud(string jsonFilePath)
        {
            JsonFilePath = jsonFilePath;
        }

        #endregion

        #region Start / End

        public bool Start(out string result)
        {
            OpenDatabaseParameters openDatabaseParameters;

            result = string.Empty;

            try
            {
                if (LoadConfiguration(out openDatabaseParameters, out result))
                {
                    _repositoryDatabase = new SqlServerDal();
                    _repositoryDatabase.RepositoryDatabaseMessage += _repositoryDatabase_RepositoryDatabaseMessage;

                    if (!OpenDatabase(openDatabaseParameters, out result))
                    {
                        result = $"Failed Openning Database: {result}";

                        return false;
                    }
                }
                else
                {
                    result = $"Configuration Loading Failed. Database Not Opened. {result}";

                    return false;
                }

                Street street = new Street("yosef");
                if (!CreateStreetsTableRecord(street, out result))
                {
                    return false;
                }

                return true;
            }
            catch (Exception e)
            {
                result = e.Message;

                return false;
            }
        }

        public bool SaveDatabase(out string result)
        {
            result = string.Empty;

            try
            {
                if (!Mazor.EventsLog.Common.Utils.SaveToJson(JsonFilePath, eventsLogDatabase, out result))
                {
                    return false;
                }

                return true;
            }
            catch (Exception e)
            {
                result = e.Message;

                return false;
            }
        }

        //  Purpose:        Load configuration
        //  Input:          (out) open database parameters
        //                  (out) result
        //  Output:         true / false
        private bool LoadConfiguration(out OpenDatabaseParameters openDatabaseParameters, out string result)
        {
            string method = "[" + MethodBase.GetCurrentMethod().Name + "]: ";
            string message;
            string filename;

            openDatabaseParameters = null;
            result = string.Empty;

            try
            {
                filename = $"{General.Database.Common.Utils.VerifyPath(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location))}{Mazor.EventsLog.Common.Constants.DATABASE_PARAMETERS_FILE}.JSON";

                if (File.Exists(filename))
                {
                    if (!Mazor.EventsLog.Common.Utils.LoadFromJson<OpenDatabaseParameters>(filename, out openDatabaseParameters, out result))
                    {
                        result = $"Load JSON File Error: {result}";

                        return false;
                    }                    
                }
                else
                {
                    result = $"'{filename}' Does Not Exist";

                    return false;
                }

                if (openDatabaseParameters == null)
                {
                    result = "Open Database Parameters Object Is Null";

                    return false;
                }

                if (openDatabaseParameters.DatabaseTableFieldsCsvPath == ".")
                {
                    openDatabaseParameters.DatabaseTableFieldsCsvPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
                }

                return true;
            }
            catch (Exception e)
            {
                message = e.Message + ". Line " + General.Database.Common.Utils.GetLineNumber(e);

                Audit(method + message);

                return false;
            }
        }

        //  Purpose:        open database
        //  Input:          open database parameters
        //                  (out) result
        //  Output:         true / false
        private bool OpenDatabase(OpenDatabaseParameters openDatabaseParameters, out string result)
        {
            result = string.Empty;

            try
            {
                if (_repositoryDatabase == null)
                {
                    result = "Database Repository Object Is Null";

                    return false;
                }

                if (!_repositoryDatabase.OpenDb(openDatabaseParameters, out result))
                {
                    return false;
                }

                return true;
            }
            catch (Exception e)
            {
                result = e.Message;

                return false;
            }
        }

        #endregion

        #region Streets

        public bool Create(CriminalEvent criminalEvent, out string result)
        {
            result = string.Empty;

            try
            {
                if (_repositoryDatabase == null)
                {
                    result = "Database Object Is Null";

                    return false;
                }

                if (!_repositoryDatabase.IsConnected(out result))
                {
                    result = $"Database Is Not COnnected. {result}";

                    return false;
                }

                if (criminalEvent == null)
                {
                    result = "New Record Is Null";

                    return false;
                }

                //criminalEvent.Id = Guid.NewGuid();

                eventsLogDatabase.CriminalEventsRecordsList.Add(criminalEvent);

                return true;
            }
            catch (Exception e)
            {
                result = e.Message;

                return false;
            }
        }

        public bool Retrieve(int recordIndex, out CriminalEvent criminalEvent, out string result)
        {
            result = string.Empty;

            criminalEvent = null;

            try
            {
                int index = eventsLogDatabase.CriminalEventsRecordsList.FindIndex(x => (x.Id == recordIndex));
                if (index == Mazor.EventsLog.Common.Constants.NONE)
                {
                    result = string.Format("Record With Index[{0}] Not Found", index);
                    
                    return false;
                }

                criminalEvent = eventsLogDatabase.CriminalEventsRecordsList[index];

                return true;
            }
            catch (Exception e)
            {
                result = e.Message;

                return false;
            }
        }

        public bool Retrieve(QueryType queryType, 
                             List<object> parameters, 
                             out List<CriminalEvent> criminalEventsList, 
                             out string result)
        {
            result = string.Empty;

            criminalEventsList = null;

            try
            {                
                if ((parameters == null) || (parameters.Count == 0))
                {
                    result = "Parameters List Is Null Or Empty";

                    return false;
                }

                //if (((parameters == null) || (parameters.Count == 0)) && (queryType != QueryType.All))
                //{
                //    result = "Parameters List Is Null Or Empty";

                //    return false;
                //}

                switch (queryType)
                {
                    case QueryType.All:
                        criminalEventsList = eventsLogDatabase.CriminalEventsRecordsList;
                        break;

                    case QueryType.ByTime:
                        #region By Time

                        criminalEventsList = new List<CriminalEvent>();

                        if (parameters.Count == 1)
                        {
                            DateTime dtTime = (DateTime)parameters[0];

                            criminalEventsList = new List<CriminalEvent>();
                            foreach (CriminalEvent criminalEvent in eventsLogDatabase.CriminalEventsRecordsList)
                            {
                                if ((criminalEvent.Time.Hour == dtTime.Hour) && 
                                    (criminalEvent.Time.Minute == dtTime.Minute))
                                {
                                    criminalEventsList.Add(criminalEvent);
                                }
                            }

                            return true;
                        }

                        if (parameters.Count == 2)
                        { 
                            DateTime dtTimeFrom = (DateTime)parameters[0];
                            DateTime dtTimeTo = (DateTime)parameters[1];

                            foreach (CriminalEvent criminalEvent in eventsLogDatabase.CriminalEventsRecordsList)
                            {
                                if ((criminalEvent.Time.TimeOfDay >= dtTimeFrom.TimeOfDay) &&
                                    (criminalEvent.Time.TimeOfDay <= dtTimeTo.TimeOfDay))
                                {
                                    criminalEventsList.Add(criminalEvent);
                                }
                            }
                        }

                        #endregion
                        break;

                    case QueryType.ByDate:
                        #region By Date

                        criminalEventsList = new List<CriminalEvent>();

                        if (parameters.Count == 1)
                        {
                            DateTime dtDate = (DateTime)parameters[0];
                            
                            foreach (CriminalEvent criminalEvent in eventsLogDatabase.CriminalEventsRecordsList)
                            {
                                if ((criminalEvent.Time.Year == dtDate.Year) &&
                                    (criminalEvent.Time.Month == dtDate.Month) &&
                                    (criminalEvent.Time.Day == dtDate.Day))
                                {
                                    criminalEventsList.Add(criminalEvent);
                                }
                            }

                            return true;
                        }

                        if (parameters.Count == 2)
                        {
                            DateTime dtDateFrom = (DateTime)parameters[0];
                            DateTime dtDateTo = (DateTime)parameters[1];

                            foreach (CriminalEvent criminalEvent in eventsLogDatabase.CriminalEventsRecordsList)
                            {
                                if ((criminalEvent.Time >= dtDateFrom) &&
                                    (criminalEvent.Time <= dtDateTo))
                                {
                                    criminalEventsList.Add(criminalEvent);
                                }
                            }

                            return true;
                        }

                        #endregion
                        break;

                    case QueryType.ByDay:
                        #region By Day

                        criminalEventsList = new List<CriminalEvent>();

                        if (parameters.Count == 1)
                        {
                            List<DayOfWeek> days = (List<DayOfWeek>)parameters[0];

                            foreach (CriminalEvent criminalEvent in eventsLogDatabase.CriminalEventsRecordsList)
                            {
                                foreach (DayOfWeek day in days)
                                {
                                    if (criminalEvent.Time.DayOfWeek == day)
                                    {
                                        criminalEventsList.Add(criminalEvent);
                                    }
                                }
                            }

                            return true;
                        }

                        #endregion
                        break;

                    case QueryType.ByAddress:
                        #region By Address

                        criminalEventsList = new List<CriminalEvent>();

                        if (parameters.Count == 1)
                        {
                            List<string> keyWords = (List<string>)parameters[0];

                            foreach (CriminalEvent criminalEvent in eventsLogDatabase.CriminalEventsRecordsList)
                            {
                                foreach (string keyWord in keyWords)
                                {
                                    if (!string.IsNullOrEmpty(criminalEvent.Street))
                                    {
                                        if (keyWord.Contains(criminalEvent.Street) || keyWord.Contains(criminalEvent.HouseNumber.ToString()))
                                        {
                                            criminalEventsList.Add(criminalEvent);
                                        }
                                    }
                                }
                            }

                            return true;
                        }

                        #endregion
                        break;

                    case QueryType.ByFamily:
                        #region By Family

                        criminalEventsList = new List<CriminalEvent>();

                        if (parameters.Count == 1)
                        {
                            List<string> keyWords = (List<string>)parameters[0];

                            foreach (CriminalEvent criminalEvent in eventsLogDatabase.CriminalEventsRecordsList)
                            {
                                foreach (string keyWord in keyWords)
                                {
                                    if (criminalEvent.Family.Trim() == keyWord.Trim())
                                    {
                                        criminalEventsList.Add(criminalEvent);
                                    }
                                }
                            }

                            return true;
                        }

                        #endregion
                        break;

                    case QueryType.ByEvent:
                        #region By Event

                        criminalEventsList = new List<CriminalEvent>();

                        if (parameters.Count == 1)
                        {
                            List<CriminalEventType> criminalEventTypes = (List<CriminalEventType>)parameters[0];

                            foreach (CriminalEvent criminalEvent in eventsLogDatabase.CriminalEventsRecordsList)
                            {
                                foreach (CriminalEventType criminalEventType in criminalEventTypes)
                                {
                                    if (criminalEvent.Type == criminalEventType)
                                    {
                                        criminalEventsList.Add(criminalEvent);
                                    }
                                }
                            }

                            return true;
                        }

                        #endregion
                        break;

                    default:
                        break;
                }
                
                return true;
            }
            catch (Exception e)
            {
                result = e.Message;

                return false;
            }
        }

        public bool Update(CriminalEvent criminalEvent, out string result)
        {
            result = string.Empty;

            try
            {
                int index = eventsLogDatabase.CriminalEventsRecordsList.FindIndex(x => (x.Id == criminalEvent.Id));
                if (index == Mazor.EventsLog.Common.Constants.NONE)
                {
                    result = string.Format("Record With Index[{0}] Not Found", index);
                    
                    return false;
                }

                eventsLogDatabase.CriminalEventsRecordsList[index] = criminalEvent;

                return true;
            }
            catch (Exception e)
            {
                result = e.Message;

                return false;
            }
        }

        public bool Delete(int recordIndex, out string result)
        {
            result = string.Empty;

            try
            {
                int index = eventsLogDatabase.CriminalEventsRecordsList.FindIndex(x => (x.Id == recordIndex));
                if (index == Mazor.EventsLog.Common.Constants.NONE)
                {
                    result = string.Format("Record With Index[{0}] Not Found", index);

                    return false;
                }

                eventsLogDatabase.CriminalEventsRecordsList.RemoveAt(index);

                return true;
            }
            catch (Exception e)
            {
                result = e.Message;

                return false;
            }
        }

        #endregion

        #region Create

        public bool CreateStreetsTableRecord(Street street, out string result)
        {
            result = string.Empty;

            try
            {
                if (_repositoryDatabase == null)
                {
                    result = "Database Object Is Null";

                    return false;
                }

                if (!_repositoryDatabase.IsConnected(out result))
                {
                    result = $"Database Is Not Connected. {result}";

                    return false;
                }

                if (street == null)
                {
                    result = "New Record Is Null";

                    return false;
                }

                string sql = $"INSERT INTO dbo.Streets (Name) VALUES ('{street.Name}')";
                if (!_repositoryDatabase.NonQuery(sql, out result))
                {
                    result = $"Faild Sql[{sql}]. {result}";

                    return false;
                }

                return true;
            }
            catch (Exception e)
            {
                result = e.Message;

                return false;
            }
        }

        public bool CreateCriminalEventTypesTableRecord(CriminalEventType1 criminalEventType, out string result)
        {
            result = string.Empty;

            try
            {
                if (_repositoryDatabase == null)
                {
                    result = "Database Object Is Null";

                    return false;
                }

                if (!_repositoryDatabase.IsConnected(out result))
                {
                    result = $"Database Is Not Connected. {result}";

                    return false;
                }

                if (criminalEventType == null)
                {
                    result = "New Record Is Null";

                    return false;
                }

                string sql = $"INSERT INTO dbo.CriminalEventTypes (Name) VALUES ('{criminalEventType.Name}')";
                if (!_repositoryDatabase.NonQuery(sql, out result))
                {
                    result = $"Faild Sql[{sql}]. {result}";

                    return false;
                }

                return true;
            }
            catch (Exception e)
            {
                result = e.Message;

                return false;
            }
        }

        public bool CreateArrivalDirectionsTableRecord(ArrivalDirection arrivalDirection, out string result)
        {
            result = string.Empty;

            try
            {
                if (_repositoryDatabase == null)
                {
                    result = "Database Object Is Null";

                    return false;
                }

                if (!_repositoryDatabase.IsConnected(out result))
                {
                    result = $"Database Is Not Connected. {result}";

                    return false;
                }

                if (arrivalDirection == null)
                {
                    result = "New Record Is Null";

                    return false;
                }

                string sql = $"INSERT INTO dbo.ArrivalDirections (Name) VALUES ('{arrivalDirection.Name}')";
                if (!_repositoryDatabase.NonQuery(sql, out result))
                {
                    result = $"Faild Sql[{sql}]. {result}";

                    return false;
                }

                return true;
            }
            catch (Exception e)
            {
                result = e.Message;

                return false;
            }
        }

        public bool CreateDamagesTableRecord(Damage damage, out string result)
        {
            result = string.Empty;

            try
            {
                if (_repositoryDatabase == null)
                {
                    result = "Database Object Is Null";

                    return false;
                }

                if (!_repositoryDatabase.IsConnected(out result))
                {
                    result = $"Database Is Not Connected. {result}";

                    return false;
                }

                if (damage == null)
                {
                    result = "New Record Is Null";

                    return false;
                }

                string sql = $"INSERT INTO dbo.Damages (Name) VALUES ('{damage.Name}')";
                if (!_repositoryDatabase.NonQuery(sql, out result))
                {
                    result = $"Faild Sql[{sql}]. {result}";

                    return false;
                }

                return true;
            }
            catch (Exception e)
            {
                result = e.Message;

                return false;
            }
        }

        public bool CreateLocationsTableRecord(LocationPoint location, out string result)
        {
            result = string.Empty;

            try
            {
                if (_repositoryDatabase == null)
                {
                    result = "Database Object Is Null";

                    return false;
                }

                if (!_repositoryDatabase.IsConnected(out result))
                {
                    result = $"Database Is Not Connected. {result}";

                    return false;
                }

                if (location == null)
                {
                    result = "New Record Is Null";

                    return false;
                }

                string sql = $"INSERT INTO dbo.Locations (Latitude, Longitude) VALUES ('{location.Latitude}', '{location.Longitude}')";
                if (!_repositoryDatabase.NonQuery(sql, out result))
                {
                    result = $"Faild Sql[{sql}]. {result}";

                    return false;
                }

                return true;
            }
            catch (Exception e)
            {
                result = e.Message;

                return false;
            }
        }

        public bool CreateSpecialLocationsTableRecord(SpecialLocation location, out string result)
        {
            result = string.Empty;

            try
            {
                if (_repositoryDatabase == null)
                {
                    result = "Database Object Is Null";

                    return false;
                }

                if (!_repositoryDatabase.IsConnected(out result))
                {
                    result = $"Database Is Not Connected. {result}";

                    return false;
                }

                if (location == null)
                {
                    result = "New Record Is Null";

                    return false;
                }

                string sql = $"INSERT INTO dbo.SpecialLocations (Name, LocationId) VALUES ('{location.Name}', '{location.LocationId}')";
                if (!_repositoryDatabase.NonQuery(sql, out result))
                {
                    result = $"Faild Sql[{sql}]. {result}";

                    return false;
                }

                return true;
            }
            catch (Exception e)
            {
                result = e.Message;

                return false;
            }
        }

        public bool CreateCamerasLocationsTableRecord(CameraLocation location, out string result)
        {
            result = string.Empty;

            try
            {
                if (_repositoryDatabase == null)
                {
                    result = "Database Object Is Null";

                    return false;
                }

                if (!_repositoryDatabase.IsConnected(out result))
                {
                    result = $"Database Is Not Connected. {result}";

                    return false;
                }

                if (location == null)
                {
                    result = "New Record Is Null";

                    return false;
                }

                string sql = $"INSERT INTO dbo.CamerasLocations (Name, LocationId) VALUES ('{location.Name}', '{location.LocationId}')";
                if (!_repositoryDatabase.NonQuery(sql, out result))
                {
                    result = $"Faild Sql[{sql}]. {result}";

                    return false;
                }

                return true;
            }
            catch (Exception e)
            {
                result = e.Message;

                return false;
            }
        }

        public bool CreateContactDetailsTableRecord(ContactDetails contactDetails, out string result)
        {
            result = string.Empty;

            try
            {
                if (_repositoryDatabase == null)
                {
                    result = "Database Object Is Null";

                    return false;
                }

                if (!_repositoryDatabase.IsConnected(out result))
                {
                    result = $"Database Is Not Connected. {result}";

                    return false;
                }

                if (contactDetails == null)
                {
                    result = "New Record Is Null";

                    return false;
                }

                string sql = $"INSERT INTO dbo.ContactDetails (ContactPerson, Phone, Email) VALUES ('{contactDetails.ContactPerson}', '{contactDetails.Phone}','{contactDetails.Email}')";
                if (!_repositoryDatabase.NonQuery(sql, out result))
                {
                    result = $"Faild Sql[{sql}]. {result}";

                    return false;
                }

                return true;
            }
            catch (Exception e)
            {
                result = e.Message;

                return false;
            }
        }

        public bool CreateLawEnforcementUnitsTableRecord(LawEnforcementUnit lawEnforcementUnit, out string result)
        {
            result = string.Empty;

            try
            {
                if (_repositoryDatabase == null)
                {
                    result = "Database Object Is Null";

                    return false;
                }

                if (!_repositoryDatabase.IsConnected(out result))
                {
                    result = $"Database Is Not Connected. {result}";

                    return false;
                }

                if (lawEnforcementUnit == null)
                {
                    result = "New Record Is Null";

                    return false;
                }

                string sql = $"INSERT INTO dbo.LawEnforcementUnit (Name, ContactDetailsId) VALUES ('{lawEnforcementUnit.Name}', '{lawEnforcementUnit.ContactDetailsId}')";
                if (!_repositoryDatabase.NonQuery(sql, out result))
                {
                    result = $"Faild Sql[{sql}]. {result}";

                    return false;
                }

                return true;
            }
            catch (Exception e)
            {
                result = e.Message;

                return false;
            }
        }

        public bool CreateTrainingUnitsTableRecord(TrainingUnit trainingUnit, out string result)
        {
            result = string.Empty;

            try
            {
                if (_repositoryDatabase == null)
                {
                    result = "Database Object Is Null";

                    return false;
                }

                if (!_repositoryDatabase.IsConnected(out result))
                {
                    result = $"Database Is Not Connected. {result}";

                    return false;
                }

                if (trainingUnit == null)
                {
                    result = "New Record Is Null";

                    return false;
                }

                string sql = $"INSERT INTO dbo.TrainingUnits (Name, ContactDetailsId, FromDate, ToDate, FromTime, ToTime) VALUES ('{trainingUnit.Name}', '{trainingUnit.ContactDetailsId}', '{trainingUnit.FromDate}', '{trainingUnit.ToDate}', '{trainingUnit.FromTime}', '{trainingUnit.ToTime}')";
                if (!_repositoryDatabase.NonQuery(sql, out result))
                {
                    result = $"Faild Sql[{sql}]. {result}";

                    return false;
                }

                return true;
            }
            catch (Exception e)
            {
                result = e.Message;

                return false;
            }
        }

        #endregion

        //public bool Retrieve(int recordIndex, out CriminalEvent criminalEvent, out string result)


        //public bool Retrieve(int recordIndex, out CriminalEvent criminalEvent, out string result)
        //{
        //    result = string.Empty;

        //    criminalEvent = null;

        //    try
        //    {
        //        int index = eventsLogDatabase.CriminalEventsRecordsList.FindIndex(x => (x.Id == recordIndex));
        //        if (index == Mazor.EventsLog.Common.Constants.NONE)
        //        {
        //            result = string.Format("Record With Index[{0}] Not Found", index);

        //            return false;
        //        }

        //        criminalEvent = eventsLogDatabase.CriminalEventsRecordsList[index];

        //        return true;
        //    }
        //    catch (Exception e)
        //    {
        //        result = e.Message;

        //        return false;
        //    }
        //}

        //public bool Retrieve(QueryType queryType,
        //                     List<object> parameters,
        //                     out List<CriminalEvent> criminalEventsList,
        //                     out string result)
        //{
        //    result = string.Empty;

        //    criminalEventsList = null;

        //    try
        //    {
        //        if ((parameters == null) || (parameters.Count == 0))
        //        {
        //            result = "Parameters List Is Null Or Empty";

        //            return false;
        //        }

        //        //if (((parameters == null) || (parameters.Count == 0)) && (queryType != QueryType.All))
        //        //{
        //        //    result = "Parameters List Is Null Or Empty";

        //        //    return false;
        //        //}

        //        switch (queryType)
        //        {
        //            case QueryType.All:
        //                criminalEventsList = eventsLogDatabase.CriminalEventsRecordsList;
        //                break;

        //            case QueryType.ByTime:
        //                #region By Time

        //                criminalEventsList = new List<CriminalEvent>();

        //                if (parameters.Count == 1)
        //                {
        //                    DateTime dtTime = (DateTime)parameters[0];

        //                    criminalEventsList = new List<CriminalEvent>();
        //                    foreach (CriminalEvent criminalEvent in eventsLogDatabase.CriminalEventsRecordsList)
        //                    {
        //                        if ((criminalEvent.Time.Hour == dtTime.Hour) &&
        //                            (criminalEvent.Time.Minute == dtTime.Minute))
        //                        {
        //                            criminalEventsList.Add(criminalEvent);
        //                        }
        //                    }

        //                    return true;
        //                }

        //                if (parameters.Count == 2)
        //                {
        //                    DateTime dtTimeFrom = (DateTime)parameters[0];
        //                    DateTime dtTimeTo = (DateTime)parameters[1];

        //                    foreach (CriminalEvent criminalEvent in eventsLogDatabase.CriminalEventsRecordsList)
        //                    {
        //                        if ((criminalEvent.Time.TimeOfDay >= dtTimeFrom.TimeOfDay) &&
        //                            (criminalEvent.Time.TimeOfDay <= dtTimeTo.TimeOfDay))
        //                        {
        //                            criminalEventsList.Add(criminalEvent);
        //                        }
        //                    }
        //                }

        //                #endregion
        //                break;

        //            case QueryType.ByDate:
        //                #region By Date

        //                criminalEventsList = new List<CriminalEvent>();

        //                if (parameters.Count == 1)
        //                {
        //                    DateTime dtDate = (DateTime)parameters[0];

        //                    foreach (CriminalEvent criminalEvent in eventsLogDatabase.CriminalEventsRecordsList)
        //                    {
        //                        if ((criminalEvent.Time.Year == dtDate.Year) &&
        //                            (criminalEvent.Time.Month == dtDate.Month) &&
        //                            (criminalEvent.Time.Day == dtDate.Day))
        //                        {
        //                            criminalEventsList.Add(criminalEvent);
        //                        }
        //                    }

        //                    return true;
        //                }

        //                if (parameters.Count == 2)
        //                {
        //                    DateTime dtDateFrom = (DateTime)parameters[0];
        //                    DateTime dtDateTo = (DateTime)parameters[1];

        //                    foreach (CriminalEvent criminalEvent in eventsLogDatabase.CriminalEventsRecordsList)
        //                    {
        //                        if ((criminalEvent.Time >= dtDateFrom) &&
        //                            (criminalEvent.Time <= dtDateTo))
        //                        {
        //                            criminalEventsList.Add(criminalEvent);
        //                        }
        //                    }

        //                    return true;
        //                }

        //                #endregion
        //                break;

        //            case QueryType.ByDay:
        //                #region By Day

        //                criminalEventsList = new List<CriminalEvent>();

        //                if (parameters.Count == 1)
        //                {
        //                    List<DayOfWeek> days = (List<DayOfWeek>)parameters[0];

        //                    foreach (CriminalEvent criminalEvent in eventsLogDatabase.CriminalEventsRecordsList)
        //                    {
        //                        foreach (DayOfWeek day in days)
        //                        {
        //                            if (criminalEvent.Time.DayOfWeek == day)
        //                            {
        //                                criminalEventsList.Add(criminalEvent);
        //                            }
        //                        }
        //                    }

        //                    return true;
        //                }

        //                #endregion
        //                break;

        //            case QueryType.ByAddress:
        //                #region By Address

        //                criminalEventsList = new List<CriminalEvent>();

        //                if (parameters.Count == 1)
        //                {
        //                    List<string> keyWords = (List<string>)parameters[0];

        //                    foreach (CriminalEvent criminalEvent in eventsLogDatabase.CriminalEventsRecordsList)
        //                    {
        //                        foreach (string keyWord in keyWords)
        //                        {
        //                            if (!string.IsNullOrEmpty(criminalEvent.Street))
        //                            {
        //                                if (keyWord.Contains(criminalEvent.Street) || keyWord.Contains(criminalEvent.HouseNumber.ToString()))
        //                                {
        //                                    criminalEventsList.Add(criminalEvent);
        //                                }
        //                            }
        //                        }
        //                    }

        //                    return true;
        //                }

        //                #endregion
        //                break;

        //            case QueryType.ByFamily:
        //                #region By Family

        //                criminalEventsList = new List<CriminalEvent>();

        //                if (parameters.Count == 1)
        //                {
        //                    List<string> keyWords = (List<string>)parameters[0];

        //                    foreach (CriminalEvent criminalEvent in eventsLogDatabase.CriminalEventsRecordsList)
        //                    {
        //                        foreach (string keyWord in keyWords)
        //                        {
        //                            if (criminalEvent.Family.Trim() == keyWord.Trim())
        //                            {
        //                                criminalEventsList.Add(criminalEvent);
        //                            }
        //                        }
        //                    }

        //                    return true;
        //                }

        //                #endregion
        //                break;

        //            case QueryType.ByEvent:
        //                #region By Event

        //                criminalEventsList = new List<CriminalEvent>();

        //                if (parameters.Count == 1)
        //                {
        //                    List<CriminalEventType> criminalEventTypes = (List<CriminalEventType>)parameters[0];

        //                    foreach (CriminalEvent criminalEvent in eventsLogDatabase.CriminalEventsRecordsList)
        //                    {
        //                        foreach (CriminalEventType criminalEventType in criminalEventTypes)
        //                        {
        //                            if (criminalEvent.Type == criminalEventType)
        //                            {
        //                                criminalEventsList.Add(criminalEvent);
        //                            }
        //                        }
        //                    }

        //                    return true;
        //                }

        //                #endregion
        //                break;

        //            default:
        //                break;
        //        }

        //        return true;
        //    }
        //    catch (Exception e)
        //    {
        //        result = e.Message;

        //        return false;
        //    }
        //}

        //public bool Update(CriminalEvent criminalEvent, out string result)
        //{
        //    result = string.Empty;

        //    try
        //    {
        //        int index = eventsLogDatabase.CriminalEventsRecordsList.FindIndex(x => (x.Id == criminalEvent.Id));
        //        if (index == Mazor.EventsLog.Common.Constants.NONE)
        //        {
        //            result = string.Format("Record With Index[{0}] Not Found", index);

        //            return false;
        //        }

        //        eventsLogDatabase.CriminalEventsRecordsList[index] = criminalEvent;

        //        return true;
        //    }
        //    catch (Exception e)
        //    {
        //        result = e.Message;

        //        return false;
        //    }
        //}

        //public bool Delete(int recordIndex, out string result)
        //{
        //    result = string.Empty;

        //    try
        //    {
        //        int index = eventsLogDatabase.CriminalEventsRecordsList.FindIndex(x => (x.Id == recordIndex));
        //        if (index == Mazor.EventsLog.Common.Constants.NONE)
        //        {
        //            result = string.Format("Record With Index[{0}] Not Found", index);

        //            return false;
        //        }

        //        eventsLogDatabase.CriminalEventsRecordsList.RemoveAt(index);

        //        return true;
        //    }
        //    catch (Exception e)
        //    {
        //        result = e.Message;

        //        return false;
        //    }
        //}

        #region Audit

        private void Audit(string message)
        {
            Console.WriteLine(message);
        }

        private void _repositoryDatabase_RepositoryDatabaseMessage(object sender, EventArgs e)
        {
            string message = (string)sender;

            Audit(message);
        }

        private void appConfigManager_AppConfigManagerMessage(object sender, EventArgs e)
        {
            string message = (string)sender;

            Audit(message);
        }

        #endregion
    }
}
