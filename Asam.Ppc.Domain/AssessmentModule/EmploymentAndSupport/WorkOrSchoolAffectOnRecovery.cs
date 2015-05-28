using Asam.Ppc.Domain.CommonModule;

namespace Asam.Ppc.Domain.AssessmentModule.EmploymentAndSupport
{
    public class WorkOrSchoolAffectOnRecovery : Lookup
    {
        /// <summary>
        ///     WillBeSupportiveAndProtective = 0.
        /// </summary>
        public static readonly WorkOrSchoolAffectOnRecovery WillBeSupportiveAndProtective = new WorkOrSchoolAffectOnRecovery
            {
                Code = "WillBeSupportiveAndProtective",
                SortOrder = 1,
                Value = 0
            };

        /// <summary>
        ///     WillFreelyPermitRecovery = 1.
        /// </summary>
        public static readonly WorkOrSchoolAffectOnRecovery WillFreelyPermitRecovery = new WorkOrSchoolAffectOnRecovery
            {
                Code = "WillFreelyPermitRecovery",
                SortOrder = 2,
                Value = 1
            };

        /// <summary>
        ///     WillRequireSomeScheduleAdjustments = 2.
        /// </summary>
        public static readonly WorkOrSchoolAffectOnRecovery WillRequireSomeScheduleAdjustments = new WorkOrSchoolAffectOnRecovery
            {
                Code = "WillRequireSomeScheduleAdjustments",
                SortOrder = 3,
                Value = 2
            };

        /// <summary>
        ///     WillDiscourageOrHinderRecovery = 3.
        /// </summary>
        public static readonly WorkOrSchoolAffectOnRecovery WillDiscourageOrHinderRecovery = new WorkOrSchoolAffectOnRecovery
            {
                Code = "WillDiscourageOrHinderRecovery",
                SortOrder = 4,
                Value = 3
            };

        /// <summary>
        ///     WillOftenPoseExposureToSubstanceUse = 4.
        /// </summary>
        public static readonly WorkOrSchoolAffectOnRecovery WillOftenPoseExposureToSubstanceUse = new WorkOrSchoolAffectOnRecovery
            {
                Code = "WillOftenPoseExposureToSubstanceUse",
                SortOrder = 5,
                Value = 4
            };
    }
}