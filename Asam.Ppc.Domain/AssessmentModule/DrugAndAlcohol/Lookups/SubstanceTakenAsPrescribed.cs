using Asam.Ppc.Domain.CommonModule;

namespace Asam.Ppc.Domain.AssessmentModule.DrugAndAlcohol.Lookups
{
    /// <summary>
    /// Substance Taken as Prescribed
    /// </summary>
    public class SubstanceTakenAsPrescribed : Lookup
    {
        /// <summary>
        ///     Less = 0.
        /// </summary>
        public static readonly SubstanceTakenAsPrescribed Less = new SubstanceTakenAsPrescribed
            {
                Code = "Less",
                SortOrder = 1,
                Value = 0
            };

        /// <summary>
        ///     Yes = 1.
        /// </summary>
        public static readonly SubstanceTakenAsPrescribed Yes = new SubstanceTakenAsPrescribed
            {
                Code = "Yes",
                SortOrder = 2,
                Value = 1
            };

        /// <summary>
        ///     More = 2.
        /// </summary>
        public static readonly SubstanceTakenAsPrescribed More = new SubstanceTakenAsPrescribed
            {
                Code = "More",
                SortOrder = 3,
                Value = 2
            };
    }
}