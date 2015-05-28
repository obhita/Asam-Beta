namespace Asam.Ppc.Domain.CommonModule.Lookups
{
    public class LikertScale : Lookup
    {
        /// <summary>
        ///     NotAtAll = 0.
        /// </summary>
        public static readonly LikertScale NotAtAll = new LikertScale
            {
                Code = "NotAtAll",
                SortOrder = 1,
                Value = 0
            };

        /// <summary>
        ///     Slightly = 1.
        /// </summary>
        public static readonly LikertScale Slightly = new LikertScale
            {
                Code = "Slightly",
                SortOrder = 2,
                Value = 1
            };

        /// <summary>
        ///     Moderately = 2.
        /// </summary>
        public static readonly LikertScale Moderately = new LikertScale
            {
                Code = "Moderately",
                SortOrder = 3,
                Value = 2
            };

        /// <summary>
        ///     Considerably = 3.
        /// </summary>
        public static readonly LikertScale Considerably = new LikertScale
            {
                Code = "Considerably",
                SortOrder = 4,
                Value = 3
            };

        /// <summary>
        ///     Extremely = 4.
        /// </summary>
        public static readonly LikertScale Extremely = new LikertScale
            {
                Code = "Extremely",
                SortOrder = 5,
                Value = 4
            };
    }
}