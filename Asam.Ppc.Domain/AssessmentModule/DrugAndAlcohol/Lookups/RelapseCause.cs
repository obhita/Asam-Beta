using Asam.Ppc.Domain.CommonModule;

namespace Asam.Ppc.Domain.AssessmentModule.DrugAndAlcohol.Lookups
{
    /// <summary>
    /// Relapse Cause
    /// </summary>
    public class RelapseCause : Lookup
    {
        /// <summary>
        ///     DetailedPerspectiveOnRisksAndTheirTiming = 0.
        /// </summary>
        public static readonly RelapseCause DetailedPerspectiveOnRisksAndTheirTiming = new RelapseCause
            {
                Code = "DetailedPerspectiveOnRisksAndTheirTiming",
                SortOrder = 1,
                Value = 0
            };

        /// <summary>
        ///     AwareOfSomeRisks = 1.
        /// </summary>
        public static readonly RelapseCause AwareOfSomeRisks = new RelapseCause
            {
                Code = "AwareOfSomeRisks",
                SortOrder = 2,
                Value = 1
            };

        /// <summary>
        ///     AdmitsRiskPossibleButVagueAboutRiskFactors = 2.
        /// </summary>
        public static readonly RelapseCause AdmitsRiskPossibleButVagueAboutRiskFactors = new RelapseCause
            {
                Code = "AdmitsRiskPossibleButVagueAboutRiskFactors",
                SortOrder = 3,
                Value = 2
            };

        /// <summary>
        ///     DoubtsRisksAreSerious = 3.
        /// </summary>
        public static readonly RelapseCause DoubtsRisksAreSerious = new RelapseCause
            {
                Code = "DoubtsRisksAreSerious",
                SortOrder = 4,
                Value = 3
            };

        /// <summary>
        ///     ConvincedRelapseWillNotOccur = 4.
        /// </summary>
        public static readonly RelapseCause ConvincedRelapseWillNotOccur = new RelapseCause
            {
                Code = "ConvincedRelapseWillNotOccur",
                SortOrder = 5,
                Value = 4
            };
    }
}