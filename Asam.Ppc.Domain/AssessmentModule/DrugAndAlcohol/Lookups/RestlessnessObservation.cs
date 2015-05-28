using Asam.Ppc.Domain.CommonModule;

namespace Asam.Ppc.Domain.AssessmentModule.DrugAndAlcohol.Lookups
{
    /// <summary>
    /// Restlessness Observation
    /// </summary>
    public class RestlessnessObservation : Lookup
    {
        /// <summary>
        ///     NormalActivity = 0.
        /// </summary>
        public static readonly RestlessnessObservation NormalActivity = new RestlessnessObservation
            {
                Code = "NormalActivity",
                SortOrder = 1,
                Value = 0
            };

        /// <summary>
        ///     SomewhatMoreThanNormalActivity = 1.
        /// </summary>
        public static readonly RestlessnessObservation SomewhatMoreThanNormalActivity = new RestlessnessObservation
            {
                Code = "SomewhatMoreThanNormalActivity",
                SortOrder = 2,
                Value = 1
            };

        /// <summary>
        ///     ModeratelyFidgety = 2.
        /// </summary>
        public static readonly RestlessnessObservation ModeratelyFidgety = new RestlessnessObservation
            {
                Code = "ModeratelyFidgety",
                SortOrder = 3,
                Value = 2
            };

        /// <summary>
        ///     GrossMovements = 3.
        /// </summary>
        public static readonly RestlessnessObservation GrossMovements = new RestlessnessObservation
            {
                Code = "GrossMovements",
                SortOrder = 4,
                Value = 3
            };
    }
}