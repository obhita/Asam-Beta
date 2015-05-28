using Asam.Ppc.Domain.CommonModule;

namespace Asam.Ppc.Domain.AssessmentModule.FamilyAndSocialHistory
{
    public class Companionship : Lookup
    {
        /// <summary>
        ///     Family = 1.
        /// </summary>
        public static readonly Companionship Family = new Companionship
            {
                Code = "Family",
                SortOrder = 1,
                Value = 1
            };

        /// <summary>
        ///     Friends = 2.
        /// </summary>
        public static readonly Companionship Friends = new Companionship
            {
                Code = "Friends",
                SortOrder = 2,
                Value = 2
            };

        /// <summary>
        ///     Alone = 3.
        /// </summary>
        public static readonly Companionship Alone = new Companionship
            {
                Code = "Alone",
                SortOrder = 3,
                Value = 3
            };
    }
}