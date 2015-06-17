namespace Asam.Ppc.Service.Messages.Security
{
    using Agatha.Common;

    public class AssignAccountRequest : Request
    {
        public long StaffKey { get; set; }
        public SystemAccountDto SystemAccountDto { get; set; }
    }
}