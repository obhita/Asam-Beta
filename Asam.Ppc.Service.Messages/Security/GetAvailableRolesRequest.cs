namespace Asam.Ppc.Service.Messages.Security
{
    using Agatha.Common;

    public class GetAvailableRolesRequest : Request
    {
        public long Key { get; set; }
    }
}