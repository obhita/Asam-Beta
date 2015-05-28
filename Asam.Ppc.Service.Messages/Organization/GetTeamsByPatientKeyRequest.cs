namespace Asam.Ppc.Service.Messages.Organization
{
    using Agatha.Common;

    public class GetTeamsByPatientKeyRequest : Request
    {
        public long PatientKey { get; set; }
    }
}