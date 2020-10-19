using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Mazor.EventsLog.Common;

namespace Mazor.EventsLog
{
    public partial class frmAddUpdateCriminalRecord : Form
    {
        #region Events

        public event EventHandler Save;
        public event AuditMessage Audit;

        #endregion

        #region Data Members

        private CriminalEvent criminalEvent;

        #endregion

        #region Constructors

        public frmAddUpdateCriminalRecord()
        {
            InitializeComponent();

            criminalEvent = null;
        }

        public frmAddUpdateCriminalRecord(CriminalEvent inCriminalEvent)
        {
            InitializeComponent();

            criminalEvent = inCriminalEvent;
        }

        #endregion

        private void frmAddUpdateCriminalRecord_Load(object sender, EventArgs e)
        {
            try
            {
                Location = Cursor.Position;

                foreach (CriminalEventType criminalEventType in (CriminalEventType[])Enum.GetValues(typeof(CriminalEventType)))
                {
                    cboEventType.Items.Add(Utils.GetEnumDescription(criminalEventType));
                }
                cboEventType.Text = cboEventType.Items[0].ToString();


                if (criminalEvent == null)
                {
                    Text = "הוספת אירוע";
                }
                else
                {
                    Text = "עדכון אירוע";

                    cboEventType.Text = Utils.GetEnumDescription(criminalEvent.Type);

                    txtFamily.Text = criminalEvent.Family;
                    cboStreet.Text = criminalEvent.Street;
                    nudHouseNumber.Value = criminalEvent.HouseNumber;
                    lbArrivalDirection.Text = criminalEvent.ArrivalDirection;
                    txtWhatWasStolen.Text = criminalEvent.WhatWasStolen;
                    lbWhoArrivedAfterTheEvent.Text = criminalEvent.WhoArrivedAfterTheEvent;
                    txtDescription.Text = criminalEvent.Description;

                    dtTime.Value = criminalEvent.Time;
                    dtDate.Value = criminalEvent.Time;
                }
            }
            catch (Exception ex)
            {
                OnAudit($"שגיאת הוספה/עדכון אירוע: {ex.Message}", AuditSeverity.Error);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string result;

            try
            {
                if (!ValidateRecord(out result))
                {
                    OnAudit("שגיאת שמירת אירוע", AuditSeverity.Error);

                    return;
                }

                if (Save != null)
                {
                    CriminalEvent newCriminalEvent = new CriminalEvent();

                    newCriminalEvent.Id = (criminalEvent == null) ? Guid.Empty : criminalEvent.Id;

                    if (newCriminalEvent.Id != Guid.Empty)
                    {
                        DialogResult dialogResult = MessageBox.Show("?לעדכן", "עדכון אירוע", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (dialogResult != DialogResult.Yes)
                        {
                            return;
                        }
                    }

                    int criminalEventTypeIndex = cboEventType.SelectedIndex;

                    newCriminalEvent.Type = (CriminalEventType)criminalEventTypeIndex;
                    newCriminalEvent.Family = txtFamily.Text;
                    newCriminalEvent.Street = cboStreet.Text;
                    newCriminalEvent.HouseNumber = (int)nudHouseNumber.Value;
                    newCriminalEvent.ArrivalDirection = lbArrivalDirection.Text;
                    newCriminalEvent.WhatWasStolen = txtWhatWasStolen.Text;
                    newCriminalEvent.WhoArrivedAfterTheEvent = lbWhoArrivedAfterTheEvent.Text;
                    newCriminalEvent.Description = txtDescription.Text;

                    newCriminalEvent.Time = new DateTime(dtDate.Value.Year, dtDate.Value.Month, dtDate.Value.Day, dtTime.Value.Hour, dtTime.Value.Minute, dtTime.Value.Second);

                    Save(null, newCriminalEvent);

                    Close();
                }
            }
            catch (Exception ex)
            {
                OnAudit($"שגיאת שמירת אירוע: {ex.Message}", AuditSeverity.Error);
            }
        }

        private bool ValidateRecord(out string result)
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
