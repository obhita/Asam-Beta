namespace Asam.Ppc.Domain.AssessmentModule.Review
{
    #region Using Statements

    using CommonModule;

    #endregion

    /// <summary>
    ///     Agreement Rating
    /// </summary>
    public class AgreementRating : Lookup
    {
        #region Static Fields

        /// <summary>
        ///     1=Definitely not
        /// </summary>
        public static readonly AgreementRating DefinitelyNot = new AgreementRating
            {
                Code = "DefinitelyNot",
                SortOrder = 1,
                Value = 1
            };

        /// <summary>
        ///     6=Definitely yes
        /// </summary>
        public static readonly AgreementRating DefinitelyYes = new AgreementRating
            {
                Code = "DefinitelyYes",
                SortOrder = 6,
                Value = 6
            };

        /// <summary>
        ///     0=No answer
        /// </summary>
        public static readonly AgreementRating NoAnswer = new AgreementRating
            {
                Code = "NoAnswer",
                SortOrder = 0,
                Value = 0
            };

        /// <summary>
        ///     3=Possibly not
        /// </summary>
        public static readonly AgreementRating PossiblyNot = new AgreementRating
            {
                Code = "PossiblyNot",
                SortOrder = 3,
                Value = 3
            };

        /// <summary>
        ///     4=Possibly yes
        /// </summary>
        public static readonly AgreementRating PossiblyYes = new AgreementRating
            {
                Code = "PossiblyYes",
                SortOrder = 4,
                Value = 4
            };

        /// <summary>
        ///     2=Probably not
        /// </summary>
        public static readonly AgreementRating ProbablyNot = new AgreementRating
            {
                Code = "ProbablyNot",
                SortOrder = 2,
                Value = 2
            };

        /// <summary>
        ///     5=Probably yes
        /// </summary>
        public static readonly AgreementRating ProbablyYes = new AgreementRating
            {
                Code = "ProbablyYes",
                SortOrder = 5,
                Value = 5
            };

        #endregion
    }
}