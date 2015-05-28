using Asam.Ppc.Domain.CommonModule;

namespace Asam.Ppc.Domain.AssessmentModule.DrugAndAlcohol.Lookups
{
    /// <summary>
    /// Substance Use or Relapse Likelihood
    /// </summary>
    public class SubstanceUseOrRelapseLikelihood : Lookup
    {
        /// <summary>
        ///     NoImminentRiskOfRelapseInNextFewDays = 0.
        /// </summary>
        public static readonly SubstanceUseOrRelapseLikelihood NoImminentRiskOfRelapseInNextFewDays = new SubstanceUseOrRelapseLikelihood
            {
                Code = "NoImminentRiskOfRelapseInNextFewDays",
                SortOrder = 1,
                Value = 0
            };

        /// <summary>
        ///     FeelsAtRiskWithinAMonth = 1.
        /// </summary>
        public static readonly SubstanceUseOrRelapseLikelihood FeelsAtRiskWithinAMonth = new SubstanceUseOrRelapseLikelihood
            {
                Code = "FeelsAtRiskWithinAMonth",
                SortOrder = 2,
                Value = 1
            };

        /// <summary>
        ///     FeelsAtRiskWithinAWeek = 2.
        /// </summary>
        public static readonly SubstanceUseOrRelapseLikelihood FeelsAtRiskWithinAWeek = new SubstanceUseOrRelapseLikelihood
            {
                Code = "FeelsAtRiskWithinAWeek",
                SortOrder = 3,
                Value = 2
            };

        /// <summary>
        ///     FeelsAtRiskWithinDays = 3.
        /// </summary>
        public static readonly SubstanceUseOrRelapseLikelihood FeelsAtRiskWithinDays = new SubstanceUseOrRelapseLikelihood
            {
                Code = "FeelsAtRiskWithinDays",
                SortOrder = 4,
                Value = 3
            };

        /// <summary>
        ///     AtRiskToday = 4.
        /// </summary>
        public static readonly SubstanceUseOrRelapseLikelihood AtRiskToday = new SubstanceUseOrRelapseLikelihood
            {
                Code = "AtRiskToday",
                SortOrder = 5,
                Value = 4
            };
    }
}