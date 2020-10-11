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
    public partial class frmSearchByAddress : Form
    {
        #region Events

        public event EventHandler Reply;
        public event AuditMessage Audit;

        #endregion

        public frmSearchByAddress()
        {
            InitializeComponent();
        }
        
        private void frmSearchByAddress_Load(object sender, EventArgs e)
        {
            try
            {
                Location = Cursor.Position;
            }
            catch (Exception ex)
            {
                OnAudit($"שגיאת טעינת חיפוש לפי כתובת: {ex.Message}", AuditSeverity.Error);
            }
        }

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

        private void btnQuery_Click(object sender, EventArgs e)
        {
            string result;

            try
            {
                if (!ValidateFilter(out result))
                {
                    OnAudit($"שגיאת הגדרת חיפוש: {result}", AuditSeverity.Error);
 
                    return;
                }

                if (Reply != null)
                {
                    List<string> keyWordsSearch = new List<string>();

                    foreach (string kws in lbSearch.Items)
                    {
                        keyWordsSearch.Add(kws);
                    }

                    SearchFilter searchFilter = new SearchFilter(keyWordsSearch);
                    searchFilter.KwsType = KeyWordSearchType.Address;

                    Reply(null, searchFilter);

                    Close();
                }
            }
            catch (Exception ex)
            {
                OnAudit($"תקלת שאילתא: {ex.Message}", AuditSeverity.Error);                
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
