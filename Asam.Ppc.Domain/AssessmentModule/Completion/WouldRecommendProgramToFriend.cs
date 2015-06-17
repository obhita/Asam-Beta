using Asam.Ppc.Domain.CommonModule;

namespace Asam.Ppc.Domain.AssessmentModule.Completion
{
    /// <summary>
    /// Would Recommend Program to Friend
    /// </summary>
    public class WouldRecommendProgramToFriend : Lookup
    {
        /// <summary>
        ///     NoAnswer = 0.
        /// </summary>
        public static readonly WouldRecommendProgramToFriend NoAnswer = new WouldRecommendProgramToFriend
            {
                Code = "NoAnswer",
                SortOrder = 1,
                Value = 0
            };

        /// <summary>
        ///     DefinitelyNot = 1.
        /// </summary>
        public static readonly WouldRecommendProgramToFriend DefinitelyNot = new WouldRecommendProgramToFriend
            {
                Code = "DefinitelyNot",
                SortOrder = 2,
                Value = 1
            };

        /// <summary>
        ///     ProbablyNot = 2.
        /// </summary>
        public static readonly WouldRecommendProgramToFriend ProbablyNot = new WouldRecommendProgramToFriend
            {
                Code = "ProbablyNot",
                SortOrder = 3,
                Value = 2
            };

        /// <summary>
        ///     PossiblyNot = 3.
        /// </summary>
        public static readonly WouldRecommendProgramToFriend PossiblyNot = new WouldRecommendProgramToFriend
            {
                Code = "PossiblyNot",
                SortOrder = 4,
                Value = 3
            };

        /// <summary>
        ///     PossiblyYes = 4.
        /// </summary>
        public static readonly WouldRecommendProgramToFriend PossiblyYes = new WouldRecommendProgramToFriend
            {
                Code = "PossiblyYes",
                SortOrder = 5,
                Value = 4
            };

        /// <summary>
        ///     ProbablyYes = 5.
        /// </summary>
        public static readonly WouldRecommendProgramToFriend ProbablyYes = new WouldRecommendProgramToFriend
            {
                Code = "ProbablyYes",
                SortOrder = 6,
                Value = 5
            };

        /// <summary>
        ///     DefinitelyYes = 6.
        /// </summary>
        public static readonly WouldRecommendProgramToFriend DefinitelyYes = new WouldRecommendProgramToFriend
            {
                Code = "DefinitelyYes",
                SortOrder = 7,
                Value = 6
            };
    }
}