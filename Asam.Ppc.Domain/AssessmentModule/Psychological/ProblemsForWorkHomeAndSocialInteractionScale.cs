using Asam.Ppc.Domain.CommonModule;

namespace Asam.Ppc.Domain.AssessmentModule.Psychological
{
    public class ProblemsForWorkHomeAndSocialInteractionScale : Lookup
    {
        /// <summary>
        ///     NotAtAll = 0.
        /// </summary>
        public static readonly ProblemsForWorkHomeAndSocialInteractionScale NotAtAll = new ProblemsForWorkHomeAndSocialInteractionScale
            {
                Code = "NotAtAll",
                SortOrder = 1,
                Value = 0
            };

        /// <summary>
        ///     Slightly = 1.
        /// </summary>
        public static readonly ProblemsForWorkHomeAndSocialInteractionScale Slightly = new ProblemsForWorkHomeAndSocialInteractionScale
            {
                Code = "Slightly",
                SortOrder = 2,
                Value = 1
            };

        /// <summary>
        ///     Moderately = 2.
        /// </summary>
        public static readonly ProblemsForWorkHomeAndSocialInteractionScale Moderately = new ProblemsForWorkHomeAndSocialInteractionScale
            {
                Code = "Moderately",
                SortOrder = 3,
                Value = 2
            };

        /// <summary>
        ///     Considerably = 3.
        /// </summary>
        public static readonly ProblemsForWorkHomeAndSocialInteractionScale Considerably = new ProblemsForWorkHomeAndSocialInteractionScale
            {
                Code = "Considerably",
                SortOrder = 4,
                Value = 3
            };

        /// <summary>
        ///     Extremely = 4.
        /// </summary>
        public static readonly ProblemsForWorkHomeAndSocialInteractionScale Extremely = new ProblemsForWorkHomeAndSocialInteractionScale
            {
                Code = "Extremely",
                SortOrder = 5,
                Value = 4
            };
    }
}