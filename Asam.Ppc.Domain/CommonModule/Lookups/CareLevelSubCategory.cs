namespace Asam.Ppc.Domain.CommonModule.Lookups
{
    public class CareLevelSubCategory : Lookup
    {
        /// <summary>
        ///     NotKnown = 99.
        /// </summary>
        public static readonly CareLevelSubCategory NotKnown = new CareLevelSubCategory
            {
                Code = "NotKnown",
                SortOrder = 1,
                Value = 99
            };

        /// <summary>
        ///     AddictionOnlyServices = 1.
        /// </summary>
        public static readonly CareLevelSubCategory AddictionOnlyServices = new CareLevelSubCategory
            {
                Code = "AddictionOnlyServices",
                SortOrder = 2,
                Value = 1
            };

        /// <summary>
        ///     DualDiagnosisCapable = 2.
        /// </summary>
        public static readonly CareLevelSubCategory CoOccurringCapable = new CareLevelSubCategory
            {
                Code = "CoOccurringCapable",
                SortOrder = 3,
                Value = 2
            };

        /// <summary>
        ///     DualDiagnosisEnhanced = 3.
        /// </summary>
        public static readonly CareLevelSubCategory CoOccurringEnhanced = new CareLevelSubCategory
            {
                Code = "CoOccurringEnhanced",
                SortOrder = 4,
                Value = 3
            };
    }
}