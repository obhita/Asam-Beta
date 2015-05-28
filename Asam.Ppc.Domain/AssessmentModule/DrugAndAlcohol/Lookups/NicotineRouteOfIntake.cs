using Asam.Ppc.Domain.CommonModule;

namespace Asam.Ppc.Domain.AssessmentModule.DrugAndAlcohol.Lookups
{
    /// <summary>
    /// Nicotine Route of Intake
    /// </summary>
    public class NicotineRouteOfIntake : Lookup
    {
        /// <summary>
        ///     Oral = 1.
        /// </summary>
        public static readonly NicotineRouteOfIntake Oral = new NicotineRouteOfIntake
            {
                Code = "Oral",
                SortOrder = 1,
                Value = 1
            };

        /// <summary>
        ///     Insufflation = 2.
        /// </summary>
        public static readonly NicotineRouteOfIntake Insufflation = new NicotineRouteOfIntake
            {
                Code = "Insufflation",
                SortOrder = 2,
                Value = 2
            };

        /// <summary>
        ///     Smoke = 3.
        /// </summary>
        public static readonly NicotineRouteOfIntake Smoke = new NicotineRouteOfIntake
            {
                Code = "Smoke",
                SortOrder = 3,
                Value = 3
            };
    }
}