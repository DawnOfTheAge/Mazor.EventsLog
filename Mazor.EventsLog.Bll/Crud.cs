﻿using Mazor.EventsLog.Common;
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

        private List<CriminalEvent> criminalEvents;

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
                    criminalEvents = new List<CriminalEvent>();
                }
                else
                {
                    if (!Utils.LoadFromJson(JsonFilePath, out criminalEvents, out result))
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

        public bool SaveCriminalEvents(out string result)
        {
            result = string.Empty;

            try
            {
                if (!Utils.SaveToJson(JsonFilePath, criminalEvents, out result))
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

                if (criminalEvents == null)
                {
                    criminalEvents = new List<CriminalEvent>();
                }

                criminalEvent.Id = Guid.NewGuid();

                criminalEvents.Add(criminalEvent);

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
                int index = criminalEvents.FindIndex(x => (x.Id == recordIndex));
                if (index == Constants.NONE)
                {
                    result = string.Format("Record With Index[{0}] Not Found", index);
                    
                    return false;
                }

                criminalEvent = criminalEvents[index];

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
                if (criminalEvents == null)
                {
                    result = "No Records Found";

                    return false;
                }

                if (((parameters == null) || (parameters.Count == 0)) && (queryType != QueryType.All))
                {
                    result = "Parameters List Is Null Or Empty";

                    return false;
                }

                switch (queryType)
                {
                    case QueryType.All:
                        criminalEventsList = criminalEvents;
                        break;

                    case QueryType.ByTime:
                        #region By Time

                        criminalEventsList = new List<CriminalEvent>();

                        if (parameters.Count == 1)
                        {
                            DateTime dtTime = (DateTime)parameters[0];

                            criminalEventsList = new List<CriminalEvent>();
                            foreach (CriminalEvent criminalEvent in criminalEvents)
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

                            foreach (CriminalEvent criminalEvent in criminalEvents)
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
                            
                            foreach (CriminalEvent criminalEvent in criminalEvents)
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

                            foreach (CriminalEvent criminalEvent in criminalEvents)
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

                            foreach (CriminalEvent criminalEvent in criminalEvents)
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

                            foreach (CriminalEvent criminalEvent in criminalEvents)
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

                            foreach (CriminalEvent criminalEvent in criminalEvents)
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

                            foreach (CriminalEvent criminalEvent in criminalEvents)
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
                int index = criminalEvents.FindIndex(x => (x.Id == criminalEvent.Id));
                if (index == Constants.NONE)
                {
                    result = string.Format("Record With Index[{0}] Not Found", index);
                    
                    return false;
                }

                criminalEvents[index] = criminalEvent;

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
                int index = criminalEvents.FindIndex(x => (x.Id == recordIndex));
                if (index == Constants.NONE)
                {
                    result = string.Format("Record With Index[{0}] Not Found", index);

                    return false;
                }

                criminalEvents.RemoveAt(index);

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
