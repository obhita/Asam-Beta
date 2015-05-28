using System;
using System.Collections.Generic;
using Asam.Ppc.Domain.OrganizationModule;

namespace Asam.Ppc.Domain.EhrModule
{
    #region Using Statements

    using CommonModule;
    using Pillar.Common.Utility;
    using Pillar.Domain.Attributes;

    #endregion

    /// <summary>
    ///     Ehr aggregate root.
    /// </summary>
    public class Ehr : AggregateRootBase
    {
        #region Fields

        private readonly IList<Organization> _organizations = new List<Organization>();

        #endregion

        #region Constructors and Destructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="Ehr" /> class.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="signingCertName">The signingCertName.</param>
        /// <param name="emailAddress">The emailAddress.</param>
        public Ehr(string name, string signingCertName, string emailAddress)
        {
            Name = name;
            SigningCertName = signingCertName;
            EmailAddress = emailAddress;
        }

        internal Ehr()
        {
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets the Ehr key.
        /// </summary>
        /// <value>
        /// The Ehr key.
        /// </value>
        [IgnoreMapping]
        public virtual long EhrKey { get { return Key; } }

        /// <summary>
        ///     Gets the name.
        /// </summary>
        /// <value>
        ///     The name.
        /// </value>
        [NotNull]
        public virtual string Name { get; protected set; }

        /// <summary>
        ///     Gets the SigningCertName.
        /// </summary>
        /// <value>
        ///     The SigningCertName.
        /// </value>
        [NotNull]
        public virtual string SigningCertName { get; protected set; }

        /// <summary>
        ///     Gets the EmailAddress.
        /// </summary>
        /// <value>
        ///     The EmailAddress.
        /// </value>
        [NotNull]
        public virtual string EmailAddress { get; protected set; }

        /// <summary>
        ///     Gets the SystemAccountKey.
        /// </summary>
        /// <value>
        ///     The SystemAccountKey.
        /// </value>
        public virtual long? SystemAccountKey { get; protected set; }

        /// <summary>
        ///     Gets the DeactivatedDate.
        /// </summary>
        /// <value>
        ///     The DeactivatedDate.
        /// </value>
        public virtual DateTime? DeactivatedDate {get; protected set; }

      
        /// <summary>
        ///     Gets the list of organizations.
        /// </summary>
        /// <value>
        ///     The list of organizations.
        /// </value>
        public virtual IEnumerable<Organization> Organizations
        {
            get { return _organizations; }
        }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        ///     Adds an organization.
        /// </summary>
        /// <param name="organization">The organization.</param>
        public virtual void AddOrganization(Organization organization)
        {
            _organizations.Add(organization);
        }

        /// <summary>
        ///     Removes an organization.
        /// </summary>
        /// <param name="organization">The organization.</param>
        public virtual void RemoveOrganization(Organization organization)
        {
            if (_organizations.Contains(organization))
            {
                _organizations.Remove(organization);
            }
        }

        public virtual void ReviseName(string name)
        {
            Check.IsNotNullOrWhitespace ( name, () => Name );

            Name = name;
        }

        public virtual void ReviseSigningCertName(string signingCertName)
        {
            Check.IsNotNullOrWhitespace(signingCertName, () => signingCertName);

            SigningCertName = signingCertName;
        }

        public virtual void ReviseEmailAddress(string emailAddress)
        {
            Check.IsNotNullOrWhitespace(emailAddress, () => emailAddress);

            EmailAddress = emailAddress;
        }

        public virtual void ReviseDeactivatedDate(DateTime? deactivatedDate)
        {
            DeactivatedDate = deactivatedDate;
        }

        public virtual void ReviseSystemAccountKey(long? systemAccountKey)
        {
            SystemAccountKey = systemAccountKey;
        }

        #endregion
    }
}