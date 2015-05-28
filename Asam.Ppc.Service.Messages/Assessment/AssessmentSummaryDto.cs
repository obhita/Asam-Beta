using System;
using Asam.Ppc.Service.Messages.Common;

namespace Asam.Ppc.Service.Messages.Assessment
{
    public class AssessmentSummaryDto : KeyedDataTransferObject
    {
        public DateTime CreatedTimestamp { get; set; }

        public string CreatedTimestampString { get { return CreatedTimestamp.ToShortDateString (); } }

        public string PatientId { get; set; }
        public string PatientFirstName { get; set; }
        public string PatientLastName { get; set; }

        public int PercentComplete { get; set; }
        public bool IsSubmitted { get; set; }
    }
}
