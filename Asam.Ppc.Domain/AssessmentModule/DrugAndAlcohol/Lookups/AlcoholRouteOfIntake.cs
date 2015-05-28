using Asam.Ppc.Domain.CommonModule;

namespace Asam.Ppc.Domain.AssessmentModule.DrugAndAlcohol.Lookups
{
    /// <summary>
    /// Alcohol Route Of Intake
    /// </summary>
    public class AlcoholRouteOfIntake : Lookup
    {
        /// <summary>
        ///     Oral = 1.
        /// </summary>
        public static readonly AlcoholRouteOfIntake Oral = new AlcoholRouteOfIntake
            {
                Code = "Oral",
                SortOrder = 1,
                Value = 1
            };

        /// <summary>
        ///     IvInjection = 5.
        /// </summary>
        public static readonly AlcoholRouteOfIntake IvInjection = new AlcoholRouteOfIntake
            {
                Code = "IvInjection",
                SortOrder = 2,
                Value = 5
            };
    }
}