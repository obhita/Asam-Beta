using System.Collections.Generic;
using Agatha.Common;

namespace Asam.Ppc.Service.Messages.Assessment
{
    public class GetAllAssessmentsByKeywordResponse : Response
    {
        public List<AssessmentSummaryDto> Assessments { get; set; }
        public int TotalCount { get; set; }
    }
}
