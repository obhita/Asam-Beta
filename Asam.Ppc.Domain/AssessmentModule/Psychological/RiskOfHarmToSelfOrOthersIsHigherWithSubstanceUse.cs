using Asam.Ppc.Domain.CommonModule;

namespace Asam.Ppc.Domain.AssessmentModule.Psychological
{
    public class RiskOfHarmToSelfOrOthersIsHigherWithSubstanceUse : Lookup
    {
        /// <summary>
        ///     NoNeverWithUseOrIntoxication = 0.
        /// </summary>
        public static readonly RiskOfHarmToSelfOrOthersIsHigherWithSubstanceUse NoNeverWithUseOrIntoxication = new RiskOfHarmToSelfOrOthersIsHigherWithSubstanceUse
            {
                Code = "NoNeverWithUseOrIntoxication",
                SortOrder = 1,
                Value = 0
            };

        /// <summary>
        ///     YesOnlyWithUseOrIntoxication = 1.
        /// </summary>
        public static readonly RiskOfHarmToSelfOrOthersIsHigherWithSubstanceUse YesOnlyWithUseOrIntoxication = new RiskOfHarmToSelfOrOthersIsHigherWithSubstanceUse
            {
                Code = "YesOnlyWithUseOrIntoxication",
                SortOrder = 2,
                Value = 1
            };

        /// <summary>
        ///     BothWithAndWithoutSubstanceUse = 2.
        /// </summary>
        public static readonly RiskOfHarmToSelfOrOthersIsHigherWithSubstanceUse BothWithAndWithoutSubstanceUse = new RiskOfHarmToSelfOrOthersIsHigherWithSubstanceUse
            {
                Code = "BothWithAndWithoutSubstanceUse",
                SortOrder = 3,
                Value = 2
            };

        /// <summary>
        ///     Unknown = 9.
        /// </summary>
        public static readonly RiskOfHarmToSelfOrOthersIsHigherWithSubstanceUse Unknown = new RiskOfHarmToSelfOrOthersIsHigherWithSubstanceUse
            {
                Code = "Unknown",
                SortOrder = 4,
                Value = 9
            };
    }
}