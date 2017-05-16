using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApprendaAPIClient.Models.DeveloperPortal
{
    public enum ReportCardStatus
    {
        Started = 0,
        Succeeded = 1,
        Failed = 2,
        Canceled = 3
    }

    public enum PromotionOperationType : byte
    {
        NotApplicable = 0,
        Promote = 1,
        Rollback = 2
    }

    public enum MessageLevel
    {
        /// <summary>
        /// Identifies messages related to system failures during system processes
        /// </summary>
        Error = 0,

        Warning = 1,

        /// <summary>
        /// Identifies messages that are simple informational relay messages
        /// </summary>
        Info = 2
    };

    public class ReportMessageDTO
    {
        #region Properties
        public string Message { get; set; }

        public MessageLevel Level { get; set; }
        #endregion
    }
    public class PublishReportCardSectionDTO 
    {
       
        public IList<ReportMessageDTO> Messages { get; set; }


        public string Name { get; set; }

        public DateTime? BeginDate { get; set; }

        public DateTime? EndDate { get; set; }

        public bool IsCanceled { get; set; }

        public PromotionOperationType OperationType { get; set; }

    }

    public class PublishReportCardDTO
    {

        public IList<PublishReportCardSectionDTO> Sections { get; set; }

        public DateTime BeginDate { get; set; }

        public DateTime? EndDate { get; set; }

        public ReportCardStatus Status { get; set; }
    }
}
