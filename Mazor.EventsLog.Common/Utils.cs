using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Mazor.EventsLog.Common
{
    public static class Utils
    {
        #region JSON Stuff

        public static bool SaveToJson<T>(string path, T objectToJson, out string result)
        {
            result = string.Empty;

            try
            {
                if (objectToJson == null)
                {
                    result = "Object Is Null";

                    return false;
                }

                string json = JsonConvert.SerializeObject(objectToJson);

                File.WriteAllText(path, json);

                return true;
            }
            catch (Exception e)
            {
                result = e.Message;

                return false;
            }
        }

        public static bool LoadFromJson<T>(string jsonFilePath, out T objectFormJson, out string result)
        {
            result = string.Empty;

            objectFormJson = default(T);

            try
            {
                if (!File.Exists(jsonFilePath))
                {
                    result = string.Format("JSON File '{0}' Does Not Exist", jsonFilePath);

                    return false;
                }

                string json = File.ReadAllText(jsonFilePath);
                objectFormJson = JsonConvert.DeserializeObject<T>(json);

                return true;
            }
            catch (Exception e)
            {
                result = e.Message;

                return false;
            }
        }

        #endregion

        public static string HebrewDayOfTheWeek(DayOfWeek dayOfWeek)
        {
            string hebrewDayOfTheWeek;

            switch (dayOfWeek)
            {
                case DayOfWeek.Sunday:
                    hebrewDayOfTheWeek = "ראשון";
                    break;

                case DayOfWeek.Monday:
                    hebrewDayOfTheWeek = "שני";
                    break;

                case DayOfWeek.Tuesday:
                    hebrewDayOfTheWeek = "שלישי";
                    break;

                case DayOfWeek.Wednesday:
                    hebrewDayOfTheWeek = "רביעי";
                    break;

                case DayOfWeek.Thursday:
                    hebrewDayOfTheWeek = "חמישי";
                    break;

                case DayOfWeek.Friday:
                    hebrewDayOfTheWeek = "שישי";
                    break;

                case DayOfWeek.Saturday:
                    hebrewDayOfTheWeek = "שבת";
                    break;

                default:
                    hebrewDayOfTheWeek = "יום שגוי";
                    break;
            }

            return hebrewDayOfTheWeek;
        }

        public static CriminalEventType CriminalEventTypeTextToType(string criminalEventTypeString)
        {
            CriminalEventType criminalEventType;

            switch (criminalEventTypeString)
            {
                case "פריצה":
                    criminalEventType = CriminalEventType.CarTheft;
                    break;

                default:
                    criminalEventType = CriminalEventType.Unknown;
                    break;
            }

            return criminalEventType;
        }

        public static string CriminalEventTypeTypeToText(CriminalEventType criminalEventType)
        {
            return GetEnumDescription(criminalEventType);
        }

        public static string GetEnumDescription(Enum enumValue)
        {
            try
            {
                FieldInfo fi = enumValue.GetType().GetField(enumValue.ToString());

                DescriptionAttribute[] attributes = (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);

                if ((attributes != null) && (attributes.Length > 0))
                {
                    return attributes[0].Description;
                }
                else
                {
                    return enumValue.ToString();
                }
            }
            catch (Exception e)
            {
                return string.Format("Error[{0}]", e.Message);
            }
        }

        public static string Strech(string s)
        {
            if (s.Length == 1)
            {
                return $"0{s}";
            }
            else
            {
                return s;
            }
        }

        public static List<CriminalEvent> Intersect(List<CriminalEvent> mainList, List<CriminalEvent> intersectedlist, out string result)
        {
            result = string.Empty;

            try
            {
                if ((mainList == null) || (mainList.Count == 0))
                {
                    return intersectedlist;
                }

                if ((intersectedlist == null) || (intersectedlist.Count == 0))
                {
                    return mainList;
                }

                var ids = mainList.Select(x => x.Id).Intersect(intersectedlist.Select(x => x.Id));
                List<CriminalEvent> resultList = mainList.Where(x => ids.Contains(x.Id)).ToList();

                return resultList;
            }
            catch (Exception e)
            {
                result = e.Message;

                return null;
            }
        }

        public static bool IsReachable(string ipAddress, out string result)
        {
            result = string.Empty;

            try
            {
                PingReply pingReply;
                Ping ping = new Ping();

                pingReply = ping.Send(ipAddress);

                if (pingReply.Status == IPStatus.Success) 
                {
                    return true;
                }

                result = pingReply.Status.ToString();

                return false;
            }
            catch (Exception e)
            {
                result = e.Message;

                return false;
            }
        }

        public static bool GetMacAddress(out string macAddress, out string result)
        {
            long maxSpeed = Constants.NONE;

            int MIN_MAC_ADDR_LENGTH = 12;

            result = string.Empty;
            macAddress = string.Empty;

            try
            {
                NetworkInterface[] networkInterfaces = NetworkInterface.GetAllNetworkInterfaces();

                foreach (NetworkInterface nic in networkInterfaces)
                {
                    string tempMac = nic.GetPhysicalAddress().ToString();
                    if (nic.Speed > maxSpeed && !string.IsNullOrEmpty(tempMac) && tempMac.Length >= MIN_MAC_ADDR_LENGTH)
                    {
                        maxSpeed = nic.Speed;
                        macAddress = tempMac;
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
    }
}
