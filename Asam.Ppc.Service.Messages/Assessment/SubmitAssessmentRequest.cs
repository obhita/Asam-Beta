using Agatha.Common;

namespace Asam.Ppc.Service.Messages.Assessment
{
    public class SubmitAssessmentRequest : Request
    {
        public long AssessmentKey { get; set; }
        public string Username { get; set; }
    }
}
