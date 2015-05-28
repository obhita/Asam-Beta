namespace Asam.Ppc.Service.Messages.Security
{
    using Agatha.Common;

    public class GetApiSystemAccountRequest : Request
    {
        public long EhrId { get; set; }
        public long OrganizationKey { get; set; }
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string UserEmail { get; set; }
    }
}