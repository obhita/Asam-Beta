namespace Asam.Ppc.Infrastructure.Services
{
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using Permission;
    using Pillar.Security.AccessControl;

    public class AsamAccessControlManager : AccessControlManager, IProvidePermissions, IAccessControlManager
    {
        private readonly List<Permission> _permissions = new List<Permission> (); 

        public AsamAccessControlManager ( ICurrentUserPermissionService currentUserPermissionService )
            : base ( currentUserPermissionService )
        {
        }

        public IReadOnlyCollection<Permission> Permissions { get { return new ReadOnlyCollection<Permission> (_permissions);} }

        void IAccessControlManager.RegisterPermissionDescriptor ( params IPermissionDescriptor[] permissionDescriptors )
        {
            var publicPermissionDescritpors = permissionDescriptors.OfType<IInternalPermissionDescriptor>().Where(pd => !pd.IsInternal).ToList ();
            _permissions.AddRange(publicPermissionDescritpors.SelectMany(pd => pd.Resources.Select(r => r.Permission)).Distinct());
            foreach (var resource in publicPermissionDescritpors.SelectMany(permissionDescriptor => (List<Resource>)permissionDescriptor.Resources))
            {
                GetAllPermissionHelper ( resource );
            }
            base.RegisterPermissionDescriptor ( permissionDescriptors );
        }

        private void GetAllPermissionHelper ( Resource resource )
        {
            if ( !_permissions.Contains ( resource.Permission ) )
            {
                _permissions.Add ( resource.Permission );
            }
            if ( resource.Resources != null )
            {
                foreach ( var r in resource.Resources )
                {
                    GetAllPermissionHelper ( r );
                }
            }
        }
    }
}
