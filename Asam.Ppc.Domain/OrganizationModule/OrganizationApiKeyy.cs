namespace Asam.Ppc.Domain.OrganizationModule
{
    #region Using Statements

    using System;
    using Pillar.Common.Utility;
    using Pillar.Domain;

    #endregion

    /// <summary>
    ///     OrganizationApiKey
    /// </summary>
    public class OrganizationApiKey : Entity, IEquatable<OrganizationApiKey>
    {
        #region Constructors and Destructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="OrganizationApiKey" /> class.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="apiKey">The api key</param>
        public OrganizationApiKey ( string name, string apiKey)
        {
            Check.IsNotNull ( name, () => Name );
            Check.IsNotNull ( apiKey, () => ApiKey );

            ApiKey = apiKey;
            Name = name;
        }

        internal OrganizationApiKey()
        {}

        #endregion

        #region Public Properties

        /// <summary>
        ///     Gets the Name.
        /// </summary>
        /// <value>
        ///     The Name.
        /// </value>
        public virtual string Name { get; protected set; }

        /// <summary>
        ///     Gets the ApiKey
        /// </summary>
        /// <value>
        ///     The ApiKey
        /// </value>
        public virtual string ApiKey { get; protected internal set; }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        ///     ==s the specified left.
        /// </summary>
        /// <param name="left">The left.</param>
        /// <param name="right">The right.</param>
        /// <returns></returns>
        public static bool operator == ( OrganizationApiKey left, OrganizationApiKey right )
        {
            return Equals ( left, right );
        }

        /// <summary>
        ///     !=s the specified left.
        /// </summary>
        /// <param name="left">The left.</param>
        /// <param name="right">The right.</param>
        /// <returns></returns>
        public static bool operator != ( OrganizationApiKey left, OrganizationApiKey right )
        {
            return !Equals ( left, right );
        }

        /// <summary>
        ///     Equalses the specified other.
        /// </summary>
        /// <param name="other">The other.</param>
        /// <returns></returns>
        public virtual bool Equals(OrganizationApiKey other)
        {
            if ( ReferenceEquals ( null, other ) )
                return false;
            if ( ReferenceEquals ( this, other ) )
                return true;
            return Equals ( ApiKey, other.ApiKey );
        }

        /// <summary>
        ///     Determines whether the specified <see cref="System.Object" /> is equal to this instance.
        /// </summary>
        /// <param name="obj">
        ///     The <see cref="System.Object" /> to compare with this instance.
        /// </param>
        /// <returns>
        ///     <c>true</c> if the specified <see cref="System.Object" /> is equal to this instance; otherwise, <c>false</c>.
        /// </returns>
        public override bool Equals ( object obj )
        {
            if ( ReferenceEquals ( null, obj ) )
                return false;
            if ( ReferenceEquals ( this, obj ) )
                return true;
            if ( obj.GetType () != GetType () )
                return false;
            return Equals ( (OrganizationApiKey) obj );
        }

        /// <summary>
        ///     Returns a hash code for this instance.
        /// </summary>
        /// <returns>
        ///     A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table.
        /// </returns>
        public override int GetHashCode ()
        {
            unchecked
            {
                return ( ( ApiKey != null ? ApiKey.GetHashCode () : 0 ) * 397 );
            }
        }

        #endregion
    }
}