namespace Asam.Ppc.Infrastructure.Permission
{
    using Pillar.Security.AccessControl;

    public class SingleSignOnPermission
    {
        #region Static Fields

        /// <summary>
        ///     The index view permission
        /// </summary>
        public static Permission SingleSignOnViewPermission = new Permission {Name = "singlesignonmodule/singlesignonview"};

        #endregion
    }
}