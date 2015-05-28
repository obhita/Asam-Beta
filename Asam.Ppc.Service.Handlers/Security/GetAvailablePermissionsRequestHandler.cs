namespace Asam.Ppc.Service.Handlers.Security
{
    using System.Linq;
    using Common;
    using Domain.SecurityModule;
    using Infrastructure.Services;
    using Messages.Security;

    public class GetAvailablePermissionsRequestHandler : ServiceRequestHandler<GetAvailablePermissionsRequest, GetAvailablePermissionsResponse>
    {
        private readonly IRoleRepository _roleRepository;
        private readonly IProvidePermissions _permissionsProvider;

        public GetAvailablePermissionsRequestHandler (IRoleRepository roleRepository, IProvidePermissions permissionsProvider)
        {
            _roleRepository = roleRepository;
            _permissionsProvider = permissionsProvider;
        }

        protected override void Handle ( GetAvailablePermissionsRequest request, GetAvailablePermissionsResponse response )
        {
            var role = _roleRepository.GetByKey ( request.Key );
            if ( role.Permissions == null || !role.Permissions.Any () )
            {
                response.Permissions = _permissionsProvider.Permissions.Select ( p => p.Name ).ToList ();
            }
            else
            {
                response.Permissions = _permissionsProvider.Permissions.Where ( p => role.Permissions.All ( sp => sp.SystemPermission.WellKnownName != p.Name ) ).Select ( p => p.Name ).ToList ();
            }
            if ( response.Permissions == null )
            {
                response.Permissions = Enumerable.Empty<string> ();
            }
        }
    }
}
