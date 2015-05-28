using Asam.Ppc.Domain.CommonModule;
using Pillar.Common.Metadata;
using Pillar.Domain.Attributes;

namespace Asam.Ppc.Domain.BillingModule
{
    #region Using Statements

    

    #endregion

    /// <summary>
    /// BillingTransaction aggregate root
    /// </summary>
    public class BillingTransaction : AggregateRootBase
    {
        #region Fields


        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="BillingTransaction" /> class.
        /// </summary>
        /// <param name="ehrKey">The ehr key.</param>
        /// <param name="organizationKey">The organization key.</param>
        /// <param name="userEmail">The user email.</param>
        /// <param name="userName">Name of the user.</param>
        /// <param name="methodName">Name of the method.</param>
        /// <param name="parameters">The parameters.</param>
        public BillingTransaction(
            long ehrKey, 
            long organizationKey, 
            string userEmail, 
            string userName, 
            string methodName, 
            string parameters)
        {
            EhrKey = ehrKey;
            OrganizationKey = organizationKey;
            UserEmail = userEmail;
            UserName = userName;
            MethodName = methodName;
            Parameters = parameters;
        }

        internal BillingTransaction()
        {
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets the billing transaction key.
        /// </summary>
        /// <value>
        /// The billing transaction key.
        /// </value>
        [IgnoreMapping]
        public virtual long BillingTransactionKey { get { return Key; } }

        /// <summary>
        /// Gets or sets the ehr key.
        /// </summary>
        /// <value>
        /// The ehr key.
        /// </value>
        [NotNull]
        public virtual long EhrKey { get; protected set; }

        /// <summary>
        /// Gets or sets the organization key.
        /// </summary>
        /// <value>
        /// The organization key.
        /// </value>
        [NotNull]
        public virtual long OrganizationKey { get; protected set; }

        /// <summary>
        /// Gets or sets the name of the user.
        /// </summary>
        /// <value>
        /// The name of the user.
        /// </value>
        public virtual string UserName { get; protected set; }

        /// <summary>
        /// Gets or sets the user email.
        /// </summary>
        /// <value>
        /// The user email.
        /// </value>
        public virtual string UserEmail { get; protected set; }

        /// <summary>
        /// Gets or sets the name of the method.
        /// </summary>
        /// <value>
        /// The name of the method.
        /// </value>
        public virtual string MethodName { get; protected set; }

        /// <summary>
        /// Gets or sets the parameters.
        /// </summary>
        /// <value>
        /// The parameters.
        /// </value>
        [ColumnLength(4000)]
        public virtual string Parameters { get; protected set; }

        #endregion

        #region Public Methods and Operators

        #endregion
    }
}