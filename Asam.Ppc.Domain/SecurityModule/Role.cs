namespace Asam.Ppc.Domain.SecurityModule
{
    #region Using Statements

    using System;
    using System.Collections.Generic;
    using System.Linq;
    using CommonModule;
    using OrganizationModule;
    using Pillar.Common.Utility;
    using Pillar.Domain.Attributes;
    using Pillar.Security.AccessControl;

    #endregion

    /// <summary>
    ///     Role aggregate root.
    /// </summary>
    public class Role : AggregateRootBase, IOrganizationMember
    {
        #region Fields

        private readonly IList<RoleSystemPermission> _permissions = new List<RoleSystemPermission>();

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="Role" /> class.
        /// </summary>
        /// <param name="organization">The organization.</param>
        /// <param name="name">The name.</param>
        /// <param name="roleType">Type of the role.</param>
        public Role(Organization organization, string name, RoleType roleType)
        {
            if ( roleType != RoleType.Internal )
            {
                Check.IsNotNull ( organization, () => Organization );
            }
            Check.IsNotNullOrWhitespace(name, () => Name);

            Organization = organization;
            Name = name;
            RoleType = roleType;
        }

        internal Role()
        {
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets the organization key.
        /// </summary>
        /// <value>
        /// The organization key.
        /// </value>
        [IgnoreMapping]
        public virtual long OrganizationKey { get { return Organization.Key; } }

        /// <summary>
        ///     Gets the name.
        /// </summary>
        /// <value>
        ///     The name.
        /// </value>
        [NotNull]
        public virtual string Name { get; protected set; }

        /// <summary>
        ///     Gets the organization.
        /// </summary>
        /// <value>
        ///     The organization.
        /// </value>
        public virtual Organization Organization { get; protected set; }

        /// <summary>
        ///     Gets the permissions.
        /// </summary>
        /// <value>
        ///     The permissions.
        /// </value>
        public virtual IEnumerable<RoleSystemPermission> Permissions
        {
            get { return _permissions; }
        }

        /// <summary>
        /// Gets or sets the type of the role.
        /// </summary>
        /// <value>
        /// The type of the role.
        /// </value>
        [NotNull]
        public virtual RoleType RoleType { get; protected set; }

        #endregion

        #region Public Methods and Operators

        public virtual void ReviseName(string name)
        {
            Name = name;
        }

        /// <summary>
        ///     Adds the permision.
        /// </summary>
        /// <param name="permission">The permission.</param>
        public virtual void AddPermision(Permission permission)
        {
            _permissions.Add ( new RoleSystemPermission ( this, new SystemPermission(permission)) );
        }

        /// <summary>
        ///     Removes the permision.
        /// </summary>
        /// <param name="permission">The permission.</param>
        public virtual void RemovePermision(Permission permission)
        {
            var systemPermission = _permissions.FirstOrDefault ( sp => sp.SystemPermission.WellKnownName == permission.Name );
            if ( systemPermission != null )
            {
                _permissions.Remove(systemPermission);
            }
        }

        #endregion
    }
}