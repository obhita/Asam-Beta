namespace Asam.Ppc.Service.Handlers.Security
{
    #region

    using Common;
    using Domain.SecurityModule;
    using Messages.Security;
    using Pillar.Security.AccessControl;

    #endregion

    public class AssignPermissionRequestHandler : ServiceRequestHandler<AssignPermissionRequest, AssignPermissionResponse>
    {
        private readonly IRoleRepository _roleRepository;

        public AssignPermissionRequestHandler(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }

        protected override void Handle(AssignPermissionRequest request, AssignPermissionResponse response)
        {
            var role = _roleRepository.GetByKey(request.Key);
            if (role != null)
            {
                if (request.Add)
                {
                    foreach (var permission in request.Permissions)
                    {
                        role.AddPermision(new Permission {Name = permission});
                    }
                }
                else
                {
                    foreach (var permission in request.Permissions)
                    {
                        role.RemovePermision(new Permission {Name = permission});
                    }
                }
            }
        }
    }
}