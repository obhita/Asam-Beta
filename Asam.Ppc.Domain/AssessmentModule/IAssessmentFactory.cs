using Asam.Ppc.Domain.PatientModule;

namespace Asam.Ppc.Domain.AssessmentModule
{
    public interface IAssessmentFactory
    {
        Assessment Create(Patient patient);
    }
}