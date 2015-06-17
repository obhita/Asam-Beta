namespace Asam.Ppc.Service.Handlers.Organization
{
    using Common;
    using Domain.OrganizationModule;
    using Messages.Common;
    using Messages.Organization;
    using global::AutoMapper;

    public class CreateOrganizationRequestHandler :
        ServiceRequestHandler<CreateOrganizationRequest, DtoResponse<OrganizationSummaryDto>>
    {
        private readonly IOrganizationFactory _organizationFactory;

        public CreateOrganizationRequestHandler (IOrganizationFactory organizationFactory)
        {
            _organizationFactory = organizationFactory;
        }

        #region Methods

        /// <summary>
        ///     Handles the specified request.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <param name="response">The response.</param>
        protected override void Handle(CreateOrganizationRequest request, DtoResponse<OrganizationSummaryDto> response)
        {
            var organization = _organizationFactory.Create ( request.Name );
            response.DataTransferObject = Mapper.Map<Organization, OrganizationSummaryDto>(organization);
        }

        #endregion
    }
}