using Asam.Ppc.Domain.CommonModule;

namespace Asam.Ppc.Domain.AssessmentModule.DrugAndAlcohol.Lookups
{
    /// <summary>
    /// Increase In Addiction Symptoms
    /// </summary>
    public class IncreaseInAddictionSymptoms : Lookup
    {
        /// <summary>
        ///     No = 0.
        /// </summary>
        public static readonly IncreaseInAddictionSymptoms No = new IncreaseInAddictionSymptoms
            {
                Code = "No",
                SortOrder = 1,
                Value = 0
            };

        /// <summary>
        ///     IncreasedThoughtsOrCraving = 1.
        /// </summary>
        public static readonly IncreaseInAddictionSymptoms IncreasedThoughtsOrCraving = new IncreaseInAddictionSymptoms
            {
                Code = "IncreasedThoughtsOrCraving",
                SortOrder = 2,
                Value = 1
            };

        /// <summary>
        ///     MoreRiskTakingBehaviorsButNotUse = 2.
        /// </summary>
        public static readonly IncreaseInAddictionSymptoms MoreRiskTakingBehaviorsButNotUse = new IncreaseInAddictionSymptoms
            {
                Code = "MoreRiskTakingBehaviorsButNotUse",
                SortOrder = 3,
                Value = 2
            };

        /// <summary>
        ///     RelapsedButToLessUseThanWhenUsingBefore = 3.
        /// </summary>
        public static readonly IncreaseInAddictionSymptoms RelapsedButToLessUseThanWhenUsingBefore = new IncreaseInAddictionSymptoms
            {
                Code = "RelapsedButToLessUseThanWhenUsingBefore",
                SortOrder = 4,
                Value = 3
            };

        /// <summary>
        ///     IncreasedUseOrMoreAcuteRouteOfAdministrationThanBefore = 4.
        /// </summary>
        public static readonly IncreaseInAddictionSymptoms IncreasedUseOrMoreAcuteRouteOfAdministrationThanBefore = new IncreaseInAddictionSymptoms
            {
                Code = "IncreasedUseOrMoreAcuteRouteOfAdministrationThanBefore",
                SortOrder = 5,
                Value = 4
            };
    }
}