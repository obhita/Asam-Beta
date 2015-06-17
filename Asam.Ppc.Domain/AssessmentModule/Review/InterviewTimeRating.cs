namespace Asam.Ppc.Domain.AssessmentModule.Review
{
    #region Using Statements

    using CommonModule;

    #endregion

    /// <summary>
    ///     Interview Time Rating
    /// </summary>
    public class InterviewTimeRating : Lookup
    {
        #region Static Fields

        /// <summary>
        ///     3=Just about right
        /// </summary>
        public static readonly InterviewTimeRating JustAboutRight = new InterviewTimeRating
            {
                Code = "JustAboutRight",
                SortOrder = 3,
                Value = 3
            };

        /// <summary>
        ///     0=No answer
        /// </summary>
        public static readonly InterviewTimeRating NoAnswer = new InterviewTimeRating
            {
                Code = "NoAnswer",
                SortOrder = 0,
                Value = 0
            };

        /// <summary>
        ///     1=No, definitely too long
        /// </summary>
        public static readonly InterviewTimeRating NoDefinitelyTooLong = new InterviewTimeRating
            {
                Code = "NoDefinitelyTooLong",
                SortOrder = 1,
                Value = 1
            };

        /// <summary>
        ///     5=No, definitely too quick
        /// </summary>
        public static readonly InterviewTimeRating NoDefinitelyTooQuick = new InterviewTimeRating
            {
                Code = "NoDefinitelyTooQuick",
                SortOrder = 5,
                Value = 5
            };

        /// <summary>
        ///     2=No, somewhat too long
        /// </summary>
        public static readonly InterviewTimeRating NoSomewhatTooLong = new InterviewTimeRating
            {
                Code = "NoSomewhatTooLong",
                SortOrder = 2,
                Value = 2
            };

        /// <summary>
        ///     4=No, somewhat too quick
        /// </summary>
        public static readonly InterviewTimeRating NoSomewhatTooQuick = new InterviewTimeRating
            {
                Code = "NoSomewhatTooQuick",
                SortOrder = 4,
                Value = 4
            };

        #endregion
    }
}