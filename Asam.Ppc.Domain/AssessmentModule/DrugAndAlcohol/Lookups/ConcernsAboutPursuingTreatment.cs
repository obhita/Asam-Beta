using Asam.Ppc.Domain.CommonModule;

namespace Asam.Ppc.Domain.AssessmentModule.DrugAndAlcohol.Lookups
{
    /// <summary>
    /// Concerns About Pursuing Treatment
    /// </summary>
    public class ConcernsAboutPursuingTreatment : Lookup
    {
        /// <summary>
        ///     NoHasBeenFullyParticipatingInAllRecommendedTreatments = 0.
        /// </summary>
        public static readonly ConcernsAboutPursuingTreatment NoHasBeenFullyParticipatingInAllRecommendedTreatments = new ConcernsAboutPursuingTreatment
            {
                Code = "NoHasBeenFullyParticipatingInAllRecommendedTreatments",
                SortOrder = 1,
                Value = 0
            };

        /// <summary>
        ///     NoOpenToFullyParticipatingInAnyRecommendedTreatments = 1.
        /// </summary>
        public static readonly ConcernsAboutPursuingTreatment NoOpenToFullyParticipatingInAnyRecommendedTreatments = new ConcernsAboutPursuingTreatment
            {
                Code = "NoOpenToFullyParticipatingInAnyRecommendedTreatments",
                SortOrder = 2,
                Value = 1
            };

        /// <summary>
        ///     PassiveOrSomeHesitations = 2.
        /// </summary>
        public static readonly ConcernsAboutPursuingTreatment PassiveOrSomeHesitations = new ConcernsAboutPursuingTreatment
            {
                Code = "PassiveOrSomeHesitations",
                SortOrder = 3,
                Value = 2
            };

        /// <summary>
        ///     ResistsImportantComponents = 3.
        /// </summary>
        public static readonly ConcernsAboutPursuingTreatment ResistsImportantComponents = new ConcernsAboutPursuingTreatment
            {
                Code = "ResistsImportantComponents",
                SortOrder = 4,
                Value = 3
            };

        /// <summary>
        ///     RejectsOrObstructsPlanWithManyContingencies = 4.
        /// </summary>
        public static readonly ConcernsAboutPursuingTreatment RejectsOrObstructsPlanWithManyContingencies = new ConcernsAboutPursuingTreatment
            {
                Code = "RejectsOrObstructsPlanWithManyContingencies",
                SortOrder = 5,
                Value = 4
            };
    }
}