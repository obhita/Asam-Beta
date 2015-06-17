namespace Asam.Ppc.Domain.OrganizationModule
{
    #region Using Statements

    using System.Collections.Generic;
    using System.Linq;
    using CommonModule;
    using Pillar.Common.Utility;
    using Pillar.Domain.Attributes;

    #endregion

    /// <summary>
    ///     Organization aggregate root.
    /// </summary>
    public class Organization : AggregateRootBase, IOrganizationMember
    {
        #region Fields

        private readonly IList<OrganizationAddress> _organizationAddresses = new List<OrganizationAddress> ();
        private readonly IList<OrganizationPhone> _organizationPhones = new List<OrganizationPhone> ();

        #endregion

        #region Constructors and Destructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="Organization" /> class.
        /// </summary>
        /// <param name="name">The name.</param>
        public Organization ( string name )
        {
            Name = name;
        }

        internal Organization ()
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
        public virtual long OrganizationKey { get { return Key; } }

        /// <summary>
        ///     Gets the name.
        /// </summary>
        /// <value>
        ///     The name.
        /// </value>
        [NotNull]
        public virtual string Name { get; protected set; }

        /// <summary>
        ///     Gets the organization addresses.
        /// </summary>
        /// <value>
        ///     The organization addresses.
        /// </value>
        public virtual IEnumerable<OrganizationAddress> OrganizationAddresses
        {
            get { return _organizationAddresses; }
        }

        /// <summary>
        ///     Gets the organization phones.
        /// </summary>
        /// <value>
        ///     The organization phones.
        /// </value>
        public virtual IEnumerable<OrganizationPhone> OrganizationPhones
        {
            get { return _organizationPhones; }
        }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        ///     Adds the address.
        /// </summary>
        /// <param name="organizationAddress">The organization address.</param>
        public virtual void AddAddress(OrganizationAddress organizationAddress)
        {
            _organizationAddresses.Add ( organizationAddress );
            if (organizationAddress.IsPrimary)
            {
                MakePrimary(organizationAddress);
            }
        }

        /// <summary>
        ///     Adds the phone.
        /// </summary>
        /// <param name="organizationPhone">The organization phone.</param>
        public virtual void AddPhone(OrganizationPhone organizationPhone)
        {
            _organizationPhones.Add ( organizationPhone );
            if (organizationPhone.IsPrimary)
            {
                MakePrimary ( organizationPhone );
            }
        }

        public virtual void MakePrimary(OrganizationAddress organizationAddress)
        {
            Check.IsNotNull ( organizationAddress, "organizationAddress is required." );
            var currentPrimary = OrganizationAddresses.FirstOrDefault ( oa => oa.IsPrimary );
            if ( currentPrimary != organizationAddress )
            {
                currentPrimary.IsPrimary = false;
                organizationAddress.IsPrimary = true;
            }
        }

        public virtual void MakePrimary(OrganizationPhone organizationPhone)
        {
            Check.IsNotNull(organizationPhone, "organizationPhone is required.");
            var currentPrimary = OrganizationPhones.FirstOrDefault(oa => oa.IsPrimary);
            if (currentPrimary != organizationPhone)
            {
                currentPrimary.IsPrimary = false;
                organizationPhone.IsPrimary = true;
            }
        }

        /// <summary>
        ///     Removes the address.
        /// </summary>
        /// <param name="organizationAddress">The organization address.</param>
        public virtual void RemoveAddress(OrganizationAddress organizationAddress)
        {
            if ( _organizationAddresses.Contains ( organizationAddress ) )
            {
                _organizationAddresses.Remove ( organizationAddress );
            }
        }

        /// <summary>
        ///     Removes the phone.
        /// </summary>
        /// <param name="organizationPhone">The organization phone.</param>
        public virtual void RemovePhone(OrganizationPhone organizationPhone)
        {
            if ( _organizationPhones.Contains ( organizationPhone ) )
            {
                _organizationPhones.Remove ( organizationPhone );
            }
        }


        public virtual void ReviseName(string name)
        {
            Check.IsNotNullOrWhitespace ( name, () => Name );

            Name = name;
        }

        #endregion
    }
}