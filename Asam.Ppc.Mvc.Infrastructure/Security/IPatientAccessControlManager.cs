namespace Asam.Ppc.Mvc.Infrastructure.Security
{
    public interface IPatientAccessControlManager
    {
        bool CanAccessAllPatients { get; }

        bool CanAccessPatient ( long patientKey );
    }
}
