namespace Asam.Ppc.Domain.SecurityModule
{
    using Pillar.Common.Utility;
    using Pillar.Domain;
    using Pillar.Domain.Attributes;

    public class RoleSystemPermission : Entity
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RoleSystemPermission"/> class.
        /// </summary>
        protected RoleSystemPermission()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RoleSystemPermission"/> class.
        /// </summary>
        /// <param name="role">The system role.</param>
        /// <param name="systemPermission">The system permission.</param>
        protected internal RoleSystemPermission(Role role, SystemPermission systemPermission)
        {
            Check.IsNotNull ( role, "System role is required." );
            Check.IsNotNull ( systemPermission, "System permission is required." );

            Role = role;
            SystemPermission = systemPermission;
        }

        /// <summary>
        /// Gets the system role.
        /// </summary>
        public virtual Role Role { get; protected set; }

        /// <summary>
        /// Gets the system permission.
        /// </summary>
        public virtual SystemPermission SystemPermission { get; protected set; }
    }
}
