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
    using Pillar.Domain.Primitives;

    #endregion

    /// <summary>
    ///     System account aggregate.
    /// </summary>
    public class SystemAccount : AggregateRootBase, IOrganizationMember
    {
        private readonly IList<SystemAccountRole> _roles = new List<SystemAccountRole>();

        #region Constructors and Destructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="SystemAccount" /> class.
        /// </summary>
        /// <param name="organization">The organization.</param>
        /// <param name="identifier">The identifier.</param>
        /// <param name="email">The email.</param>
        internal SystemAccount(Organization organization, string identifier, Email email)
        {
            Check.IsNotNull ( organization, () => Organization );
            Check.IsNotNullOrWhitespace(identifier, () => Identifier);

            Organization = organization;
            Identifier = identifier;
            Email = email;
        }

        internal SystemAccount ( string identifier, Email email )
        {
            Identifier = identifier;
            Email = email;
            IsSystemAdmin = true;
        }

        internal SystemAccount()
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
        ///     Gets the identifier.
        /// </summary>
        /// <value>
        ///     The identifier.
        /// </value>
        [NotNull]
        [ColumnLength(255)]
        public virtual string Identifier { get; protected set; }

        /// <summary>
        ///     Gets the organization.
        /// </summary>
        /// <value>
        ///     The organization.
        /// </value>
        public virtual Organization Organization { get; protected set; }

        /// <summary>
        ///     Gets the email.
        /// </summary>
        /// <value>
        ///     The email.
        /// </value>
        public virtual Email Email { get; protected set; }

        /// <summary>
        ///     Gets the staff.
        /// </summary>
        /// <value>
        ///     The staff.
        /// </value>
        public virtual Staff Staff { get; protected set; }

        /// <summary>
        ///     Gets the role.
        /// </summary>
        /// <value>
        ///     The role.
        /// </value>
        public virtual IEnumerable<SystemAccountRole> Roles
        {
            get { return _roles; }
        }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is system admin.
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance is system admin; otherwise, <c>false</c>.
        /// </value>
        [NotNull]
        public virtual bool IsSystemAdmin { get; protected set; }

        /// <summary>
        /// Gets or sets the last login.
        /// </summary>
        /// <value>
        /// The last login.
        /// </value>
        public virtual DateTime? LastLogin { get; protected set; }

        /// <summary>
        /// Gets or sets the EULA date signed.
        /// </summary>
        /// <value>
        /// The EULA date signed.
        /// </value>
        public virtual DateTime? EulaAgreeDate { get; protected set; }

        #endregion

        public virtual void LoggedIn ()
        {
            LastLogin = DateTime.Now;
        }

        public virtual void AddRole(Role role)
        {
            _roles.Add ( new SystemAccountRole(this, role) );
        }

        public virtual void RemoveRole(Role role)
        {
            var systemAccountRole = Roles.FirstOrDefault ( sar => sar.Role.Key == role.Key );
            if ( systemAccountRole != null )
            {
                _roles.Remove ( systemAccountRole );
            }
        }

        public virtual void RemoveRole(SystemAccountRole systemAccountRole)
        {
            if (systemAccountRole != null)
            {
                _roles.Remove(systemAccountRole);
            }
        }

        public virtual void AssignToStaff(Staff staff)
        {
            Staff = staff;
        }

        public virtual void ReviseEulaSignDate(DateTime? signedDate)
        {
            EulaAgreeDate = signedDate;
        }
    }
}