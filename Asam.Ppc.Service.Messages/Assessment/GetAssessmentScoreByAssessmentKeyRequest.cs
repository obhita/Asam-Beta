using Agatha.Common;

namespace Asam.Ppc.Service.Messages.Assessment
{
    public class GetAssessmentScoreByAssessmentKeyRequest : Request
    {
        public long AssessmentKey { get; set; }
    }
}
