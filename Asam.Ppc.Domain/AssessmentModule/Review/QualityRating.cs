namespace Asam.Ppc.Domain.AssessmentModule.Review
{
    #region Using Statements

    using CommonModule;

    #endregion

    /// <summary>
    ///     Quality Rating
    /// </summary>
    public class QualityRating : Lookup
    {
        #region Static Fields

        /// <summary>
        ///     Excellent = 6
        /// </summary>
        public static readonly QualityRating Excellent = new QualityRating
            {
                Code = "Excellent",
                SortOrder = 6,
                Value = 6
            };

        /// <summary>
        ///     Fair = 3
        /// </summary>
        public static readonly QualityRating Fair = new QualityRating
            {
                Code = "Fair",
                SortOrder = 3,
                Value = 3
            };

        /// <summary>
        ///     Good = 4
        /// </summary>
        public static readonly QualityRating Good = new QualityRating
            {
                Code = "Good",
                SortOrder = 4,
                Value = 4
            };

        /// <summary>
        ///     No answer = 0
        /// </summary>
        public static readonly QualityRating NoAnswer = new QualityRating
            {
                Code = "NoAnswer",
                SortOrder = 0,
                Value = 0
            };

        /// <summary>
        ///     Poor = 2
        /// </summary>
        public static readonly QualityRating Poor = new QualityRating
            {
                Code = "Poor",
                SortOrder = 2,
                Value = 2
            };

        /// <summary>
        ///     Unacceptable = 1
        /// </summary>
        public static readonly QualityRating Unacceptable = new QualityRating
            {
                Code = "Unacceptable",
                SortOrder = 1,
                Value = 1
            };

        /// <summary>
        ///     Ver Good = 5
        /// </summary>
        public static readonly QualityRating VeryGood = new QualityRating
            {
                Code = "VeryGood",
                SortOrder = 5,
                Value = 5
            };

        #endregion
    }
}