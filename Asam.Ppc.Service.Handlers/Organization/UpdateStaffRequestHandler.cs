namespace Asam.Ppc.Service.Handlers.Organization
{
    using Common;
    using Domain.OrganizationModule;
    using Messages.Common;
    using Messages.Organization;
    using Pillar.Domain.Primitives;
    using global::AutoMapper;

    public class UpdateStaffRequestHandler: ServiceRequestHandler<SaveDtoRequest<StaffDto>, DtoResponse<StaffDto> >
    {
        private readonly IStaffRepository _staffRepository;

        public UpdateStaffRequestHandler(IStaffRepository staffRepository)
        {
            _staffRepository = staffRepository;
        }

        protected override void Handle(SaveDtoRequest<StaffDto> request, DtoResponse<StaffDto> response)
        {
            var staff = _staffRepository.GetByKey(request.DataTransferObject.Key);

            staff.ReviseName(request.DataTransferObject.Name);
            staff.ReviseEmail(string.IsNullOrWhiteSpace(request.DataTransferObject.Email) ? null : new Email(request.DataTransferObject.Email));
            staff.ReviseLocation(request.DataTransferObject.Location);
            staff.ReviseNpi(request.DataTransferObject.NPI);

            response.DataTransferObject = Mapper.Map<Staff, StaffDto>(staff);
        }
    }
}