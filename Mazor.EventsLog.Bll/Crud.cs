﻿using General.Database.Common;
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
        //  Input:          none
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
        //  Input:          none
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

        public bool Create(CriminalEvent criminalEvent, out string result)
        {
            result = string.Empty;

            try
            {
                if (criminalEvent == null)
                {
                    result = "New Record Is Null";

                    return false;
                }

                criminalEvent.Id = Guid.NewGuid();

                eventsLogDatabase.CriminalEventsRecordsList.Add(criminalEvent);

                return true;
            }
            catch (Exception e)
            {
                result = e.Message;

                return false;
            }
        }

        public bool Retrieve(Guid recordIndex, out CriminalEvent criminalEvent, out string result)
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

        public bool Delete(Guid recordIndex, out string result)
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
