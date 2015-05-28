using Asam.Ppc.Domain.CommonModule;

namespace Asam.Ppc.Domain.AssessmentModule.DrugAndAlcohol.Lookups
{
    /// <summary>
    /// Substance Treatment Type
    /// </summary>
    public class SubstanceTreatmentType : Lookup
    {
        /// <summary> 
        /// No = 0.
        /// </summary>
        public static readonly SubstanceTreatmentType No = new SubstanceTreatmentType
            {
                Code = "No",
                SortOrder = 1,
                Value = 0
            };

        /// <summary>
        ///     AlcoholOnly = 1.
        /// </summary>
        public static readonly SubstanceTreatmentType AlcoholOnly = new SubstanceTreatmentType
            {
                Code = "AlcoholOnly",
                SortOrder = 2,
                Value = 1
            };

        /// <summary>
        ///     DrugOnly = 2.
        /// </summary>
        public static readonly SubstanceTreatmentType DrugOnly = new SubstanceTreatmentType
            {
                Code = "DrugOnly",
                SortOrder = 3,
                Value = 2
            };

        /// <summary>
        ///     AlcoholAndDrug = 3.
        /// </summary>
        public static readonly SubstanceTreatmentType AlcoholAndDrug = new SubstanceTreatmentType
            {
                Code = "AlcoholAndDrug",
                SortOrder = 4,
                Value = 3
            };
    }
}