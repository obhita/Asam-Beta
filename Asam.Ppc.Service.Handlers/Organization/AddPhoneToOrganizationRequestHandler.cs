namespace Asam.Ppc.Service.Handlers.Organization
{
    #region Using Statements

    using System.Linq;
    using Common;
    using Domain.CommonModule;
    using Domain.CommonModule.ValueObjects;
    using Domain.OrganizationModule;
    using Infrastructure;
    using Messages.Common;
    using Messages.Organization;
    using global::AutoMapper;

    #endregion

    /// <summary>
    ///     Handler for request to add <see cref="Phone" /> to <see cref="Asam.Ppc.Service.Handlers.Organization" />.
    /// </summary>
    public class AddPhoneToOrganizationRequestHandler :
        ServiceRequestHandler<AddDtoRequest<OrganizationPhoneDto>, AddDtoResponse<OrganizationPhoneDto>>
    {
        private readonly IOrganizationRepository _organizationRepository;

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="AddPhoneToOrganizationRequestHandler" /> class.
        /// </summary>
        /// <param name="organizationRepository">The organization repository.</param>
        public AddPhoneToOrganizationRequestHandler ( IOrganizationRepository organizationRepository )
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
        protected override void Handle(AddDtoRequest<OrganizationPhoneDto> request, AddDtoResponse<OrganizationPhoneDto> response)
        {
            var organization = _organizationRepository.GetByKey(UserContext.IsSystemAdmin ? request.AggregateKey : UserContext.OrganizationKey);
            var originalPhone = organization.OrganizationPhones.FirstOrDefault(p => p.Key == request.DataTransferObject.OriginalHash); 
            var organizationPhoneType = Lookup.Find<OrganizationPhoneType>(request.DataTransferObject.OrganizationPhoneType.Code);
            var phone = new Phone(request.DataTransferObject.Phone.Number, request.DataTransferObject.Phone.Extension);

            var organizationPhone = new OrganizationPhone(organizationPhoneType, phone, request.DataTransferObject.IsPrimary);
            if (originalPhone != organizationPhone)
            {
                if ( originalPhone != null )
                {
                    organization.RemovePhone ( originalPhone );
                }
                organization.AddPhone ( organizationPhone );
            }
            else if ( organizationPhone.IsPrimary )
            {
                organization.MakePrimary ( organizationPhone );
            }

            response.AggregateKey = organization.Key;
            response.DataTransferObject = Mapper.Map<OrganizationPhone, OrganizationPhoneDto>(organizationPhone);
            response.DataTransferObject.Key = organization.Key;
        }

        #endregion
    }
}