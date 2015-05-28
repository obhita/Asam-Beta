namespace Asam.Ppc.Service.Messages.Organization
{
    using Agatha.Common;

    public class CreateOrganizationApiKeyRequest : Request
    {
        public string Name { get; set; }
        public string ApiKey { get; set; }
    }
}
