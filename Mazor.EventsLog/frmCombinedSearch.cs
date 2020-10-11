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
    public partial class frmCombinedSearch : Form
    {
        #region Events

        public event EventHandler Reply;
        public event AuditMessage Audit;

        #endregion

        public frmCombinedSearch()
        {
            InitializeComponent();
        }

        private void frmCombinedSearch_Load(object sender, EventArgs e)
        {
            try
            {
                Location = Cursor.Position;

                #region Time

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

                #endregion

                #region Criminal Events

                foreach (CriminalEventType criminalEventType in (CriminalEventType[])Enum.GetValues(typeof(CriminalEventType)))
                {
                    lbEventTypes.Items.Add(Utils.GetEnumDescription(criminalEventType));
                }

                #endregion

                rbOr.Checked = true;
            }
            catch (Exception ex)
            {
                OnAudit($"שגיאת טעינת חיפוש משולב: {ex.Message}", AuditSeverity.Error);
            }
        }

        #region Address

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(cboStreet.Text))
                {
                    return;
                }

                string searchLine = string.Empty;
                string houseNumber = (nudHouseNumber.Value == 0) ? string.Empty : string.Format("{0}", nudHouseNumber.Value);

                searchLine = string.Format("{0} {1}", cboStreet.Text, houseNumber);

                int index = lbSearch.FindStringExact(searchLine);
                if (index != Constants.NONE)
                {
                    return;
                }

                lbSearch.Items.Add(searchLine);
            }
            catch (Exception ex)
            {
                OnAudit($"שגיאת הוספת כתובת: {ex.Message}", AuditSeverity.Error);
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            try
            {
                if (lbSearch.SelectedItems != null)
                {
                    List<int> selectedItemIndexes = new List<int>();
                    foreach (object oDay in lbSearch.SelectedItems)
                    {
                        int toDeleteIndex = lbSearch.Items.IndexOf(oDay);
                        selectedItemIndexes.Add(toDeleteIndex);
                    }

                    if ((selectedItemIndexes != null) && (selectedItemIndexes.Count > 0))
                    {
                        selectedItemIndexes.Reverse();

                        for (int i = 0; i < selectedItemIndexes.Count; i++)
                        {
                            lbSearch.Items.RemoveAt(selectedItemIndexes[i]);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                OnAudit($"שגיאת הסרת כתובת: {ex.Message}", AuditSeverity.Error);
            }
        }

        #endregion

        #region Family / Location

        private void btnAddFamily_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtFamily.Text))
                {
                    return;
                }

                int index = lbSearchFamily.FindStringExact(txtFamily.Text);
                if (index != Constants.NONE)
                {
                    return;
                }

                lbSearchFamily.Items.Add(txtFamily.Text);
            }
            catch (Exception ex)
            {
                OnAudit($"תקלת הוספת משפחה/משק/מבנה: {ex.Message}", AuditSeverity.Error);
            }
        }

        private void btnRemoveFamily_Click(object sender, EventArgs e)
        {
            try
            {
                if (lbSearchFamily.SelectedItems != null)
                {
                    List<int> selectedItemIndexes = new List<int>();
                    foreach (object oDay in lbSearchFamily.SelectedItems)
                    {
                        int toDeleteIndex = lbSearchFamily.Items.IndexOf(oDay);
                        selectedItemIndexes.Add(toDeleteIndex);
                    }

                    if ((selectedItemIndexes != null) && (selectedItemIndexes.Count > 0))
                    {
                        selectedItemIndexes.Reverse();

                        for (int i = 0; i < selectedItemIndexes.Count; i++)
                        {
                            lbSearchFamily.Items.RemoveAt(selectedItemIndexes[i]);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                OnAudit($"תקלת מחיקת משפחה/משק/מבנה: {ex.Message}", AuditSeverity.Error);
            }
        }

        #endregion

        #region Date / Time

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

        #endregion

        private void btnQuery_Click(object sender, EventArgs e)
        {
            string result;

            if (!ValidateFilter(out result))
            {
                OnAudit($"שגיאת הגדרת חיפוש {result}", AuditSeverity.Error);

                return;
            }

            if (Reply != null)
            {
                #region Criminal Events

                List<CriminalEventType> eventTypesSearch = new List<CriminalEventType>();

                foreach (object oEventType in lbEventTypes.SelectedItems)
                {
                    int eventTypeIndex = lbEventTypes.Items.IndexOf(oEventType);
                    eventTypesSearch.Add((CriminalEventType)eventTypeIndex);
                }

                if (eventTypesSearch.Count == 0)
                {
                    eventTypesSearch = null;
                }

                #endregion

                #region Date / Time

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

                #endregion

                #region Family

                List<string> keyWordsSearchFamily = new List<string>();

                foreach (string kws in lbSearchFamily.Items)
                {
                    keyWordsSearchFamily.Add(kws);
                }

                if (keyWordsSearchFamily.Count == 0)
                {
                    keyWordsSearchFamily = null;
                }

                #endregion

                #region Address

                List<string> keyWordsSearchAddress = new List<string>();

                foreach (string kws in lbSearch.Items)
                {
                    keyWordsSearchAddress.Add(kws);
                }

                if (keyWordsSearchAddress.Count == 0)
                {
                    keyWordsSearchAddress = null;
                }

                #endregion

                SearchFilter searchFilter = new SearchFilter(eventTypesSearch, 
                                                             keyWordsSearchAddress, 
                                                             keyWordsSearchFamily, 
                                                             daysFilter, 
                                                             timeFilter, 
                                                             dateFilter,
                                                             rbOr.Checked ? QueryLogic.Or : QueryLogic.And);
 
                Reply(null, searchFilter);

                Close();
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

        private void OnAudit(string message, AuditSeverity severity)
        {
            if (Audit != null)
            {
                Audit(message, severity);
            }
        }
    }
}
