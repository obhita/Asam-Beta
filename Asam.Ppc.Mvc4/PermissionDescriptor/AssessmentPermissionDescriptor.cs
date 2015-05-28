namespace Asam.Ppc.Mvc4.PermissionDescriptor
{
    using System.Web.Mvc;
    using Controllers;
    using Infrastructure.Permission;
    using Pillar.Security.AccessControl;

    public class AssessmentPermissionDescriptor : IInternalPermissionDescriptor
    {
        #region Fields

        private readonly ResourceList _resourceList = new ResourceListBuilder ()
            .AddResource<AssessmentController> ( AssessmentPermission.AssessmentViewPermission,
                                                 rlb => rlb.AddResource ( "Edit",
                                                                          AssessmentPermission.AssessmentViewPermission,
                                                                          innerrlb =>
                                                                          innerrlb.AddResource (
                                                                                                HttpVerbs.Post.ToString ().ToUpper (),
                                                                                                AssessmentPermission.AssessmentEditPermission ) )
                                                           .AddResource( "CreateForPatientId",
                                                                          AssessmentPermission.AssessmentEditPermission ) )
            .AddResource<SectionController>(AssessmentPermission.AssessmentViewPermission,
                                                 rlb => rlb.AddResource("Edit",
                                                                          AssessmentPermission.AssessmentViewPermission,
                                                                          innerrlb =>
                                                                          innerrlb.AddResource(
                                                                                                HttpVerbs.Post.ToString().ToUpper(),
                                                                                                AssessmentPermission.AssessmentEditPermission))
                                                           .AddResource("Submit",
                                                                          AssessmentPermission.AssessmentEditPermission));


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