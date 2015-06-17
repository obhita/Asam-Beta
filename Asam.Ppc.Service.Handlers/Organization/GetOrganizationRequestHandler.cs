namespace Asam.Ppc.Service.Handlers.Organization
{
    #region Using Statements

    using Common;
    using Infrastructure;
    using Messages.Common;
    using Messages.Organization;
    using Domain.OrganizationModule;
    using System.Linq;
    using global::AutoMapper;

    #endregion

    public class GetOrganizationRequestHandler :
        ServiceRequestHandler<GetDtoByKeyRequest<OrganizationDto>, DtoResponse<OrganizationDto>>
    {
        private readonly IOrganizationRepository _organizationRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="GetOrganizationRequestHandler" /> class.
        /// </summary>
        /// <param name="organizationRepository">The organization repository.</param>
        public GetOrganizationRequestHandler ( IOrganizationRepository organizationRepository )
        {
            _organizationRepository = organizationRepository;
        }

        #region Methods

        /// <summary>
        ///     Handles the specified request.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <param name="response">The response.</param>
        protected override void Handle ( GetDtoByKeyRequest<OrganizationDto> request, DtoResponse<OrganizationDto> response )
        {
            var organizationKey = UserContext.OrganizationKey;
            if ( UserContext.IsSystemAdmin )
            {
                organizationKey = request.Key;
            }
            var organization = _organizationRepository.GetByKey ( organizationKey );
            response.DataTransferObject = Mapper.Map<Organization, OrganizationDto> ( organization );
        }

        #endregion
    }
}