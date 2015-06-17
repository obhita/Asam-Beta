namespace Asam.Ppc.Domain.CommonModule.Lookups
{
    public class YesNoIndifferent : Lookup
    {
        /// <summary>
        ///     No = 0.
        /// </summary>
        public static readonly YesNoIndifferent No = new YesNoIndifferent
            {
                Code = "No",
                SortOrder = 1,
                Value = 0
            };

        /// <summary>
        ///     Indifferent = 1.
        /// </summary>
        public static readonly YesNoIndifferent Indifferent = new YesNoIndifferent
            {
                Code = "Indifferent",
                SortOrder = 2,
                Value = 1
            };

        /// <summary>
        ///     Yes = 2.
        /// </summary>
        public static readonly YesNoIndifferent Yes = new YesNoIndifferent
            {
                Code = "Yes",
                SortOrder = 3,
                Value = 2
            };
    }
}