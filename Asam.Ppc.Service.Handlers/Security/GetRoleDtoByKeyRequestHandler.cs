namespace Asam.Ppc.Service.Handlers.Security
{
    #region

    using System.Linq;
    using Common;
    using Domain.SecurityModule;
    using Messages.Common;
    using Messages.Security;
    using global::AutoMapper;

    #endregion

    public class GetRoleDtoByKeyRequestHandler : ServiceRequestHandler<GetRoleDtoByKeyRequest, DtoResponse<RoleDto>>
    {
        private readonly IRoleRepository _roleRepository;

        public GetRoleDtoByKeyRequestHandler(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }

        protected override void Handle(GetRoleDtoByKeyRequest request, DtoResponse<RoleDto> response)
        {
            var role = _roleRepository.GetByKey(request.Key);
            if (role != null)
            {
                var roleDto = Mapper.Map<Role, RoleDto>(role);
                roleDto.Permissions = roleDto.Permissions.OrderBy(p => p);
                response.DataTransferObject = roleDto;
            }
        }
    }
}