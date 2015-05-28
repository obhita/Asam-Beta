using Asam.Ppc.Domain.CommonModule;

namespace Asam.Ppc.Domain.AssessmentModule.DrugAndAlcohol.Lookups
{
    /// <summary>
    /// Experienced Nausea Or Vomited Recently
    /// </summary>
    public class ExperiencedNauseaOrVomitedRecently : Lookup
    {
        /// <summary>
        ///     NoNauseaAndNoVomiting = 0.
        /// </summary>
        public static readonly ExperiencedNauseaOrVomitedRecently NoNauseaAndNoVomiting = new ExperiencedNauseaOrVomitedRecently
            {
                Code = "NoNauseaAndNoVomiting",
                SortOrder = 1,
                Value = 0
            };

        /// <summary>
        ///     MildNauseaWithNoVomiting = 1.
        /// </summary>
        public static readonly ExperiencedNauseaOrVomitedRecently MildNauseaWithNoVomiting = new ExperiencedNauseaOrVomitedRecently
            {
                Code = "MildNauseaWithNoVomiting",
                SortOrder = 2,
                Value = 1
            };

        /// <summary>
        ///     IntermittentNauseaWithDryHeaves = 4.
        /// </summary>
        public static readonly ExperiencedNauseaOrVomitedRecently IntermittentNauseaWithDryHeaves = new ExperiencedNauseaOrVomitedRecently
            {
                Code = "IntermittentNauseaWithDryHeaves",
                SortOrder = 3,
                Value = 4
            };

        /// <summary>
        ///     ConstantNauseaFrequentDryHeavesAndVomiting = 7.
        /// </summary>
        public static readonly ExperiencedNauseaOrVomitedRecently ConstantNauseaFrequentDryHeavesAndVomiting = new ExperiencedNauseaOrVomitedRecently
            {
                Code = "ConstantNauseaFrequentDryHeavesAndVomiting",
                SortOrder = 4,
                Value = 7
            };
    }
}