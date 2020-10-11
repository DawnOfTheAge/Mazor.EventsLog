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
    public partial class frmSearchByFamily : Form
    {
        #region Events

        public event EventHandler Reply;
        public event AuditMessage Audit;

        #endregion

        public frmSearchByFamily()
        {
            InitializeComponent();
        }

        private void frmSearchByFamily_Load(object sender, EventArgs e)
        {
            try
            {
                Location = Cursor.Position;
            }
            catch (Exception ex)
            {
                OnAudit($"שגיאת טעינת חיפוש לפי משפחה/משק/מבנה: {ex.Message}", AuditSeverity.Error);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtFamily.Text))
                {
                    return;
                }

                int index = lbSearch.FindStringExact(txtFamily.Text);
                if (index != Constants.NONE)
                {
                    return;
                }

                lbSearch.Items.Add(txtFamily.Text);
            }
            catch (Exception ex)
            {
                OnAudit($"תקלת הוספת משפחה/משק/מבנה: {ex.Message}", AuditSeverity.Error);
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
                OnAudit($"תקלת מחיקת משפחה/משק/מבנה: {ex.Message}", AuditSeverity.Error);                
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
                    List<string> keyWordsSearch = new List<string>();

                    foreach (string kws in lbSearch.Items)
                    {
                        keyWordsSearch.Add(kws);
                    }

                    SearchFilter searchFilter = new SearchFilter(keyWordsSearch);
                    searchFilter.KwsType = KeyWordSearchType.Family;

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
