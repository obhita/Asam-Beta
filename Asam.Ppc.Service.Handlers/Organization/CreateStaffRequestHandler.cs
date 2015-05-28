namespace Asam.Ppc.Service.Handlers.Organization
{
    #region

    using Common;
    using Domain.OrganizationModule;
    using Infrastructure;
    using Messages.Organization;
    using global::AutoMapper;

    #endregion
    
    public class CreateStaffRequestHandler : ServiceRequestHandler<CreateStaffRequest, GetStaffDtoResponse>
    {
        private readonly IOrganizationRepository _organizationRepository;
        private readonly IStaffFactory _staffFactory;

        public CreateStaffRequestHandler (IOrganizationRepository organizationRepository, IStaffFactory staffFactory)
        {
            _organizationRepository = organizationRepository;
            _staffFactory = staffFactory;
        }

        protected override void Handle(CreateStaffRequest request, GetStaffDtoResponse response)
        {
            var organization = _organizationRepository.GetByKey ( UserContext.OrganizationKey );
            var staff = _staffFactory.Create(organization, request.Name);
            if (staff != null)
            {
                var staffDto = Mapper.Map<Staff, StaffDto>(staff);
                response.DataTransferObject = staffDto;
            }
        }
    }
}