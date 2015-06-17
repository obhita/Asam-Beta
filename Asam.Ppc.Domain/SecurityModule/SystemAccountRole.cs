namespace Asam.Ppc.Domain.SecurityModule
{
    #region Using Statements

    using Pillar.Domain;
    using Pillar.Domain.Attributes;

    #endregion

    /// <summary>
    ///     System Account Role Entity.
    /// </summary>
    public class SystemAccountRole : Entity
    {
        #region Constructors and Destructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="SystemAccountRole" /> class.
        /// </summary>
        /// <param name="systemAccount">The system account.</param>
        /// <param name="role">The role.</param>
        protected internal SystemAccountRole ( SystemAccount systemAccount, Role role )
        {
            SystemAccount = systemAccount;
            Role = role;
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="SystemAccountRole" /> class.
        /// </summary>
        protected SystemAccountRole ()
        {}

        #endregion

        #region Public Properties

        /// <summary>
        ///     Gets or sets the role.
        /// </summary>
        /// <value>
        ///     The role.
        /// </value>
        public virtual Role Role { get; protected set; }

        /// <summary>
        ///     Gets or sets the system account.
        /// </summary>
        /// <value>
        ///     The system account.
        /// </value>
        public virtual SystemAccount SystemAccount { get; protected set; }

        #endregion
    }
}