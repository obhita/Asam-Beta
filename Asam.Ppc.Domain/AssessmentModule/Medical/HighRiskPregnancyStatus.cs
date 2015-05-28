using Asam.Ppc.Domain.CommonModule;

namespace Asam.Ppc.Domain.AssessmentModule.Medical
{
    public class HighRiskPregnancyStatus : Lookup
    {
        /// <summary>
        ///     NoRisk = 0.
        /// </summary>
        public static readonly HighRiskPregnancyStatus NoRisk = new HighRiskPregnancyStatus
            {
                Code = "NoRisk",
                SortOrder = 1,
                Value = 0
            };

        /// <summary>
        ///     PossibleHighRisk = 1.
        /// </summary>
        public static readonly HighRiskPregnancyStatus PossibleHighRisk = new HighRiskPregnancyStatus
            {
                Code = "PossibleHighRisk",
                SortOrder = 2,
                Value = 1
            };

        /// <summary>
        ///     ImmediatelyUnstable = 2.
        /// </summary>
        public static readonly HighRiskPregnancyStatus ImmediatelyUnstable = new HighRiskPregnancyStatus
            {
                Code = "ImmediatelyUnstable",
                SortOrder = 3,
                Value = 2
            };
    }
}