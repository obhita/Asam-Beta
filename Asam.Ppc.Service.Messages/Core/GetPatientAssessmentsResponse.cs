using System.Collections.Generic;
using Agatha.Common;
using Asam.Ppc.Service.Messages.Assessment;

namespace Asam.Ppc.Service.Messages.Core
{
    public class GetPatientAssessmentsResponse : Response
    {
        public IEnumerable<AssessmentSummaryDto> Assessments { get; set; }
        public int TotalCount { get; set; }
    }
}
