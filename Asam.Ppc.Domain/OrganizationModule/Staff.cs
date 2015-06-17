namespace Asam.Ppc.Domain.OrganizationModule
{
    #region Using Statements

    using System.Collections.Generic;
    using System.Reflection;
    using CommonModule;
    using Pillar.Common.Utility;
    using Pillar.Domain.Attributes;
    using Pillar.Domain.Primitives;
    using Primitives;

    #endregion

    /// <summary>
    ///     Staff aggregate
    /// </summary>
    public class Staff : AggregateRootBase, IOrganizationMember
    {

        private static Dictionary<string, PropertyInfo> _propertyCache;

        #region Constructors and Destructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="Staff" /> class.
        /// </summary>
        /// <param name="organization">The organization.</param>
        /// <param name="name">The name.</param>
        public Staff ( Organization organization, PersonName name )
        {
            Check.IsNotNull ( name, () => Name );

            Organization = organization;
            Name = name;
        }

        internal Staff()
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
        ///     Gets the email.
        /// </summary>
        /// <value>
        ///     The email.
        /// </value>
        public virtual Email Email { get; protected set; }

        /// <summary>
        ///     Gets the location.
        /// </summary>
        /// <value>
        ///     The location.
        /// </value>
        public virtual string Location { get; protected set; }

        /// <summary>
        ///     Gets the name.
        /// </summary>
        /// <value>
        ///     The name.
        /// </value>
        [NotNull]
        public virtual PersonName Name { get; protected set; }

        /// <summary>
        ///     Gets the organization.
        /// </summary>
        /// <value>
        ///     The organization.
        /// </value>
        [NotNull]
        public virtual Organization Organization { get; protected set; }


        /// <summary>
        ///     Gets the National Practive Id.
        /// </summary>
        /// <value> 
        ///     The NPI number.
        /// </value>
        public virtual string NPI { get; protected set; }

        #endregion

        public virtual void ReviseName(PersonName name)
        {
            Check.IsNotNull(name, () => Name);
            Name = name;
        }

        public virtual void ReviseEmail(Email email)
        {
            Email = email;
        }

        public virtual void ReviseLocation(string location)
        {
            Location = location;
        }

        public virtual void ReviseNpi(string npi)
        {
            NPI = npi;
        }
    }
}