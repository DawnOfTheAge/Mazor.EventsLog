using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace General.Common.Database.Common
{
    public class Enums
    {
        public enum ContextMember
        {
            Unknown = -1,
            InternalTargetId,
            FormattedTargetId,
            TransferId,
            FormattedExtLineId,
            CaseId,
            SessionId,
            ProductId,
            ConverterType,
            FileQueueName,
            DirectoryPath,
            FormattedStreamGuid,
            SegmentNumber,
            ProductGuid,
            Length
        }
    }
}
