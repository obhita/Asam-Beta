using Asam.Ppc.Domain.CommonModule;

namespace Asam.Ppc.Domain.AssessmentModule.Psychological
{
    public class RangeOfIrritability : Lookup
    {
        /// <summary>
        ///     NoDifficulty = 0.
        /// </summary>
        public static readonly RangeOfIrritability NoDifficulty = new RangeOfIrritability
            {
                Code = "NoDifficulty",
                SortOrder = 1,
                Value = 0
            };

        /// <summary>
        ///     SubjectiveTensionAndIrritability = 1.
        /// </summary>
        public static readonly RangeOfIrritability SubjectiveTensionAndIrritability = new RangeOfIrritability
            {
                Code = "SubjectiveTensionAndIrritability",
                SortOrder = 2,
                Value = 1
            };

        /// <summary>
        ///     WorryingAboutMinorMatters = 2.
        /// </summary>
        public static readonly RangeOfIrritability WorryingAboutMinorMatters = new RangeOfIrritability
            {
                Code = "WorryingAboutMinorMatters",
                SortOrder = 3,
                Value = 2
            };

        /// <summary>
        ///     ApprehensiveAttitudeApparentInFaceOrSpeech = 3.
        /// </summary>
        public static readonly RangeOfIrritability ApprehensiveAttitudeApparentInFaceOrSpeech = new RangeOfIrritability
            {
                Code = "ApprehensiveAttitudeApparentInFaceOrSpeech",
                SortOrder = 4,
                Value = 3
            };

        /// <summary>
        ///     FearsExpressedWithoutQuestioning = 4.
        /// </summary>
        public static readonly RangeOfIrritability FearsExpressedWithoutQuestioning = new RangeOfIrritability
            {
                Code = "FearsExpressedWithoutQuestioning",
                SortOrder = 5,
                Value = 4
            };
    }
}