namespace Asam.Ppc.Mvc4.PermissionDescriptor
{
    using System.Web.Mvc;
    using Controllers;
    using Infrastructure.Permission;
    using Pillar.Security.AccessControl;

    public class SingleSignOnPermissionDescriptor : IInternalPermissionDescriptor
    {
        #region Fields

        private readonly ResourceList _resourceList = new ResourceListBuilder()
            .AddResource<SingleSignOnController>(SingleSignOnPermission.SingleSignOnViewPermission,
                rlb => rlb.AddResource("Index",
                    SingleSignOnPermission.SingleSignOnViewPermission,
                    innerrlb =>
                        innerrlb.AddResource(
                            HttpVerbs.Post.ToString().ToUpper(),
                            SingleSignOnPermission.SingleSignOnViewPermission)));

        #endregion

        #region Public Properties

        public ResourceList Resources
        {
            get { return _resourceList; }
        }

        public bool IsInternal { get { return false; } }

        #endregion
    }
}