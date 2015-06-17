namespace Asam.Ppc.Domain.SecurityModule
{
    using Pillar.Domain;
    using Pillar.Security.AccessControl;

    /// <summary>
    /// Class that defines permission.
    /// </summary>
    public class SystemPermission : Entity
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SystemPermission" /> class.
        /// </summary>
        /// <param name="permission">The permission.</param>
        public SystemPermission (Permission permission)
        {
            WellKnownName = permission.Name;
        }

        internal SystemPermission ()
        {}

        /// <summary>
        /// Gets the name of the well known.
        /// </summary>
        /// <value>
        /// The name of the well known.
        /// </value>
        public virtual string WellKnownName { get; protected set; }
    }
}
