namespace Asam.Ppc.Service.Messages.Security
{
    using Agatha.Common;

    public class GetAvailablePermissionsRequest : Request
    {
        public long Key { get; set; }
    }
}