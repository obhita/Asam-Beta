namespace Asam.Ppc.Domain.CommonModule.Lookups
{
    public class YesNoNotApplicable : Lookup
    {
        /// <summary>
        ///     No = 0.
        /// </summary>
        public static readonly YesNoNotApplicable No = new YesNoNotApplicable
            {
                Code = "No",
                SortOrder = 1,
                Value = 0
            };

        /// <summary>
        ///     Yes = 1.
        /// </summary>
        public static readonly YesNoNotApplicable Yes = new YesNoNotApplicable
            {
                Code = "Yes",
                SortOrder = 2,
                Value = 1
            };

        /// <summary>
        ///     NotApplicable = 9.
        /// </summary>
        public static readonly YesNoNotApplicable NotApplicable = new YesNoNotApplicable
            {
                Code = "NotApplicable",
                SortOrder = 3,
                Value = 9
            };
    }
}