namespace Asam.Ppc.Infrastructure.Services
{
    #region Using Statements

    using System.Collections.Generic;

    #endregion

    /// <summary>
    ///     Class for holding completeness result.
    /// </summary>
    public class CompletenessResults
    {
        #region Constructors and Destructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="CompletenessResults" /> class.
        /// </summary>
        /// <param name="completenessCategory">The completeness category.</param>
        /// <param name="total">The total.</param>
        /// <param name="numberInComplete">The number in complete.</param>
        public CompletenessResults ( string completenessCategory, int total, int numberInComplete )
        {
            CompletenessCategory = completenessCategory;
            Total = total;
            NumberInComplete = numberInComplete;
        }

        #endregion

        #region Public Properties

        /// <summary>
        ///     Gets the completeness category.
        /// </summary>
        /// <value>
        ///     The completeness category.
        /// </value>
        public string CompletenessCategory { get; private set; }

        /// <summary>
        ///     Gets or sets the completeness results per rule set.
        /// </summary>
        /// <value>
        ///     The completeness results per rule set.
        /// </value>
        public IDictionary<string, CompletenessResults> CompletenessResultsPerRuleSet { get; set; }

        /// <summary>
        ///     Gets the number complete.
        /// </summary>
        /// <value>
        ///     The number complete.
        /// </value>
        public int NumberComplete
        {
            get { return Total - NumberInComplete; }
        }

        /// <summary>
        ///     Gets the number in complete.
        /// </summary>
        /// <value>
        ///     The number in complete.
        /// </value>
        public int NumberInComplete { get; private set; }

        /// <summary>
        ///     Gets the percent complete.
        /// </summary>
        /// <value>
        ///     The percent complete.
        /// </value>
        public double PercentComplete
        {
            get { return (double) NumberComplete / (double) Total; }
        }

        /// <summary>
        ///     Gets the total.
        /// </summary>
        /// <value>
        ///     The total.
        /// </value>
        public int Total { get; private set; }

        #endregion
    }
}