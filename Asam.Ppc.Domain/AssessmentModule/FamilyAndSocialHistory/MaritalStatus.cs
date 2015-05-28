using Asam.Ppc.Domain.CommonModule;

namespace Asam.Ppc.Domain.AssessmentModule.FamilyAndSocialHistory
{
    public class MaritalStatus : Lookup
    {
        /// <summary>
        ///     Married = 1.
        /// </summary>
        public static readonly MaritalStatus Married = new MaritalStatus
            {
                Code = "Married",
                SortOrder = 1,
                Value = 1
            };

        /// <summary>
        ///     Widowed = 3.
        /// </summary>
        public static readonly MaritalStatus Widowed = new MaritalStatus
            {
                Code = "Widowed",
                SortOrder = 2,
                Value = 3
            };

        /// <summary>
        ///     Separated = 4.
        /// </summary>
        public static readonly MaritalStatus Separated = new MaritalStatus
            {
                Code = "Separated",
                SortOrder = 3,
                Value = 4
            };

        /// <summary>
        ///     Divorced = 5.
        /// </summary>
        public static readonly MaritalStatus Divorced = new MaritalStatus
            {
                Code = "Divorced",
                SortOrder = 4,
                Value = 5
            };

        /// <summary>
        ///     NeverMarried = 6.
        /// </summary>
        public static readonly MaritalStatus NeverMarried = new MaritalStatus
            {
                Code = "NeverMarried",
                SortOrder = 5,
                Value = 6
            };
    }
}