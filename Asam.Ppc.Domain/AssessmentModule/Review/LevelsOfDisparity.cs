namespace Asam.Ppc.Domain.AssessmentModule.Review
{
    #region Using Statements

    using CommonModule;

    #endregion

    /// <summary>
    ///     Levels of Disparity
    /// </summary>
    public class LevelsOfDisparity : Lookup
    {
        #region Static Fields

        /// <summary>
        ///     No disparity = 0
        /// </summary>
        public static readonly LevelsOfDisparity NoDisparity = new LevelsOfDisparity
            {
                Code = "NoDisparity",
                SortOrder = 0,
                Value = 0
            };

        /// <summary>
        ///     Yes dimension 3 = 1
        /// </summary>
        public static readonly LevelsOfDisparity YesDimension3 = new LevelsOfDisparity
            {
                Code = "YesDimension3",
                SortOrder = 1,
                Value = 1
            };

        /// <summary>
        ///     Yes dimension 4 = 2
        /// </summary>
        public static readonly LevelsOfDisparity YesDimension4 = new LevelsOfDisparity
            {
                Code = "YesDimension4",
                SortOrder = 2,
                Value = 2
            };

        /// <summary>
        ///     Yes dimension 5 = 3
        /// </summary>
        public static readonly LevelsOfDisparity YesDimension5 = new LevelsOfDisparity
            {
                Code = "YesDimension5",
                SortOrder = 3,
                Value = 3
            };

        /// <summary>
        ///     Yes dimension 6 = 4
        /// </summary>
        public static readonly LevelsOfDisparity YesDimension6 = new LevelsOfDisparity
            {
                Code = "YesDimension6",
                SortOrder = 4,
                Value = 4
            };

        #endregion
    }
}