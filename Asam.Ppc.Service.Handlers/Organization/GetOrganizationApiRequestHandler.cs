namespace Asam.Ppc.Service.Handlers.Organization
{
    #region Using Statements

    using Common;
    using Infrastructure;
    using Messages.Common;
    using Messages.Organization;
    using Domain.OrganizationModule;

    #endregion

    public class GetOrganizationApiRequestHandler :
        ServiceRequestHandler<GetDtoByKeyRequest<OrganizationApiKeyDto>, DtoResponse<OrganizationApiKeyDto>>
    {
        private readonly IOrganizationRepository _organizationRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="GetOrganizationApiRequestHandler" /> class.
        /// </summary>
        /// <param name="organizationRepository">The organization repository.</param>
        public GetOrganizationApiRequestHandler(IOrganizationRepository organizationRepository)
        {
            _organizationRepository = organizationRepository;
        }

        #region Methods

        protected override void Handle(GetDtoByKeyRequest<OrganizationApiKeyDto> request, DtoResponse<OrganizationApiKeyDto> response)
        {
            var organizationKey = UserContext.OrganizationKey;
            if (UserContext.IsSystemAdmin)
            {
                organizationKey = request.Key;
            }
            var organization = _organizationRepository.GetByKey(organizationKey);
            var apiDto = new OrganizationApiKeyDto
            {
                ApiKey = organization.ApiKey,
                Name = organization.Name,
                Key = organization.Key
            };
            response.DataTransferObject = apiDto;
        }

        #endregion
    }
}