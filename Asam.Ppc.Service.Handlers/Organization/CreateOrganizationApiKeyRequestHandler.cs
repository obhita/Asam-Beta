using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using Asam.Ppc.Common.Email;
using Asam.Ppc.Domain.EhrModule;
using Asam.Ppc.Infrastructure;

namespace Asam.Ppc.Service.Handlers.Organization
{
    using Common;
    using Domain.OrganizationModule;
    using Messages.Common;
    using Messages.Organization;
    using global::AutoMapper;

    public class CreateOrganizationApiKeyRequestHandler :
        ServiceRequestHandler<AddDtoRequest<OrganizationApiKeyDto>, AddDtoResponse<OrganizationApiKeyDto>>
    {
        private readonly IOrganizationRepository _organizationRepository;
        private readonly IEhrRepository _ehrRepository;
        private readonly IEmailNotifier _emailNotifier;

        public CreateOrganizationApiKeyRequestHandler(
            IOrganizationRepository organizationRepository,
            IEhrRepository ehrRepository,
            IEmailNotifier emailNotifier)
        {
            _organizationRepository = organizationRepository;
            _emailNotifier = emailNotifier;
            _ehrRepository = ehrRepository;
        }

        #region Methods

        /// <summary>
        ///     Handles the specified request.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <param name="response">The response.</param>
        protected override void Handle(AddDtoRequest<OrganizationApiKeyDto> request, AddDtoResponse<OrganizationApiKeyDto> response)
        {
            var idKey = UserContext.IsSystemAdmin ? request.AggregateKey : UserContext.OrganizationKey;
            var organization = _organizationRepository.GetByKey(idKey);
            if (organization == null)
            {
                response.DataTransferObject = new OrganizationApiKeyDto();
                response.DataTransferObject.AddDataErrorInfo(new DataErrorInfo(string.Format("Organization with ID {0} does not exist.",idKey) , ErrorLevel.Error));
                return;
            }
            // make sure the API key does not already exist
            if (!string.IsNullOrWhiteSpace(organization.ApiKey))
            {
                response.DataTransferObject = new OrganizationApiKeyDto();
                response.DataTransferObject.AddDataErrorInfo(new DataErrorInfo("API Key already exists.", ErrorLevel.Error));
                return;
            }
            response.AggregateKey = organization.Key;
            request.DataTransferObject.ApiKey = CreateApiKey(organization.Key, organization.Name);
            var organizationApi = new OrganizationApiKey(organization.Name, request.DataTransferObject.ApiKey);
            organization.AddApiKey(request.DataTransferObject.ApiKey);
            response.DataTransferObject = Mapper.Map<OrganizationApiKey, OrganizationApiKeyDto>(organizationApi);
            response.DataTransferObject.Key = organization.Key;

            // send an email to the email for the EHR admin
            // TODO: Get this from the database. This is hard coded for DEMO
            var ehr = _ehrRepository.GetByKey(1);
            if (ehr != null && !string.IsNullOrWhiteSpace(ehr.EmailAddress))
            {
                SendApiEmail(ehr.Name, ehr.EmailAddress, organization.OrganizationKey, organization.Name, organization.ApiKey);
            }
        }

        private string CreateApiKey(long id, string orgName) {
            var secretKey = "secretkeyasam" + id + orgName;

            // Generate a new globally unique identifier for the salt
            var salt = Guid.NewGuid().ToString();

            // Initialize the keyed hash object using the secret key as the key
            var hashObject = new HMACSHA256(Encoding.UTF8.GetBytes(secretKey));

            // Computes the signature by hashing the salt with the secret key as the key
            var signature = hashObject.ComputeHash(Encoding.UTF8.GetBytes(salt));

            // Base 64 Encode
            var encodedSignature = Convert.ToBase64String(signature);
            return Regex.Replace(encodedSignature, "[^a-zA-Z0-9]", "").ToUpper();
        }

        private void SendApiEmail(string ehrName, string ehrEmailTo, long orgId, string orgName, string apiKey)
        {
            var emailTemplate = File.ReadAllText(HttpContext.Current.Server.MapPath("~/EmailTemplateASAM.html"));
            var body = string.Format(emailTemplate, ehrName, orgId, orgName, apiKey, "ASAM-PPC");
            var email = new EmailMessage();
            email.ToAddresses.Add(ehrEmailTo);
            email.IsHtml = true;
            email.Subject = "ASAM-PPC Organization API Key Setup";
            email.Body = body;
            _emailNotifier.Send(email);
        }

        #endregion
    }
}