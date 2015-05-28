namespace Asam.Ppc.Domain.CommonModule
{
    /// <summary>
    ///     Provides a base implementation of a coded concept deriving from <see cref="T:Asam.Ppc.Domain.CommonModule.Lookup">LookupBase</see>.
    /// </summary>
    public abstract class CodedConceptLookupBase : Lookup
    {
        /// <summary>
        ///     Gets the code system version number.
        /// </summary>
        public string CodeSystemVersionNumber { get; protected set; }

        /// <summary>
        ///     Gets the name of the code system.
        /// </summary>
        /// <value>
        ///     The name of the code system.
        /// </value>
        public string CodeSystemName { get; protected set; }

        /// <summary>
        ///     Gets the code system identifier.
        /// </summary>
        public string CodeSystemIdentifier { get; protected set; }

        /// <summary>
        ///     Gets or sets the coded concept code.
        /// </summary>
        /// <value>
        ///     The coded concept code.
        /// </value>
        public virtual string CodedConceptCode { get; protected set; }
    }
}