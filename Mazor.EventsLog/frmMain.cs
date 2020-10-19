using Mazor.EventsLog.Bll;
using Mazor.EventsLog.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mazor.EventsLog
{
    public partial class frmMain : Form
    {
        #region Data Members

        private EventsLogDatabase eventsLogDatabase;

        private ConfigurationInformation configurationInformation;

        private LocationServiceInformation locationServiceInformation;

        private MapInitialInformation mapInitialInformation;

        private Crud crud;

        private TextWriter AuditFile;

        private List<CriminalEvent> criminalEventsForMap;

        private string PingTestAddress;

        private string LicsenceFilePath;

        private int PingTestIntervalInSeconds;

        #endregion

        #region Constructor

        public frmMain()
        {
            InitializeComponent();
        }

        #endregion

        #region Stratup

        private void frmMain_Load(object sender, EventArgs e)
        {
            string result;

            try
            {
                Location = Cursor.Position;

                if (!Initialize(out result))
                {
                    Audit($"תקלת איתחול: {result}", AuditSeverity.Critical);
                }
            }
            catch (Exception ex)
            {
                Audit($"תקלת איתחול: {ex.Message}", AuditSeverity.Critical);
            }
        }

        private bool Initialize(out string result)
        {
            result = string.Empty;

            try
            {
                #region Prologue

                if (!Prologue(out result))
                {
                    Audit($"Prologue Error: {result}", AuditSeverity.Critical);

                    return false;
                }

                #endregion

                #region Licsence

                //LicsenceFilePath = $"{Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)}\\Mazor.EventsLog.lic";
                //if (!File.Exists(LicsenceFilePath))
                //{
                //    Audit($"אין רשיון להפעלה", AuditSeverity.Critical);
                //}

                //string macAddressFromFile;
                //string macAddressFromHost;
                //if (!ReadFromLicsenceFile(out macAddressFromFile, out result))
                //{
                //    Audit($"תקלת רשיון להפעלה: {result}", AuditSeverity.Critical);

                //    return false;
                //}

                //if (!Utils.GetMacAddress(out macAddressFromHost, out result))
                //{
                //    Audit($"תקלת רשיון להפעלה: {result}", AuditSeverity.Critical);

                //    return false;
                //}

                //if (macAddressFromFile == Constants.INITIAL_MAC_ADDRESS_VALUE)
                //{
                //    if (!WriteToLicsenceFile(macAddressFromHost, out result))
                //    {
                //        Audit($"תקלת רשיון להפעלה: {result}", AuditSeverity.Critical);

                //        return false;
                //    }

                //    Environment.Exit(0);
                //}

                //if (macAddressFromFile != macAddressFromHost)
                //{
                //    Audit($"אין רשיון להפעלה", AuditSeverity.Critical);

                //    return false;
                //}

                #endregion

                #region Get Configuration

                if (!ReadFromAppConfig(out result))
                {
                    return false;
                }

                #endregion

                #region Audit File

                if (configurationInformation.LogToFile)
                {
                    string fileName = $"{Constants.CITY} {DateTime.Now.ToString("dd-MM-yyyy HH-mm")}.txt";
                                      
                    AuditFile = new StreamWriter(configurationInformation.LogFilePath + "\\" + fileName);
                }

                #endregion

                #region Initialize CRUD Object

                string jsonFile = $"{configurationInformation.JsonFilePath}\\{configurationInformation.JsonFileName}.json";

                crud = new Crud(jsonFile);
                if (!crud.Start(out result))
                {
                    return false;
                }

                #endregion                

                #region Read All Existing Events

                if (!RefreshCriminalEventsGrid(out result))
                {
                    return false;
                }

                #endregion

                #region Initialize Timers

                tmrTestConnection.Interval = PingTestIntervalInSeconds * Constants.SECONDS;
                tmrTestConnection.Enabled = true;

                #endregion

                #region Epilogue

                if (!Epilogue(out result))
                {
                    Audit($"Epilogue Error: {result}", AuditSeverity.Critical);

                    return false;
                }

                #endregion

                return true;
            }
            catch (Exception e)
            {
                result = e.Message;

                return false;
            }
        }

        private bool Prologue(out string result)
        {
            result = string.Empty;

            try
            {
                return true;
            }
            catch (Exception e)
            {
                result = e.Message;
                
                return false;
            }
        }

        private bool Epilogue(out string result)
        {
            result = string.Empty;

            try
            {
                return true;
            }
            catch (Exception e)
            {
                result = e.Message;

                return false;
            }
        }

        #endregion

        #region App Config

        private bool ReadFromAppConfig(out string result)
        {
            result = string.Empty;

            try
            {
                configurationInformation = new ConfigurationInformation();

                configurationInformation.JsonFileName = ConfigurationManager.AppSettings["JsonFileName"];
                if (string.IsNullOrEmpty(configurationInformation.JsonFileName))
                {
                    result = " 'JsonFileName' אינו מוגדר";

                    return false;
                }

                string LogToFileString = ConfigurationManager.AppSettings["LogToFile"];
                if (string.IsNullOrEmpty(LogToFileString))
                {
                    result = " 'LogToFile' אינו מוגדר";

                    return false;
                }

                bool logToFile;
                configurationInformation.LogToFile = bool.TryParse(LogToFileString, out logToFile) ? logToFile : false;

                configurationInformation.LogFilePath = ConfigurationManager.AppSettings["LogFilePath"];
                if (string.IsNullOrEmpty(configurationInformation.LogFilePath))
                {
                    configurationInformation.LogFilePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
                }

                configurationInformation.JsonFilePath = ConfigurationManager.AppSettings["JsonFilePath"];
                if (string.IsNullOrEmpty(configurationInformation.JsonFilePath))
                {
                    configurationInformation.JsonFilePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
                }

                mapInitialInformation = new MapInitialInformation();

                string zoomLevelString = ConfigurationManager.AppSettings["MapInitialZoomLevel"];
                int zoomLevel;
                mapInitialInformation.ZoomLevel = int.TryParse(zoomLevelString, out zoomLevel) ? zoomLevel : Constants.DEFAULT_ZOOM_LEVEL;

                locationServiceInformation = new LocationServiceInformation();
                locationServiceInformation.Country = ConfigurationManager.AppSettings["LocationServiceCountry"];
                locationServiceInformation.City = ConfigurationManager.AppSettings["LocationServiceCity"];
                locationServiceInformation.BingKey = ConfigurationManager.AppSettings["LocationServiceBingKey"];
                locationServiceInformation.LocationServiceUrl = ConfigurationManager.AppSettings["LocationServiceUrl"];

                PingTestAddress = ConfigurationManager.AppSettings["PingTestAddress"];
                string pingTestIntervalInSecondsString = ConfigurationManager.AppSettings["PingTestIntervalInSeconds"];
                PingTestIntervalInSeconds = int.TryParse(pingTestIntervalInSecondsString, out PingTestIntervalInSeconds) ? PingTestIntervalInSeconds : Constants.DEFAULT_PING_INTERVAL_IN_SECONDS;

                return true;
            }
            catch (Exception e)
            {
                result = e.Message;

                return false;
            }
        }

        private bool SaveToAppConfig(ConfigurationInformation inConfigurationInformation, out string result)
        {
            result = string.Empty;

            try
            {
                if (inConfigurationInformation == null)
                {
                    result = "אובייקט הגדרות אינו מוגדר";

                    return false;
                }

                Configuration configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

                configuration.AppSettings.Settings["JsonFilePath"].Value = inConfigurationInformation.JsonFilePath;
                configuration.AppSettings.Settings["JsonFileName"].Value = inConfigurationInformation.JsonFileName;
                configuration.AppSettings.Settings["LogFilePath"].Value = inConfigurationInformation.LogFilePath;

                configuration.AppSettings.Settings["LogToFile"].Value = inConfigurationInformation.LogToFile.ToString();

                configuration.Save();

                ConfigurationManager.RefreshSection("appSettings");

                return true;
            }
            catch (Exception e)
            {
                result = e.Message;

                return false;
            }
        }

        #endregion

        #region Licsence

        private bool ReadFromLicsenceFile(out string line, out string result)
        {
            result = string.Empty;
            line = string.Empty;

            try
            {
                line = File.ReadAllText(LicsenceFilePath);

                return true;
            }
            catch (Exception e)
            {
                result = e.Message;

                return false;
            }
        }

        private bool WriteToLicsenceFile(string line, out string result)
        {
            result = string.Empty;

            try
            {
                File.WriteAllText(LicsenceFilePath, line);

                return true;
            }
            catch (Exception e)
            {
                result = e.Message;

                return false;
            }
        }

        #endregion

        #region CRUD Stuff

        private bool Retrieve(QueryType queryType, List<object> parameters, out List<CriminalEvent> criminalEvents, out string result)
        {
            result = string.Empty;

            criminalEvents = null;

            try
            {
                if (crud == null)
                {
                    result = "אין גישה לנתונים";

                    return false;
                }

                if (!crud.Retrieve(queryType, parameters, out criminalEvents, out result))
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

        private bool Retrieve(CriminalEvent criminalEvent, out string result)
        {
            result = string.Empty;

            try
            {
                if (criminalEvent == null)
                {
                    result = "Record To Create Is Null";

                    return false;
                }

                if (!crud.Create(criminalEvent, out result))
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

        #region GUI

        #region Grid

        private bool RefreshCriminalEventsGrid(out string result)
        {
            result = string.Empty;

            try
            {
                List<CriminalEvent> criminalEvents;
                if (!Retrieve(QueryType.All, null, out criminalEvents, out result))
                {
                    return false;
                }

                if (!FillGrid(criminalEvents, out result))
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

        private bool FillGrid(List<CriminalEvent> criminalEvents, out string result)
        {
            result = string.Empty;

            try
            {
                criminalEventsForMap = criminalEvents;

                dgvEventsLog.Rows.Clear();

                if ((criminalEvents == null) || (criminalEvents.Count == 0))
                {
                    result = "אין רשומות";

                    return false;
                }

                foreach (CriminalEvent criminalEvent in criminalEvents)
                {
                    dgvEventsLog.Rows.Add(criminalEvent.Description,
                                          criminalEvent.WhoArrivedAfterTheEvent,
                                          criminalEvent.ArrivalDirection,
                                          criminalEvent.WhatWasStolen,
                                          string.Format("{1} {0}", criminalEvent.HouseNumber, criminalEvent.Street),
                                          criminalEvent.Family,
                                          criminalEvent.Time.ToString("HH:mm"),
                                          Utils.HebrewDayOfTheWeek(criminalEvent.Time.DayOfWeek),
                                          criminalEvent.Time.Date.ToString("dd/MM/yyyy"),
                                          Utils.CriminalEventTypeTypeToText(criminalEvent.Type),
                                          criminalEvent.Id,
                                          criminalEvent.Time,
                                          criminalEvent.Street,
                                          criminalEvent.HouseNumber,
                                          criminalEvent.Type);
                }

                for (int i = 0; i < dgvEventsLog.Columns.Count; i++)
                {
                    dgvEventsLog.Columns[i].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                    dgvEventsLog.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                }

                dgvEventsLog.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);

                return true;
            }
            catch (Exception e)
            {
                result = e.Message;

                return false;
            }
        }

        #endregion

        #region CRUD

        private void btnAddEvent_Click(object sender, EventArgs e)
        {
            try
            {
                frmAddUpdateCriminalRecord addCriminalRecord = new frmAddUpdateCriminalRecord();
                addCriminalRecord.Save += AddUpdateCriminalRecord_Save;
                addCriminalRecord.Audit += Search_Audit;
                addCriminalRecord.Show();
            }
            catch (Exception ex)
            {
                Audit($"שגיאת הוספת אירוע: {ex.Message}", AuditSeverity.Critical);
            }
        }

        private void btnUpdateEvent_Click(object sender, EventArgs e)
        {
            try
            {
                int rowIndex = dgvEventsLog.SelectedRows[0].Index;
                if (rowIndex == Constants.NONE)
                {
                    return;
                }

                CriminalEventType type = (CriminalEventType)(dgvEventsLog.Rows[rowIndex].Cells[14].Value);

                Guid id = (Guid)(dgvEventsLog.Rows[rowIndex].Cells[10].Value);
                int houseNumber = (int)(dgvEventsLog.Rows[rowIndex].Cells[13].Value);

                DateTime time = (DateTime)(dgvEventsLog.Rows[rowIndex].Cells[11].Value);

                string street = dgvEventsLog.Rows[rowIndex].Cells[12].Value.ToString();
                string family = dgvEventsLog.Rows[rowIndex].Cells[5].Value.ToString();
                string description = dgvEventsLog.Rows[rowIndex].Cells[0].Value.ToString();
                string whatWasStolen = dgvEventsLog.Rows[rowIndex].Cells[3].Value.ToString();
                string arrivalDirection = dgvEventsLog.Rows[rowIndex].Cells[2].Value.ToString();
                string whoArrivedAfterTheEvent = dgvEventsLog.Rows[rowIndex].Cells[1].Value.ToString();

                CriminalEvent criminalEvent = new CriminalEvent(type,
                                                                id,
                                                                houseNumber,
                                                                time,
                                                                street,
                                                                family,
                                                                description,
                                                                whatWasStolen,
                                                                arrivalDirection,
                                                                whoArrivedAfterTheEvent);

                frmAddUpdateCriminalRecord updateCriminalRecord = new frmAddUpdateCriminalRecord(criminalEvent);
                updateCriminalRecord.Save += AddUpdateCriminalRecord_Save;
                updateCriminalRecord.Show();
            }
            catch (Exception ex)
            {
                Audit($"שגיאת עדכון אירוע: {ex.Message}", AuditSeverity.Critical);
            }
        }

        private void btnDeleteEvent_Click(object sender, EventArgs e)
        {
            string result;

            try
            {
                int rowIndex = dgvEventsLog.SelectedRows[0].Index;
                if (rowIndex == Constants.NONE)
                {
                    return;
                }

                Guid id = (Guid)(dgvEventsLog.Rows[rowIndex].Cells[10].Value);
                if (id != Guid.Empty)
                {
                    DialogResult dialogResult = MessageBox.Show("?לבטל", "ביטול אירוע", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dialogResult != DialogResult.Yes)
                    {
                        return;
                    }

                    if (crud == null)
                    {
                        Audit("אין גישה לנתונים :שגיאת ביטול אירוע", AuditSeverity.Critical);

                        return;
                    }

                    if (!crud.Delete(id, out result))
                    {
                        Audit($"שגיאת ביטול אירוע: {result}", AuditSeverity.Critical);                        

                        return;
                    }

                    if (!RefreshCriminalEventsGrid(out result))
                    {
                        Audit($"שגיאת טעינת אירועים: {result}", AuditSeverity.Critical);                        

                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                Audit($"שגיאת ביטול אירוע: {ex.Message}", AuditSeverity.Critical);                
            }
        }

        #endregion

        #region Searches

        private void btnByDateTime_Click(object sender, EventArgs e)
        {
            try
            {
                frmSearchByTime searchByTime = new frmSearchByTime();
                searchByTime.Reply += Search_Reply;
                searchByTime.Audit += Search_Audit;

                searchByTime.Show();
            }
            catch (Exception ex)
            {
                Audit($"שגיאת שאילתא לפי זמן: {ex.Message}", AuditSeverity.Critical);
            }
        }

        private void btnByAddress_Click(object sender, EventArgs e)
        {
            try
            {
                frmSearchByAddress searchByAddress = new frmSearchByAddress();
                searchByAddress.Reply += Search_Reply;
                searchByAddress.Audit += Search_Audit;

                searchByAddress.Show();
            }
            catch (Exception ex)
            {
                Audit($"שגיאת שאילתא לפי כתובת: {ex.Message}", AuditSeverity.Critical);
            }
        }
        
        private void btnByFamily_Click(object sender, EventArgs e)
        {
            try
            {
                frmSearchByFamily searchByFamily = new frmSearchByFamily();
                searchByFamily.Reply += Search_Reply;
                searchByFamily.Audit += Search_Audit;

                searchByFamily.Show();
            }
            catch (Exception ex)
            {
                Audit($"שגיאת שאילתא לפי משפחה/משק/מבנה: {ex.Message}", AuditSeverity.Critical);
            }
        }

        private void btnAll_Click(object sender, EventArgs e)
        {
            string result;

            try
            {
                if (!RefreshCriminalEventsGrid(out result))
                {
                    return;
                }
            }
            catch (Exception ex)
            {
                Audit($"שגיאת שאילתא רשימה מלאה: {ex.Message}", AuditSeverity.Critical);
            }
        }

        private void btnByEventType_Click(object sender, EventArgs e)
        {
            try
            {
                frmSearchByEvent searchByEvent = new frmSearchByEvent();
                searchByEvent.Reply += Search_Reply;
                searchByEvent.Audit += Search_Audit;

                searchByEvent.Show();
            }
            catch (Exception ex)
            {
                Audit($"שגיאת שאילתא לפי סוג אירוע: {ex.Message}", AuditSeverity.Critical);
            }
        }

        private void btnCombined_Click(object sender, EventArgs e)
        {            
            try
            {
                frmCombinedSearch combinedSearch = new frmCombinedSearch();
                combinedSearch.Reply += Search_Reply;
                combinedSearch.Audit += Search_Audit;

                combinedSearch.Show();
            }
            catch (Exception ex)
            {
                Audit($"שגיאת שאילתא משולבת: {ex.Message}", AuditSeverity.Critical);
            }
        }

        #endregion

        #region Map

        private void btnMap_Click(object sender, EventArgs e)
        {
            try
            {
                frmMap map = new frmMap(mapInitialInformation, locationServiceInformation, criminalEventsForMap);
                map.Audit += Map_Audit;
                map.Save += AddUpdateCriminalRecord_Save;
                map.Show();
            }
            catch (Exception ex)
            {
                Audit($"שגיאת הצגת מפה: {ex.Message}", AuditSeverity.Critical);
            }
        }

        private void Map_Audit(string message, AuditSeverity severity)
        {
            Audit(message, severity);
        }

        #endregion

        #region General

        private void btnSettings_Click(object sender, EventArgs e)
        {
            try
            {
                frmSettings settings = new frmSettings(configurationInformation, eventsLogDatabase);
                settings.Audit += Search_Audit;
                settings.Reply += Settings_Reply;
                settings.Show();
            }
            catch (Exception ex)
            {
                Audit($"שגיאת הצגת הגדרות: {ex.Message}", AuditSeverity.Critical);
            }
        }

        private void btnVersion_Click(object sender, EventArgs e)
        {
            try
            {
                List<string> dllFiles = Directory.GetFiles(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Mazor*.dll").ToList();
                List<string> exeFiles = Directory.GetFiles(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Mazor*.exe").ToList();
                List<string> allFiles = dllFiles;
                allFiles.AddRange(exeFiles);

                string filesVersions = string.Empty;

                foreach (string filename in allFiles)
                {
                    FileVersionInfo fileVersionInfo = FileVersionInfo.GetVersionInfo(allFiles[0]);

                    string fileLine = $"{Path.GetFileName(filename)}: {fileVersionInfo.FileVersion}{Environment.NewLine}";

                    filesVersions += fileLine;
                }
                

                MessageBox.Show(filesVersions, $"גרסה: {Application.ProductVersion}");
            }
            catch (Exception ex)
            {
                Audit($"שגיאת הצגת גרסה: {ex.Message}", AuditSeverity.Critical);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            string result;

            try
            {
                if (crud == null)
                {
                    MessageBox.Show("אין גישה לנתונים", "תקלת סגירה", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    if (!crud.SaveCriminalEvents(out result))
                    {
                        MessageBox.Show(result, "תקלת שמירת נתונים", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

                Environment.Exit(0);
            }
            catch (Exception ex)
            {
                Audit($"שגיאת יציאה: {ex.Message}", AuditSeverity.Critical);
            }
        }

        #endregion

        #region GUI Event Handlers

        private void Settings_Reply(object sender, EventArgs e)
        {
            string result;

            ConfigurationInformation inConfigurationInformation;

            try
            {
                inConfigurationInformation = (ConfigurationInformation)e;

                if (inConfigurationInformation == null)
                {
                    Audit($"שגיאת עדכון הגדרות. אובייקט הגדרות ריק", AuditSeverity.Critical);

                    return;
                }

                if (!SaveToAppConfig(inConfigurationInformation, out result))
                {
                    Audit($"שגיאת עדכון הגדרות: {result}", AuditSeverity.Critical);

                    return;
                }

                configurationInformation = inConfigurationInformation;
            }
            catch (Exception ex)
            {
                Audit($"שגיאת חיפוש לפי זמן: {ex.Message}", AuditSeverity.Critical);
            }
        }

        private void AddUpdateCriminalRecord_Save(object sender, EventArgs e)
        {
            string result;

            CriminalEvent criminalEvent;

            try
            {
                criminalEvent = (CriminalEvent)e;

                if (criminalEvent == null)
                {
                    Audit($"שגיאת הוספה/עדכון רשומה: רשומה ריקה", AuditSeverity.Critical);                    

                    return;
                }

                if (criminalEvent.Id == Guid.Empty)
                {
                    if (!crud.Create(criminalEvent, out result))
                    {
                        Audit($"שגיאת הוספת רשומה: {result}", AuditSeverity.Critical);
                        
                        return;
                    }
                }
                else
                {
                    if (!crud.Update(criminalEvent, out result))
                    {
                        Audit($"שגיאת עדכון רשומה: {result}", AuditSeverity.Critical);
                        
                        return;
                    }
                }

                if (!RefreshCriminalEventsGrid(out result))
                {
                    Audit($"שגיאת רענון רשימה: {result}", AuditSeverity.Critical);

                    return;
                }
            }
            catch (Exception ex)
            {
                Audit($"שגיאת הוספה/עדכון רשומה: {ex.Message}", AuditSeverity.Critical);                
            }
        }

        private void Search_Reply(object sender, EventArgs e)
        {
            string result;

            SearchFilter searchFilter;

            List<CriminalEvent> criminalEvents;

            try
            {
                searchFilter = (SearchFilter)e;

                if (searchFilter == null)
                {
                    Audit($"שגיאת חיפוש לפי זמן. חיפוש ריק", AuditSeverity.Critical);

                    return;
                }

                if (searchFilter.Logic == QueryLogic.And)
                {
                    if (!SearchAnd(searchFilter, out criminalEvents, out result))
                    {
                        Audit($"שגיאת חיפוש: {result}", AuditSeverity.Critical);

                        return;
                    }
                }
                else
                {
                    if (!SearchOr(searchFilter, out criminalEvents, out result))
                    {
                        Audit($"שגיאת חיפוש: {result}", AuditSeverity.Critical);

                        return;
                    }
                }

                if (!FillGrid(criminalEvents, out result))
                {
                    Audit($"שגיאת מילוי רשימה: {result}", AuditSeverity.Critical);

                    return;
                }
            }
            catch (Exception ex)
            {
                Audit($"שגיאת חיפוש לפי זמן: {ex.Message}", AuditSeverity.Critical);
            }
        }

        private void Search_Audit(string message, AuditSeverity severity)
        {
            try
            {
                Audit(message, severity);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,
                                "תקלת בקרה",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }

        #endregion

        #endregion

        #region Search Stuff

        private bool SearchOr(SearchFilter searchFilter, out List<CriminalEvent> criminalEvents, out string result)
        {
            result = string.Empty;

            criminalEvents = null;

            try
            {
                if (searchFilter == null)
                {
                    result = "Search Filter Is Null";

                    return false;
                }

                criminalEvents = new List<CriminalEvent>();

                List<CriminalEvent> resultCriminalEvents;
                if (searchFilter.DaysFilterOn)
                {
                    if (!SearchByDays(searchFilter.Days, out resultCriminalEvents, out result))
                    {
                        return false;
                    }

                    if ((resultCriminalEvents != null) && (resultCriminalEvents.Count > 0))
                    {
                        criminalEvents.AddRange(resultCriminalEvents);
                    }
                }

                if (searchFilter.DateFilterOn)
                {
                    if (!SearchByDate(searchFilter.Date, out resultCriminalEvents, out result))
                    {
                        return false;
                    }

                    if ((resultCriminalEvents != null) && (resultCriminalEvents.Count > 0))
                    {
                        criminalEvents.AddRange(resultCriminalEvents);
                    }
                }

                if (searchFilter.TimeFilterOn)
                {
                    if (!SearchByTime(searchFilter.Time, out resultCriminalEvents, out result))
                    {
                        return false;
                    }

                    if ((resultCriminalEvents != null) && (resultCriminalEvents.Count > 0))
                    {
                        criminalEvents.AddRange(resultCriminalEvents);
                    }
                }

                if (searchFilter.KeyWordsSearchOn)
                {
                    if (!SearchByKeyWords(searchFilter.KeyWordsSearch, searchFilter.KwsType, out resultCriminalEvents, out result))
                    {
                        return false;
                    }

                    if ((resultCriminalEvents != null) && (resultCriminalEvents.Count > 0))
                    {
                        criminalEvents.AddRange(resultCriminalEvents);
                    }
                }

                if (searchFilter.KeyWordsSearchAddressOn)
                {
                    if (!SearchByKeyWords(searchFilter.KeyWordsSearchAddress, KeyWordSearchType.Address, out resultCriminalEvents, out result))
                    {
                        return false;
                    }

                    if ((resultCriminalEvents != null) && (resultCriminalEvents.Count > 0))
                    {
                        criminalEvents.AddRange(resultCriminalEvents);
                    }
                }

                if (searchFilter.KeyWordsSearchFamilyOn)
                {
                    if (!SearchByKeyWords(searchFilter.KeyWordsSearchFamily, KeyWordSearchType.Family, out resultCriminalEvents, out result))
                    {
                        return false;
                    }

                    if ((resultCriminalEvents != null) && (resultCriminalEvents.Count > 0))
                    {
                        criminalEvents.AddRange(resultCriminalEvents);
                    }
                }

                if (searchFilter.CriminalEventTypesSearchOn)
                {
                    if (!SearchByCriminalEventsType(searchFilter.CriminalEventTypes, out resultCriminalEvents, out result))
                    {
                        return false;
                    }

                    if ((resultCriminalEvents != null) && (resultCriminalEvents.Count > 0))
                    {
                        criminalEvents.AddRange(resultCriminalEvents);
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

        private bool SearchAnd(SearchFilter searchFilter, out List<CriminalEvent> criminalEvents, out string result)
        {
            result = string.Empty;

            criminalEvents = null;

            try
            {
                if (searchFilter == null)
                {
                    result = "Search Filter Is Null";

                    return false;
                }

                criminalEvents = new List<CriminalEvent>();

                List<CriminalEvent> resultCriminalEvents;
                if (searchFilter.DaysFilterOn)
                {
                    if (!SearchByDays(searchFilter.Days, out resultCriminalEvents, out result))
                    {
                        return false;
                    }

                    if ((resultCriminalEvents != null) && (resultCriminalEvents.Count > 0))
                    {
                        criminalEvents = Utils.Intersect(criminalEvents, resultCriminalEvents, out result);
                    }
                }

                if (searchFilter.DateFilterOn)
                {
                    if (!SearchByDate(searchFilter.Date, out resultCriminalEvents, out result))
                    {
                        return false;
                    }

                    if ((resultCriminalEvents != null) && (resultCriminalEvents.Count > 0))
                    {
                        criminalEvents = Utils.Intersect(criminalEvents, resultCriminalEvents, out result);
                    }
                }

                if (searchFilter.TimeFilterOn)
                {
                    if (!SearchByTime(searchFilter.Time, out resultCriminalEvents, out result))
                    {
                        return false;
                    }

                    if ((resultCriminalEvents != null) && (resultCriminalEvents.Count > 0))
                    {
                        criminalEvents = Utils.Intersect(criminalEvents, resultCriminalEvents, out result);
                    }
                }

                if (searchFilter.KeyWordsSearchAddressOn)
                {
                    if (!SearchByKeyWords(searchFilter.KeyWordsSearchAddress, KeyWordSearchType.Address, out resultCriminalEvents, out result))
                    {
                        return false;
                    }

                    if ((resultCriminalEvents != null) && (resultCriminalEvents.Count > 0))
                    {
                        criminalEvents = Utils.Intersect(criminalEvents, resultCriminalEvents, out result);
                    }
                }

                if (searchFilter.KeyWordsSearchFamilyOn)
                {
                    if (!SearchByKeyWords(searchFilter.KeyWordsSearchFamily, KeyWordSearchType.Family, out resultCriminalEvents, out result))
                    {
                        return false;
                    }

                    if ((resultCriminalEvents != null) && (resultCriminalEvents.Count > 0))
                    {
                        criminalEvents = Utils.Intersect(criminalEvents, resultCriminalEvents, out result);
                    }
                }

                if (searchFilter.CriminalEventTypesSearchOn)
                {
                    if (!SearchByCriminalEventsType(searchFilter.CriminalEventTypes, out resultCriminalEvents, out result))
                    {
                        return false;
                    }

                    if ((resultCriminalEvents != null) && (resultCriminalEvents.Count > 0))
                    {
                        criminalEvents = Utils.Intersect(criminalEvents, resultCriminalEvents, out result);
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

        private bool SearchByDays(DaysFilter searchFilter, out List<CriminalEvent> criminalEvents, out string result)
        {
            result = string.Empty;

            criminalEvents = null;

            try
            {
                if (searchFilter == null)
                {
                    result = "Search Filter Is Null";

                    return false;
                }

                List<object> parameters = new List<object>();
                parameters.Add(searchFilter.Days);

                if (!Retrieve(QueryType.ByDay, parameters, out criminalEvents, out result))
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

        private bool SearchByDate(DateFilter searchFilter, out List<CriminalEvent> criminalEvents, out string result)
        {
            result = string.Empty;

            criminalEvents = null;

            try
            {
                if (searchFilter == null)
                {
                    result = "Search Filter Is Null";

                    return false;
                }

                List<object> parameters = new List<object>();
                if (searchFilter.FromTo)
                {
                    parameters.Add(searchFilter.DateFrom);
                    parameters.Add(searchFilter.DateTo);
                }
                else
                {
                    parameters.Add(searchFilter.Date);
                }

                if (!Retrieve(QueryType.ByDate, parameters, out criminalEvents, out result))
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

        private bool SearchByTime(TimeFilter searchFilter, out List<CriminalEvent> criminalEvents, out string result)
        {
            result = string.Empty;

            criminalEvents = null;

            try
            {
                if (searchFilter == null)
                {
                    result = "Search Filter Is Null";

                    return false;
                }

                List<object> parameters = new List<object>();
                if (searchFilter.FromTo)
                {
                    parameters.Add(searchFilter.TimeFrom);
                    parameters.Add(searchFilter.TimeTo);
                }
                else
                {
                    parameters.Add(searchFilter.Time);
                }

                if (!Retrieve(QueryType.ByTime, parameters, out criminalEvents, out result))
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

        private bool SearchByKeyWords(List<string> searchFilter, KeyWordSearchType kwsType, out List<CriminalEvent> criminalEvents, out string result)
        {
            result = string.Empty;

            criminalEvents = null;

            try
            {
                if (searchFilter == null)
                {
                    result = "Search Filter Is Null";

                    return false;
                }

                List<object> parameters = new List<object>();
                parameters.Add(searchFilter);

                QueryType queryType;

                switch (kwsType)
                {
                    case KeyWordSearchType.Address:
                        queryType = QueryType.ByAddress;
                        break;

                    case KeyWordSearchType.Family:
                        queryType = QueryType.ByFamily;
                        break;

                    default:
                        result = string.Format("Wrong Key Word Search Type[{0}]", kwsType);
                        return false;
                }

                if (!Retrieve(queryType, parameters, out criminalEvents, out result))
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

        private bool SearchByCriminalEventsType(List<CriminalEventType> searchFilter, out List<CriminalEvent> criminalEvents, out string result)
        {
            result = string.Empty;

            criminalEvents = null;

            try
            {
                if (searchFilter == null)
                {
                    result = "Search Filter Is Null";

                    return false;
                }

                List<object> parameters = new List<object>();
                parameters.Add(searchFilter);

                if (!Retrieve(QueryType.ByEvent, parameters, out criminalEvents, out result))
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

        #region On Closing

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            string result;

            try
            {
                if (crud == null)
                {
                    MessageBox.Show("אין גישה לנתונים", "תקלת יציאה", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    return;
                }

                if (!crud.SaveCriminalEvents(out result))
                {
                    MessageBox.Show(result, "תקלת שמירת נתונים", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "תקלת יציאה", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region Audit

        private void Audit(string message, AuditSeverity severity)
        {
            try
            {
                string nowDateTime = DateTime.Now.ToString("HH:mm:ss dd/MM/yyyy");

                dgvAudit.Rows.Insert(0, new string[] { nowDateTime, message, Utils.GetEnumDescription(severity) });
                dgvAudit.Rows[0].DefaultCellStyle.BackColor = GetColorBySeverity(severity);

                dgvAudit.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
                dgvAudit.ClearSelection();

                if (configurationInformation != null)
                {
                    if (configurationInformation.LogToFile)
                    {
                        AuditFile.WriteLine($"{nowDateTime} <{Utils.GetEnumDescription(severity)}>: {message}");
                        AuditFile.Flush();
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "שגיאת כתיבה", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private Color GetColorBySeverity(AuditSeverity severity)
        {
            Color color = Color.White; 

            switch (severity)
            {
                case AuditSeverity.Information:
                    color = Color.Aquamarine;
                    break;

                case AuditSeverity.Important:
                    color = Color.LawnGreen;
                    break;

                case AuditSeverity.Warning:
                    color = Color.Plum;
                    break;

                case AuditSeverity.Critical:
                    color = Color.Tomato;
                    break;

                case AuditSeverity.Error:
                    color = Color.Red;
                    break;

                default:
                    color = Color.Yellow;
                    break;
            }

            return color;
        }

        #endregion

        #region Timers

        private void tmrTestConnection_Tick(object sender, EventArgs e)
        {
            bool enableMapButton = false;

            string result;

            try
            {
                tmrTestConnection.Enabled = false;

                enableMapButton = Utils.IsReachable(PingTestAddress, out result);

                if (!string.IsNullOrEmpty(result))
                {
                    Audit($"שגיאת תקשורת: {result}", AuditSeverity.Warning);
                }
            }
            catch (Exception ex)
            {
                Audit($"שגיאת תקשורת: {ex.Message}", AuditSeverity.Warning);

                enableMapButton = false;
            }
            finally
            {
                btnMap.Enabled = enableMapButton;

                tmrTestConnection.Enabled = true;
            }
        }

        #endregion
    }
}
