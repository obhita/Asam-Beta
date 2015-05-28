using Asam.Ppc.Domain.CommonModule;

namespace Asam.Ppc.Domain.AssessmentModule.Psychological
{
    public class SelfManageEmotionalProblemsScale : Lookup
    {
        /// <summary>
        ///     NotAtAll = 0.
        /// </summary>
        public static readonly SelfManageEmotionalProblemsScale NotAtAll = new SelfManageEmotionalProblemsScale
            {
                Code = "NotAtAll",
                SortOrder = 1,
                Value = 0
            };

        /// <summary>
        ///     Slightly = 1.
        /// </summary>
        public static readonly SelfManageEmotionalProblemsScale Slightly = new SelfManageEmotionalProblemsScale
            {
                Code = "Slightly",
                SortOrder = 2,
                Value = 1
            };

        /// <summary>
        ///     Moderately = 2.
        /// </summary>
        public static readonly SelfManageEmotionalProblemsScale Moderately = new SelfManageEmotionalProblemsScale
            {
                Code = "Moderately",
                SortOrder = 3,
                Value = 2
            };

        /// <summary>
        ///     Considerably = 3.
        /// </summary>
        public static readonly SelfManageEmotionalProblemsScale Considerably = new SelfManageEmotionalProblemsScale
            {
                Code = "Considerably",
                SortOrder = 4,
                Value = 3
            };

        /// <summary>
        ///     Extremely = 4.
        /// </summary>
        public static readonly SelfManageEmotionalProblemsScale Extremely = new SelfManageEmotionalProblemsScale
            {
                Code = "Extremely",
                SortOrder = 5,
                Value = 4
            };
    }
}