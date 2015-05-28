namespace Asam.Ppc.Service.Messages.Organization
{
    using Agatha.Common;
    using Primitives;

    public class CreateStaffRequest: Request
    {
        public PersonName Name { get; set; }
    }
}