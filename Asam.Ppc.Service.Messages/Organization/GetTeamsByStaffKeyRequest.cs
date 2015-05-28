namespace Asam.Ppc.Service.Messages.Organization
{
    using Agatha.Common;

    public class GetTeamsByStaffKeyRequest : Request
    {
        public long StaffKey { get; set; }
    }
}
