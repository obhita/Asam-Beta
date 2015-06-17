namespace Asam.Ppc.Mvc4.PermissionDescriptor
{
    using Controllers;
    using Infrastructure.Permission;
    using Pillar.Security.AccessControl;

    public class SystemAdminPermissionDescriptor : IInternalPermissionDescriptor
    {
        #region Fields

        private readonly ResourceList _resourceList = new ResourceListBuilder()
            .AddResource<SystemAdminController>(SystemAdministrationPermission.SystemAdminPermission);

        #endregion

        #region Public Properties

        public ResourceList Resources
        {
            get { return _resourceList; }
        }

        public bool IsInternal { get { return true; } }

        #endregion
    }
}