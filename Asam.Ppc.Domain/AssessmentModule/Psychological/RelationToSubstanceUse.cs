using Asam.Ppc.Domain.CommonModule;

namespace Asam.Ppc.Domain.AssessmentModule.Psychological
{
    public class RelationToSubstanceUse : Lookup
    {
        /// <summary>
        ///     NotRelatedToUse = 0.
        /// </summary>
        public static readonly RelationToSubstanceUse NotRelatedToUse = new RelationToSubstanceUse
            {
                Code = "NotRelatedToUse",
                SortOrder = 1,
                Value = 0
            };

        /// <summary>
        ///     LikelyRelatedToActiveSubstanceUseOrIntoxication = 1.
        /// </summary>
        public static readonly RelationToSubstanceUse LikelyRelatedToActiveSubstanceUseOrIntoxication = new RelationToSubstanceUse
            {
                Code = "LikelyRelatedToActiveSubstanceUseOrIntoxication",
                SortOrder = 2,
                Value = 1
            };

        /// <summary>
        ///     LikelyRelatedToSubstanceWithdrawal = 2.
        /// </summary>
        public static readonly RelationToSubstanceUse LikelyRelatedToSubstanceWithdrawal = new RelationToSubstanceUse
            {
                Code = "LikelyRelatedToSubstanceWithdrawal",
                SortOrder = 3,
                Value = 2
            };

        /// <summary>
        ///     Unknown = 9.
        /// </summary>
        public static readonly RelationToSubstanceUse Unknown = new RelationToSubstanceUse
            {
                Code = "Unknown",
                SortOrder = 4,
                Value = 9
            };
    }
}