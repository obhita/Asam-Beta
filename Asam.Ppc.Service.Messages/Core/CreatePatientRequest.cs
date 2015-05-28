using Agatha.Common;

namespace Asam.Ppc.Service.Messages.Core
{
    public class CreatePatientRequest : Request
    {
        public PatientDto PatientDto { get; set; }
    }
}
