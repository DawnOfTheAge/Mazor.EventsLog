using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace General.Database.Common
{
    public static class Utils
    {
        #region Strings / Sub Strings

        public static string InsertNewLineByIndex(string sOrigin, int iIndex)
        {
            return ReplaceSubStringByIndex(sOrigin, iIndex, "<NEWLINE>");
        }

        public static string ReplaceSubStringByIndex(string sOrigin, int iIndex, string sNewSubString)
        {
            #region Data Members

            string sPreString;
            string sPostString;

            #endregion

            try
            {
                if (iIndex >= sOrigin.Length)
                {
                    return "";
                }

                if (sNewSubString == "<NEWLINE>")
                {
                    sNewSubString = System.Environment.NewLine;
                }

                sPreString = sOrigin.Substring(0, iIndex);
                sPostString = sOrigin.Substring(iIndex + 1, sOrigin.Length - iIndex - 1);

                return sPreString + sNewSubString + sPostString;
            }
            catch (Exception)
            {
                return "";
            }
        }

        public static int GetNumberOfOccurences(string sWord, string sSubWord)
        {
            #region Data Members

            int count = 0;
            int i;

            #endregion

            for (i = 0; i < sWord.Length; i++)
            {
                if (sWord.Substring(i, 1) == sSubWord)
                {
                    count += 1;
                }
            }

            return count;
        }

        public static string GetNthSubString(string the_string, string sDelimiter, int index)
        {
            string[] sub_string;

            try
            {
                sub_string = the_string.Split(sDelimiter.ToCharArray());

                if (sub_string == null)
                {
                    return "";
                }

                if (index > sub_string.Length)
                {
                    return "";
                }

                return sub_string[index - 1];
            }
            catch (Exception e)
            {
                string s;

                s = e.Message;

                return "";
            }
        }

        public static int GetLastOccurencePosition(string s, string c)
        {
            #region Data Members

            int i;
            int iLength;
            int iGetLastOccurencePosition;

            #endregion

            iGetLastOccurencePosition = 0;
            iLength = s.Length;

            for (i = 0; i < iLength; i++)
            {
                if (s.Substring(i, 1) == c)
                {
                    iGetLastOccurencePosition = i;
                }
            }

            return iGetLastOccurencePosition;
        }

        public static int GetNthOccurencePosition(string s, string c, int index)
        {
            #region Data Members

            int i;
            int iLength;
            int iOccurenceCounter = 0;
            int iOccurencePosition = -1;

            #endregion

            iLength = s.Length;

            for (i = 0; i < iLength; i++)
            {
                if (s.Substring(i, 1) == c)
                {
                    iOccurenceCounter += 1;
                    iOccurencePosition = i;

                    if (iOccurenceCounter == index)
                    {
                        return iOccurencePosition;
                    }
                }
            }

            return -1;
        }

        public static string GetNthItem(string s, int number, string sDelimiter)
        {
            #region Data Members

            int i;
            int length;
            int front;
            int rear;
            int count;
            int iNumberOfOccurences;
            int iLastOccurencePosition;

            string sGetNthItem;
            string current_char;

            #endregion

            sGetNthItem = "";

            iNumberOfOccurences = GetNumberOfOccurences(s, sDelimiter);
            iLastOccurencePosition = GetLastOccurencePosition(s, sDelimiter);

            if (number == iNumberOfOccurences + 1)
            {
                sGetNthItem = s.Substring(iLastOccurencePosition, s.Length - iLastOccurencePosition);

                return sGetNthItem;
            }

            count = 0;
            length = s.Length;
            front = 0;
            rear = 0;

            try
            {
                for (i = 0; i < length; i++)
                {
                    current_char = s.Substring(i, 1);
                    if (current_char == sDelimiter)
                    {
                        rear = front;
                        front = i;
                        count = count + 1;
                        if (count == number)
                        {
                            sGetNthItem = s.Substring(rear + 1, front - rear - 1);
                            return sGetNthItem;
                        }
                    }
                }

                return sGetNthItem;
            }
            catch (Exception e)
            {
                string sError = e.Message;

                sGetNthItem = "";
                return sGetNthItem;
            }
        }

        public static bool GetAllSubStrings(string the_string, string sDelimiter, out string[] sSubString, out string sError)
        {
            sError = "";
            sSubString = null;

            try
            {
                sSubString = the_string.Split(sDelimiter.ToCharArray(), System.StringSplitOptions.RemoveEmptyEntries);

                if (sSubString == null)
                {
                    sError = "No Sub Strings For String[" + the_string + "] And Delimiter[" + sDelimiter + "]";

                    return false;
                }

                return true;
            }
            catch (Exception e)
            {
                sError = e.Message;

                return false;
            }
        }

        public static string [] GetAllSubStrings(string the_string, string sDelimiter)
        {
            try
            {
                return the_string.Split(sDelimiter.ToCharArray());
            }
            catch (Exception)
            {
                return null;
            }
        }

        #endregion

        public static string VerifyPath(string path)
        {
            if (path[path.Length - 1] != '\\')
            {
                path += "\\";
            }

            return path;
        }

        public static int GetLineNumber(Exception ex)
        {
            try
            {
                var st = new StackTrace(ex, true);

                // Get the top stack frame
                var frame = st.GetFrame(0);

                // Get the line number from the stack frame
                return frame.GetFileLineNumber();
            }
            catch (Exception)
            {
                return -1;
            }
        }

        #region CSV file read / write

        public static bool ReadFromCsvFile(string filename, out List<List<string>> rows, out string result)
        {

            result = string.Empty;
            rows = null;

            try
            {
                if (!File.Exists(filename))
                {
                    result = "File [" + filename + "] Does Not exist";

                    return false;
                }                

                rows = new List<List<string>>();

                string [] lines =  File.ReadAllLines(filename);

                foreach (string line in lines)
                {
                    string[] currentLine = line.Split(',');

                    List<string> row = new List<string>();

                    foreach (string word in currentLine)
                    {
                        row.Add(word);
                    }

                    rows.Add(row);
                }

                return true;
            }
            catch (Exception e)
            {
                result = e.Message;

                return false;
            }
        }

        public static bool WriteToCsvFile(string filename, List<List<string>> rows, out string result)
        {
            StreamWriter csvFile;

            result = string.Empty;

            try
            {
                csvFile = new StreamWriter(filename);

                if ((rows == null) || (rows.Count == 0))
                {
                    result = "No Lines To Add To File";

                    return false;
                }

                foreach (List<string> row in rows)
                {
                    string line = string.Empty;

                    foreach (string word in row)
                    {
                        line += word + ",";
                    }

                    line = line.Substring(0, line.Length - 1);

                    csvFile.WriteLine(line);
                    csvFile.Flush();
                }

                csvFile.Close();

                return true;
            }
            catch (Exception e)
            {
                result = e.Message;

                return false;
            }
        }

        #endregion

        public static bool WriteToFile(string filename, List<string> rows, out string result)
        {
            StreamWriter file;

            result = string.Empty;

            try
            {
                file = new StreamWriter(filename);

                if ((rows == null) || (rows.Count == 0))
                {
                    result = "No Lines To Add To File";

                    return false;
                }

                foreach (string row in rows)
                {
                    file.WriteLine(row);
                    file.Flush();
                }

                file.Close();

                return true;
            }
            catch (Exception e)
            {
                result = e.Message;

                return false;
            }
        }

        #region JSON Read & Write

        public static bool Object2Json(string filename, object oObject, out string result)
        {
            result = string.Empty;

            try
            {
                string json = JsonConvert.SerializeObject(oObject);

                File.WriteAllText(filename, json);

                return true;
            }
            catch (Exception e)
            {
                result = e.Message;

                return false;
            }
        }

        public static bool Json2Object<T>(string filename, out T oObject, out string result)
        {
            result = string.Empty;

            oObject = default;

            try
            {
                if (!File.Exists(filename))
                {
                    result = $"'{filename}' Does Not Exist";

                    return false;
                }

                string json = File.ReadAllText(filename);

                if (string.IsNullOrEmpty(json))
                {
                    result = $"'{filename}' Does Not Contain JSON Contence";

                    return false;
                }

                oObject = JsonConvert.DeserializeObject<T>(json);

                return true;
            }
            catch (Exception e)
            {
                result = e.Message;

                return false;
            }
        }

        #endregion
    }
}
