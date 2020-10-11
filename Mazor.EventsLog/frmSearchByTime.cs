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
    public partial class frmSearchByTime : Form
    {
        #region Events

        public event EventHandler Reply;
        public event AuditMessage Audit;

        #endregion

        public frmSearchByTime()
        {
            InitializeComponent();
        }

        private void frmSearchByTime_Load(object sender, EventArgs e)
        {
            try
            {
                Location = Cursor.Position;

                dtTime.Enabled = false;

                dtTimeFrom.Enabled = false;
                dtTimeTo.Enabled = false;

                dtDate.Enabled = false;

                dtDateFrom.Enabled = false;
                dtDateTo.Enabled = false;

                rbDate.Enabled = false;
                rbDateInterval.Enabled = false;

                rbTime.Enabled = false;
                rbTimeInterval.Enabled = false;

                lbDays.Enabled = false;
            }
            catch (Exception ex)
            {
                OnAudit($"שגיאת טעינת חיפוש לפי זמן: {ex.Message}", AuditSeverity.Error);
            }
        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            string result;

            try
            {
                if (!ValidateFilter(out result))
                {
                    OnAudit($"שגיאת הגדרת חיפוש {result}", AuditSeverity.Error);

                    return;
                }

                if (Reply != null)
                {
                    DaysFilter daysFilter = null;
                    TimeFilter timeFilter = null;
                    DateFilter dateFilter = null;

                    if (chkDay.Checked)
                    {
                        daysFilter = new DaysFilter();

                        if (lbDays.SelectedItems != null)
                        {
                            foreach (object oDay in lbDays.SelectedItems) 
                            {
                                int dayIndex = lbDays.Items.IndexOf(oDay);
                                daysFilter.Days.Add((DayOfWeek)dayIndex);
                            }
                        }
                    }

                    if (chkTime.Checked)
                    {
                        timeFilter = new TimeFilter();

                        if (rbTime.Checked)
                        {
                            timeFilter.Time = dtTime.Value;
                        }
                        else
                        {
                            timeFilter.TimeFrom = dtTimeFrom.Value;
                            timeFilter.TimeTo = dtTimeTo.Value;
                        }

                        timeFilter.FromTo = !rbTime.Checked;
                    }

                    if (chkDate.Checked)
                    {
                        dateFilter = new DateFilter();

                        if (rbDate.Checked)
                        {
                            dateFilter.Date = dtDate.Value;
                        }
                        else
                        {
                            dateFilter.DateFrom = dtDateFrom.Value;
                            dateFilter.DateTo = dtDateTo.Value;
                        }

                        dateFilter.FromTo = !rbDate.Checked;
                    }

                    SearchFilter searchFilter = new SearchFilter(daysFilter, timeFilter, dateFilter);

                    Reply(null, searchFilter);

                    Close();
                }
            }
            catch (Exception ex)
            {
                OnAudit($"תקלת שאילתא: {ex.Message}", AuditSeverity.Error);
            }
        }

        private void rbTimeInterval_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                dtTime.Enabled = false;

                dtTimeFrom.Enabled = true;
                dtTimeTo.Enabled = true;
            }
            catch (Exception ex)
            {
                OnAudit($"תקלת מקטע זמן: {ex.Message}", AuditSeverity.Error);
            }
        }

        private void rbTime_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                dtTime.Enabled = true;

                dtTimeFrom.Enabled = false;
                dtTimeTo.Enabled = false;
            }
            catch (Exception ex)
            {
                OnAudit($"תקלת זמן: {ex.Message}", AuditSeverity.Error);                
            }
        }

        private void rbDate_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                dtDate.Enabled = true;

                dtDateFrom.Enabled = false;
                dtDateTo.Enabled = false;
            }
            catch (Exception ex)
            {
                OnAudit($"תקלת תאריך: {ex.Message}", AuditSeverity.Error);
            }
        }

        private void rbDateInterval_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                dtDate.Enabled = false;

                dtDateFrom.Enabled = true;
                dtDateTo.Enabled = true;
            }
            catch (Exception ex)
            {
                OnAudit($"תקלת מקטע תאריך: {ex.Message}", AuditSeverity.Error);                
            }
        }

        private bool ValidateFilter(out string result)
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

        private void chkDate_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                rbDate.Enabled = chkDate.Checked;
                rbDateInterval.Enabled = chkDate.Checked;
            }
            catch (Exception ex)
            {
                OnAudit($"תקלת תאריך: {ex.Message}", AuditSeverity.Error);                
            }
        }

        private void chkTime_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                rbTime.Enabled = chkTime.Checked;
                rbTimeInterval.Enabled = chkTime.Checked;
            }
            catch (Exception ex)
            {
                OnAudit($"תקלת זמן: {ex.Message}", AuditSeverity.Error);                
            }
        }

        private void chkDay_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                lbDays.Enabled = chkDay.Checked;
            }
            catch (Exception ex)
            {
                OnAudit($"תקלת יום: {ex.Message}", AuditSeverity.Error);
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
