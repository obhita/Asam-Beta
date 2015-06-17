using Agatha.Common;

namespace Asam.Ppc.Service.Messages.Assessment
{
    public class CreateAssessmentRequest : Request
    {
        public long PatientId { get; set; }
    }
}
