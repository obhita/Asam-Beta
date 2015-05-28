using Asam.Ppc.Domain.CommonModule;

namespace Asam.Ppc.Domain.AssessmentModule.DrugAndAlcohol.Lookups
{
    /// <summary>
    /// Route of Intake
    /// </summary>
    public class RouteOfIntake : Lookup
    {
        /// <summary>
        ///     Oral = 1.
        /// </summary>
        public static readonly RouteOfIntake Oral = new RouteOfIntake
            {
                Code = "Oral",
                SortOrder = 1,
                Value = 1
            };

        /// <summary>
        ///     Insufflation = 2.
        /// </summary>
        public static readonly RouteOfIntake Insufflation = new RouteOfIntake
            {
                Code = "Insufflation",
                SortOrder = 2,
                Value = 2
            };

        /// <summary>
        ///     Smoke = 3.
        /// </summary>
        public static readonly RouteOfIntake Smoke = new RouteOfIntake
            {
                Code = "Smoke",
                SortOrder = 3,
                Value = 3
            };

        /// <summary>
        ///     NonIvInjection = 4.
        /// </summary>
        public static readonly RouteOfIntake NonIvInjection = new RouteOfIntake
            {
                Code = "NonIvInjection",
                SortOrder = 4,
                Value = 4
            };

        /// <summary>
        ///     IvInjection = 5.
        /// </summary>
        public static readonly RouteOfIntake IvInjection = new RouteOfIntake
            {
                Code = "IvInjection",
                SortOrder = 5,
                Value = 5
            };
    }
}