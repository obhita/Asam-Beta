using Asam.Ppc.Domain.CommonModule;

namespace Asam.Ppc.Domain.AssessmentModule.FamilyAndSocialHistory
{
    public class LivingArrangement : Lookup
    {
        /// <summary>
        ///     WithSexualPartnerAndChildren = 1.
        /// </summary>
        public static readonly LivingArrangement WithSexualPartnerAndChildren = new LivingArrangement
            {
                Code = "WithSexualPartnerAndChildren",
                SortOrder = 1,
                Value = 1
            };

        /// <summary>
        ///     WithSexualPartnerAlone = 2.
        /// </summary>
        public static readonly LivingArrangement WithSexualPartnerAlone = new LivingArrangement
            {
                Code = "WithSexualPartnerAlone",
                SortOrder = 2,
                Value = 2
            };

        /// <summary>
        ///     WithParents = 3.
        /// </summary>
        public static readonly LivingArrangement WithParents = new LivingArrangement
            {
                Code = "WithParents",
                SortOrder = 3,
                Value = 3
            };

        /// <summary>
        ///     WithFamily = 4.
        /// </summary>
        public static readonly LivingArrangement WithFamily = new LivingArrangement
            {
                Code = "WithFamily",
                SortOrder = 4,
                Value = 4
            };

        /// <summary>
        ///     WithFriends = 5.
        /// </summary>
        public static readonly LivingArrangement WithFriends = new LivingArrangement
            {
                Code = "WithFriends",
                SortOrder = 5,
                Value = 5
            };

        /// <summary>
        ///     Alone = 6.
        /// </summary>
        public static readonly LivingArrangement Alone = new LivingArrangement
            {
                Code = "Alone",
                SortOrder = 6,
                Value = 6
            };

        /// <summary>
        ///     ControlledEnvironment = 7.
        /// </summary>
        public static readonly LivingArrangement ControlledEnvironment = new LivingArrangement
            {
                Code = "ControlledEnvironment",
                SortOrder = 7,
                Value = 7
            };

        /// <summary>
        ///     NoStableArrangements = 8.
        /// </summary>
        public static readonly LivingArrangement NoStableArrangements = new LivingArrangement
            {
                Code = "NoStableArrangements",
                SortOrder = 8,
                Value = 8
            };
    }
}