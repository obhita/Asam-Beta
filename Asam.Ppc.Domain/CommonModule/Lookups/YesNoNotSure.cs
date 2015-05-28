namespace Asam.Ppc.Domain.CommonModule.Lookups
{
    public class YesNoNotSure : Lookup
    {
        /// <summary>
        ///     No = 0.
        /// </summary>
        public static readonly YesNoNotSure No = new YesNoNotSure
            {
                Code = "No",
                SortOrder = 1,
                Value = 0
            };

        /// <summary>
        ///     NotSure = 1.
        /// </summary>
        public static readonly YesNoNotSure NotSure = new YesNoNotSure
            {
                Code = "NotSure",
                SortOrder = 2,
                Value = 1
            };

        /// <summary>
        ///     Yes = 2.
        /// </summary>
        public static readonly YesNoNotSure Yes = new YesNoNotSure
            {
                Code = "Yes",
                SortOrder = 3,
                Value = 2
            };
    }
}