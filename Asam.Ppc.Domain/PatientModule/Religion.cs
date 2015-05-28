using Asam.Ppc.Domain.CommonModule;

namespace Asam.Ppc.Domain.PatientModule
{
    public class Religion : Lookup
    {
        /// <summary>
        ///     Protestant = 1.
        /// </summary>
        public static readonly Religion Protestant = new Religion
            {
                Code = "Protestant",
                SortOrder = 1,
                Value = 1
            };

        /// <summary>
        ///     Catholic = 2.
        /// </summary>
        public static readonly Religion Catholic = new Religion
            {
                Code = "Catholic",
                SortOrder = 2,
                Value = 2
            };

        /// <summary>
        ///     Jewish = 3.
        /// </summary>
        public static readonly Religion Jewish = new Religion
            {
                Code = "Jewish",
                SortOrder = 3,
                Value = 3
            };

        /// <summary>
        ///     Islamic = 4.
        /// </summary>
        public static readonly Religion Islamic = new Religion
            {
                Code = "Islamic",
                SortOrder = 4,
                Value = 4
            };

        /// <summary>
        ///     Other = 5.
        /// </summary>
        public static readonly Religion Other = new Religion
            {
                Code = "Other",
                SortOrder = 5,
                Value = 5
            };

        /// <summary>
        ///     None = 6.
        /// </summary>
        public static readonly Religion None = new Religion
            {
                Code = "None",
                SortOrder = 6,
                Value = 6
            };
    }
}