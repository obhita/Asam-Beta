namespace Asam.Ppc.Domain.CommonModule.ValueObjects
{
    /// <summary>
    ///     The Currency lookup contains a list of currencies.
    /// </summary>
    public class Currency : Lookup
    {
        #region Constants and Fields

        #endregion

        #region Constructors and Destructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="Currency" /> class.
        /// </summary>
        /// <param name="cultureName">Name of the culture.</param>
        public Currency(string cultureName)
        {
            CultureName = cultureName;
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="Currency" /> class.
        /// </summary>
        protected internal Currency()
        {
        }

        #endregion

        #region Public Properties

        /// <summary>
        ///     Gets the name of the culture.
        /// </summary>
        /// <value>
        ///     The name of the culture.
        /// </value>
        public string CultureName { get; protected set; }

        #endregion

        public static readonly Currency UnitedStatesEnglish = new Currency("en-US")
            {
                Code = "en-US",
                SortOrder = 0,
                Value = 0
            };
    }
}