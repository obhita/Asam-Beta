using Asam.Ppc.Domain.CommonModule;

namespace Asam.Ppc.Domain.AssessmentModule.EmploymentAndSupport
{
    public class EmploymentPattern : Lookup
    {
        /// <summary>
        ///     FullTime = 1.
        /// </summary>
        public static readonly EmploymentPattern FullTime = new EmploymentPattern
            {
                Code = "FullTime",
                SortOrder = 1,
                Value = 1
            };

        /// <summary>
        ///     PartTimeRegularHours = 2.
        /// </summary>
        public static readonly EmploymentPattern PartTimeRegularHours = new EmploymentPattern
            {
                Code = "PartTimeRegularHours",
                SortOrder = 2,
                Value = 2
            };

        /// <summary>
        ///     PartTimeIrregularHours = 3.
        /// </summary>
        public static readonly EmploymentPattern PartTimeIrregularHours = new EmploymentPattern
            {
                Code = "PartTimeIrregularHours",
                SortOrder = 3,
                Value = 3
            };

        /// <summary>
        ///     Student = 4.
        /// </summary>
        public static readonly EmploymentPattern Student = new EmploymentPattern
            {
                Code = "Student",
                SortOrder = 4,
                Value = 4
            };

        /// <summary>
        ///     Service = 5.
        /// </summary>
        public static readonly EmploymentPattern Service = new EmploymentPattern
            {
                Code = "Service",
                SortOrder = 5,
                Value = 5
            };

        /// <summary>
        ///     RetiredOrOnDisability = 6.
        /// </summary>
        public static readonly EmploymentPattern RetiredOrOnDisability = new EmploymentPattern
            {
                Code = "RetiredOrOnDisability",
                SortOrder = 6,
                Value = 6
            };

        /// <summary>
        ///     Unemployed = 7.
        /// </summary>
        public static readonly EmploymentPattern Unemployed = new EmploymentPattern
            {
                Code = "Unemployed",
                SortOrder = 7,
                Value = 7
            };

        /// <summary>
        ///     InControlledEnvironment = 8.
        /// </summary>
        public static readonly EmploymentPattern InControlledEnvironment = new EmploymentPattern
            {
                Code = "InControlledEnvironment",
                SortOrder = 8,
                Value = 8
            };
    }
}