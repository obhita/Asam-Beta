using Agatha.Common;

namespace Asam.Ppc.Service.Messages.Assessment
{
    public class GetAssessmentByKeyRequest : Request
    {
        public long AssessmentKey { get; set; }
    }
}
