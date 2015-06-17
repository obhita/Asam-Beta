namespace Asam.Ppc.Infrastructure.Permission
{
    using Pillar.Security.AccessControl;

    public class AssessmentPermission
    {
        #region Static Fields

        /// <summary>
        ///     The assessment edit permission
        /// </summary>
        public static Permission AssessmentEditPermission = new Permission {Name = "assessmentmodule/assessmentedit"};

        /// <summary>
        ///     The assessment view permission
        /// </summary>
        public static Permission AssessmentViewPermission = new Permission { Name = "assessmentmodule/assessmentview" };

        #endregion
    }
}