using Mazor.EventsLog.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mazor.EventsLog
{
    public partial class frmSettings : Form
    {
        #region Events

        public event EventHandler Reply;
        public event AuditMessage Audit;

        #endregion

        #region Data Members

        private ConfigurationInformation configurationInformation;

        #endregion

        #region Constructor

        public frmSettings(ConfigurationInformation inConfigurationInformation)
        {
            InitializeComponent();

            configurationInformation = inConfigurationInformation;
        }

        #endregion

        #region Startup

        private void frmSettings_Load(object sender, EventArgs e)
        {
            try
            {
                Location = Cursor.Position;

                txtJsonFileName.Text = configurationInformation.JsonFileName;
                txtJsonFilePath.Text = configurationInformation.JsonFilePath;
                txtLogFilePath.Text = configurationInformation.LogFilePath;

                chkLogToFile.Checked = configurationInformation.LogToFile;
            }
            catch (Exception ex)
            {
                OnAudit($"שגיאת טעינת הגדרות: {ex.Message}", AuditSeverity.Error);
            }
        }

        #endregion

        #region Files Locations

        private void btnSave_Click(object sender, EventArgs e)
        {
            string result;

            try
            {
                if (!ValidateSettings(out result))
                {
                    OnAudit($"שגיאת הגדרות : {result}", AuditSeverity.Error);

                    return;
                }

                if (Reply != null)
                {
                    ConfigurationInformation configurationInformation = new ConfigurationInformation();

                    configurationInformation.JsonFileName = txtJsonFileName.Text;
                    configurationInformation.JsonFilePath = txtJsonFilePath.Text;
                    configurationInformation.LogFilePath = txtLogFilePath.Text;

                    configurationInformation.LogToFile = chkLogToFile.Checked;

                    Reply(null, configurationInformation);

                    Close();
                }
            }
            catch (Exception ex)
            {
                OnAudit($"תקלת הגדרות: {ex.Message}", AuditSeverity.Error);
            }
        }

        private void btnJsonFilePath_Click(object sender, EventArgs e)
        {
            try
            {
                FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
                DialogResult dialogResult = folderBrowserDialog.ShowDialog();
                if (dialogResult == DialogResult.OK)
                {
                    txtJsonFilePath.Text = folderBrowserDialog.SelectedPath;
                }
            }
            catch (Exception ex)
            {
                OnAudit($"שגיאת בחירת תקיית קובץ נתונים: {ex.Message}", AuditSeverity.Error);
            }
        }

        private void btnLogFilePath_Click(object sender, EventArgs e)
        {
            try
            {
                FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
                DialogResult dialogResult = folderBrowserDialog.ShowDialog();
                if (dialogResult == DialogResult.OK)
                {
                    txtLogFilePath.Text = folderBrowserDialog.SelectedPath;
                }
            }
            catch (Exception ex)
            {
                OnAudit($"שגיאת בחירת תקיית קובץ רשימות: {ex.Message}", AuditSeverity.Error);
            }
        }

        #endregion

        #region Training Units

        private bool FillTrainingUnits(out string result)
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

        #region Law Enforcement Units

        private bool FillLawEnforcementUnits(out string result)
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

        #region Arrival Directions

        private bool FillArrivalDirections(out string result)
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

        #region Streets

        private bool FillStreets(out string result)
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

        #region Locations

        private bool Fill(out string result)
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

        private bool ValidateSettings(out string result)
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

        private void OnAudit(string message, AuditSeverity severity)
        {
            if (Audit != null)
            {
                Audit(message, severity);
            }
        }
    }
}
