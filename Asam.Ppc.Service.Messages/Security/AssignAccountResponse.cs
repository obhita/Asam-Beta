namespace Asam.Ppc.Service.Messages.Security
{
    using Agatha.Common;

    public class AssignAccountResponse : Response
    {
        public SystemAccountDto SystemAccountDto { get; set; }
    }
}