using Mazor.EventsLog.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mazor.EventsLog.Bll
{
    public class Crud
    {
        #region Data Members

        private EventsLogDatabase eventsLogDatabase;

        private string JsonFilePath;

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
            result = string.Empty;

            try
            {
                if (!File.Exists(JsonFilePath))
                {
                    eventsLogDatabase = new EventsLogDatabase();
                }
                else
                {
                    if (!Utils.LoadFromJson(JsonFilePath, out eventsLogDatabase, out result))
                    {
                        return false;
                    }
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
                if (!Utils.SaveToJson(JsonFilePath, eventsLogDatabase, out result))
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
                if (index == Constants.NONE)
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
                if (((parameters == null) || (parameters.Count == 0)) && (queryType != QueryType.All))
                {
                    result = "Parameters List Is Null Or Empty";

                    return false;
                }

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
                if (index == Constants.NONE)
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
                if (index == Constants.NONE)
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
    }
}
