namespace Asam.Ppc.Domain.CommonModule.Lookups
{
    public class Gender : Lookup
    {
        /// <summary>
        ///     Male = 1.
        /// </summary>
        public static readonly Gender Male = new Gender
            {
                Code = "Male",
                SortOrder = 1,
                Value = 1
            };

        /// <summary>
        ///     Female = 2.
        /// </summary>
        public static readonly Gender Female = new Gender
            {
                Code = "Female",
                SortOrder = 1,
                Value = 2
            };
    }
}