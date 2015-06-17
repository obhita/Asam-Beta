using Asam.Ppc.Domain.CommonModule;

namespace Asam.Ppc.Domain.PatientModule
{
    public class Ethnicity : Lookup
    {
        /// <summary>
        ///     Undeclared = 0.
        /// </summary>
        public static readonly Ethnicity Undeclared = new Ethnicity
            {
                Code = "Undeclared",
                SortOrder = 1,
                Value = 0
            };

        /// <summary>
        ///     Caucasian = 0.
        /// </summary>
        public static readonly Ethnicity Caucasian = new Ethnicity
            {
                Code = "Caucasian",
                SortOrder = 2,
                Value = 1
            };

        /// <summary>
        ///     AfricanAmerican = 0.
        /// </summary>
        public static readonly Ethnicity AfricanAmerican = new Ethnicity
            {
                Code = "AfricanAmerican",
                SortOrder = 3,
                Value = 2
            };

        /// <summary>
        ///     NativeAmerican = 0.
        /// </summary>
        public static readonly Ethnicity NativeAmerican = new Ethnicity
            {
                Code = "NativeAmerican",
                SortOrder = 4,
                Value = 3
            };

        /// <summary>
        ///     PacificIslander = 0.
        /// </summary>
        public static readonly Ethnicity PacificIslander = new Ethnicity
            {
                Code = "PacificIslander",
                SortOrder = 5,
                Value = 4
            };

        /// <summary>
        ///     AlaskanNative = 0.
        /// </summary>
        public static readonly Ethnicity AlaskanNative = new Ethnicity
            {
                Code = "AlaskanNative",
                SortOrder = 6,
                Value = 5
            };

        /// <summary>
        ///     Hispanic = 0.
        /// </summary>
        public static readonly Ethnicity Hispanic = new Ethnicity
            {
                Code = "Hispanic",
                SortOrder = 7,
                Value = 6
            };

        /// <summary>
        ///     Asian = 0.
        /// </summary>
        public static readonly Ethnicity Asian = new Ethnicity
            {
                Code = "Asian",
                SortOrder = 8,
                Value = 7
            };
    }
}