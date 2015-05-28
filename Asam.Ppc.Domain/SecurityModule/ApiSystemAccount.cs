namespace Asam.Ppc.Domain.SecurityModule
{
    #region Using Statements

    using System;
    using CommonModule;
    using OrganizationModule;
    using Pillar.Common.Utility;
    using Pillar.Domain.Attributes;
    using Pillar.Domain.Primitives;

    #endregion

    /// <summary>
    ///     System account aggregate.
    /// </summary>
    public class ApiSystemAccount : AggregateRootBase
    {
        #region Constructors and Destructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="ApiSystemAccount" /> class.
        /// </summary>
        /// <param name="ehrId"></param>
        /// <param name="organizationKey"></param>
        /// <param name="userId"></param>
        /// <param name="userName"></param>
        /// <param name="userEmail"></param>
        public ApiSystemAccount(
            long ehrId, 
            long organizationKey, 
            string userId, 
            string userName, 
            string userEmail)
        {
            OrganizationKey = organizationKey;
            UserEmail = userEmail;
            UserId = userId;
            UserName = userName;
            EhrId = ehrId;
        }

        internal ApiSystemAccount()
        {
        }

        #endregion

        #region Public Properties

        /// <summary>
        ///     Gets the ApiSystemAccountKey.
        /// </summary>
        /// <value>
        ///     The ApiSystemAccountKey.
        /// </value>
        [IgnoreMapping]
        public virtual long ApiSystemAccountKey { get { return Key; } }

        /// <summary>
        /// Gets the organization key.
        /// </summary>
        /// <value>
        /// The organization key.
        /// </value>
        [NotNull]
        public virtual long OrganizationKey { get; protected set; }

        /// <summary>
        ///     Gets the ehrId.
        /// </summary>
        /// <value>
        ///     The ehrId.
        /// </value>
         [NotNull]
        public virtual long EhrId { get; protected set; }

        /// <summary>
        ///     Gets the UserEmail.
        /// </summary>
        /// <value>
        ///     The UserEmail.
        /// </value>
        public virtual string UserEmail { get; protected set; }

        /// <summary>
        ///     Gets the UserId.
        /// </summary>
        /// <value>
        ///     The UserId.
        /// </value>
        public virtual string UserId{ get; protected set; }

        /// <summary>
        ///     Gets the UserName.
        /// </summary>
        /// <value>
        ///     The UserName.
        /// </value>
        public virtual string UserName { get; protected set; }

        /// <summary>
        /// Gets or sets the EULA date signed.
        /// </summary>
        /// <value>
        /// The EULA date signed.
        /// </value>
        public virtual DateTime? EulaAgreeDate { get; protected set; }

        #endregion

        public virtual void ReviseEulaSignDate(DateTime? signedDate)
        {
            EulaAgreeDate = signedDate;
        }
    }
}