using System.Collections.Specialized;

namespace Asam.Ppc.Mvc.Infrastructure.Security
{
    public class SingleSignOn
    {
        public string EhrId { get; set; }
        public string OrganizationId { get; set; }
        public string ApiKey { get; set; }
        public byte[] Token { get; set; }
        public NameValueCollection Form { get; set; }
    }
}
