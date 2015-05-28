namespace Asam.Ppc.Service.Handlers.Organization
{
    #region Using Statements

    using Common;
    using Infrastructure;
    using Messages.Common;
    using Messages.Organization;
    using Domain.OrganizationModule;
    using global::AutoMapper;

    #endregion

    /// <summary>
    ///     Get <see cref="Organization" /> summary request handler.
    /// </summary>
    public class GetOrganizationSummaryRequestHandler :
        ServiceRequestHandler<GetDtoByKeyRequest<OrganizationSummaryDto>, DtoResponse<OrganizationSummaryDto>>
    {
        private readonly IOrganizationRepository _organizationRepository;

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="GetOrganizationSummaryRequestHandler" /> class.
        /// </summary>
        /// <param name="organizationRepository">The organization repository.</param>
        public GetOrganizationSummaryRequestHandler ( IOrganizationRepository organizationRepository )
        {
            _organizationRepository = organizationRepository;
        }

        #endregion

        #region Methods

        /// <summary>
        ///     Handles the specified request.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <param name="response">The response.</param>
        protected override void Handle ( GetDtoByKeyRequest<OrganizationSummaryDto> request, DtoResponse<OrganizationSummaryDto> response )
        {
            var organization = _organizationRepository.GetByKey ( UserContext.OrganizationKey );
            response.DataTransferObject = Mapper.Map<Organization, OrganizationSummaryDto> ( organization );
        }

        #endregion
    }
}