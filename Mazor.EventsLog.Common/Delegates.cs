using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mazor.EventsLog.Common
{
    public delegate void AuditMessage(string message, AuditSeverity severity);
}
