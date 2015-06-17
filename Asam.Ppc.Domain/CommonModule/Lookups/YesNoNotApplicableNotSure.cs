namespace Asam.Ppc.Domain.CommonModule.Lookups
{
    public class YesNoNotApplicableNotSure : Lookup
    {
        /// <summary>
        ///     NotApplicable = -1.
        /// </summary>
        public static readonly YesNoNotApplicableNotSure NotApplicable = new YesNoNotApplicableNotSure
            {
                Code = "NotApplicable",
                SortOrder = 1,
                Value = -1
            };

        /// <summary>
        ///     No = 0.
        /// </summary>
        public static readonly YesNoNotApplicableNotSure No = new YesNoNotApplicableNotSure
            {
                Code = "No",
                SortOrder = 2,
                Value = 0
            };

        /// <summary>
        ///     NotSureOrPossibly = 1.
        /// </summary>
        public static readonly YesNoNotApplicableNotSure NotSureOrPossibly = new YesNoNotApplicableNotSure
            {
                Code = "NotSureOrPossibly",
                SortOrder = 3,
                Value = 1
            };

        /// <summary>
        ///     Yes = 2.
        /// </summary>
        public static readonly YesNoNotApplicableNotSure Yes = new YesNoNotApplicableNotSure
            {
                Code = "Yes",
                SortOrder = 4,
                Value = 2
            };
    }
}