using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mazor.EventsLog.Common
{
    public enum CriminalEventType
    {
        [Description("לא ידוע")]
        Unknown,

        [Description("פריצה")]
        Buglary,

        [Description("גניבת רכב")]
        CarTheft,

        [Description("רצח")]
        Murder,

        [Description("ונדליזם")]
        Vandalism,

        [Description("אלימות")]
        Violence,

        [Description("אונס")]
        Rape
    }

    public enum KeyWordSearchType
    {
        Unknown,
        Address,
        Family
    }

    public enum QueryType : byte
    {
        All = 1,
        ByTime = 2,
        ByDate = 4,
        ByDay = 8,
        ByAddress = 16,
        ByFamily = 32,
        ByEvent = 64
    }

    public enum QueryLogic
    {
        Unknown,
        And,
        Or
    }

    public enum AuditSeverity
    {
        [Description("לא ידוע")]
        Unknown,

        [Description("לידיעה")]
        Information,

        [Description("חשוב")]
        Important,

        [Description("התראה")]
        Warning,

        [Description("קריטי")]
        Critical,

        [Description("שגיאה")]
        Error
    }

    public enum CrudAction
    {
        Create,
        Retrieve,
        Update,
        Delete
    }

    public enum EventsLogTable
    {
        ConfigurationInformation,
        CriminalEvents,
        CriminalEventsTypes,
        Streets,
        SpecialLocations,
        Cameras,
        LawEnforcementUnits,
        TrainingUnits
    }
}
