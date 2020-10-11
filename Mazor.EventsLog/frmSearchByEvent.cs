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
    public partial class frmSearchByEvent : Form
    {
        #region Events

        public event EventHandler Reply;
        public event AuditMessage Audit;

        #endregion

        public frmSearchByEvent()
        {
            InitializeComponent();
        }

        private void frmSearchByEvent_Load(object sender, EventArgs e)
        {
            try
            {
                Location = Cursor.Position;

                foreach (CriminalEventType criminalEventType in (CriminalEventType[])Enum.GetValues(typeof(CriminalEventType)))
                {
                    lbEventTypes.Items.Add(Utils.GetEnumDescription(criminalEventType));
                }
            }
            catch (Exception ex)
            {
                OnAudit($"שגיאת טעינת חיפוש לפי אירוע: {ex.Message}", AuditSeverity.Error);                
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
                    List<CriminalEventType> eventTypesSearch = new List<CriminalEventType>();

                    foreach (object oEventType in lbEventTypes.SelectedItems)
                    {
                        int eventTypeIndex = lbEventTypes.Items.IndexOf(oEventType);
                        eventTypesSearch.Add((CriminalEventType)eventTypeIndex);
                    }

                    SearchFilter searchFilter = new SearchFilter(eventTypesSearch);

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
