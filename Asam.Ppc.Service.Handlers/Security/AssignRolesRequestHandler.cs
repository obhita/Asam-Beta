namespace Asam.Ppc.Service.Handlers.Security
{
    using System.Linq;
    using Common;
    using Domain.SecurityModule;
    using Messages.Security;

    public class AssignRolesRequestHandler : ServiceRequestHandler<AssignRolesRequest, AssignRolesResponse>
    {
        private readonly ISystemAccountRepository _systemAccountRepository;
        private readonly IRoleRepository _roleRepository;

        public AssignRolesRequestHandler(ISystemAccountRepository systemAccountRepository, IRoleRepository roleRepository )
        {
            _systemAccountRepository = systemAccountRepository;
            _roleRepository = roleRepository;
        }

        protected override void Handle(AssignRolesRequest request, AssignRolesResponse response)
        {
            var systemAccount = _systemAccountRepository.GetByKey(request.SystemAccoutnKey);

            if (systemAccount != null)
            {
                if (request.AddRoles)
                {
                    foreach (var role in _roleRepository.GetByKeys(request.Roles.ToArray()))
                    {
                        systemAccount.AddRole(role);
                    }
                }
                else
                {
                    foreach (var role in systemAccount.Roles.Where ( r => request.Roles.Contains ( r.Role.Key ) ).ToList ())
                    {
                        systemAccount.RemoveRole(role);
                    }
                }
            }
        }
    }
}