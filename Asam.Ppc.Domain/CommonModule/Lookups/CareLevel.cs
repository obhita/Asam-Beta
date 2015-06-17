using Pillar.Domain.Attributes;

namespace Asam.Ppc.Domain.CommonModule.Lookups
{
    [Component]
    public class CareLevel : Lookup
    {
        /// <summary>
        ///     None = 0.
        /// </summary>
        public static readonly CareLevel None = new CareLevel
            {
                Code = "None",
                SortOrder = 0,
                Value = 0
            };

        /// <summary>
        ///     Level_05 = 1.
        /// </summary>
        public static readonly CareLevel Level_05 = new CareLevel
            {
                Code = "Level_05",
                SortOrder = 1,
                Value = 1
            };

        /// <summary>
        ///     Level_1 = 2.
        /// </summary>
        public static readonly CareLevel Level_1 = new CareLevel
            {
                Code = "Level_1",
                SortOrder = 2,
                Value = 2
            };

        /// <summary>
        ///     Level_1WM = 3.
        /// </summary>
        public static readonly CareLevel Level_1WM = new CareLevel
            {
                Code = "Level_1WM",
                SortOrder = 3,
                Value = 3
            };

        /// <summary>
        ///     Level_OTP = 4.
        /// </summary>
        public static readonly CareLevel Level_OTP = new CareLevel
            {
                Code = "Level_OTP",
                SortOrder = 4,
                Value = 4
            };

        /// <summary>
        ///     Level_2_1 = 5.
        /// </summary>
        public static readonly CareLevel Level_2_1 = new CareLevel
            {
                Code = "Level_2_1",
                SortOrder = 5,
                Value = 5
            };

        /// <summary>
        ///     Level_2_WM = 6.
        /// </summary>
        public static readonly CareLevel Level_2_WM = new CareLevel
            {
                Code = "Level_2_WM",
                SortOrder = 6,
                Value = 6
            };

        /// <summary>
        ///     Level_2_5 = 7.
        /// </summary>
        public static readonly CareLevel Level_2_5 = new CareLevel
            {
                Code = "Level_2_5",
                SortOrder = 7,
                Value = 7
            };

        /// <summary>
        ///     Level_3_1 = 8.
        /// </summary>
        public static readonly CareLevel Level_3_1 = new CareLevel
            {
                Code = "Level_3_1",
                SortOrder = 8,
                Value = 8
            };

        /// <summary>
        ///     Level_3_2_WM = 9.
        /// </summary>
        public static readonly CareLevel Level_3_2_WM = new CareLevel
            {
                Code = "Level_3_2_WM",
                SortOrder = 9,
                Value = 9
            };

        /// <summary>
        ///     Level_3_3 = 10.
        /// </summary>
        public static readonly CareLevel Level_3_3 = new CareLevel
            {
                Code = "Level_3_3",
                SortOrder = 10,
                Value = 10
            };

        /// <summary>
        ///     Level_3_5 = 11.
        /// </summary>
        public static readonly CareLevel Level_3_5 = new CareLevel
            {
                Code = "Level_3_5",
                SortOrder = 11,
                Value = 11
            };

        /// <summary>
        ///     Level_3_7 = 12.
        /// </summary>
        public static readonly CareLevel Level_3_7 = new CareLevel
            {
                Code = "Level_3_7",
                SortOrder = 12,
                Value = 12
            };

        /// <summary>
        ///     Level_3_7_WM = 13.
        /// </summary>
        public static readonly CareLevel Level_3_7_WM = new CareLevel
            {
                Code = "Level_3_7_WM",
                SortOrder = 13,
                Value = 13
            };

        /// <summary>
        ///     Level_4 = 14.
        /// </summary>
        public static readonly CareLevel Level_4 = new CareLevel
            {
                Code = "Level_4",
                SortOrder = 14,
                Value = 14
            };

        /// <summary>
        ///     Level_4_WM= 15.
        /// </summary>
        public static readonly CareLevel Level_4_WM = new CareLevel
            {
                Code = "Level_4_WM",
                SortOrder = 15,
                Value = 15
            };
    }
}