using Asam.Ppc.Domain.CommonModule;

namespace Asam.Ppc.Domain.AssessmentModule.FamilyAndSocialHistory
{
    public class NeedsAndWillingnessToHelpTreatment : Lookup
    {
        /// <summary>
        ///     ImportantPersonsInStableRecovery = 0.
        /// </summary>
        public static readonly NeedsAndWillingnessToHelpTreatment ImportantPersonsInStableRecovery = new NeedsAndWillingnessToHelpTreatment
            {
                Code = "ImportantPersonsInStableRecovery",
                SortOrder = 1,
                Value = 0
            };

        /// <summary>
        ///     OnlyNeedsEducationAndWillAttend = 1.
        /// </summary>
        public static readonly NeedsAndWillingnessToHelpTreatment OnlyNeedsEducationAndWillAttend = new NeedsAndWillingnessToHelpTreatment
            {
                Code = "OnlyNeedsEducationAndWillAttend",
                SortOrder = 2,
                Value = 1
            };

        /// <summary>
        ///     NeedsCouplesOrFamilyCounselingOrTherapyAndWillParticipate = 2.
        /// </summary>
        public static readonly NeedsAndWillingnessToHelpTreatment
            NeedsCouplesOrFamilyCounselingOrTherapyAndWillParticipate = new NeedsAndWillingnessToHelpTreatment
                {
                    Code = "NeedsCouplesOrFamilyCounselingOrTherapyAndWillParticipate",
                    SortOrder = 3,
                    Value = 2
                };

        /// <summary>
        ///     NotClearIfWillHelpOrNoOneAvailable = 3.
        /// </summary>
        public static readonly NeedsAndWillingnessToHelpTreatment NotClearIfWillHelpOrNoOneAvailable = new NeedsAndWillingnessToHelpTreatment
            {
                Code = "NotClearIfWillHelpOrNoOneAvailable",
                SortOrder = 4,
                Value = 3
            };

        /// <summary>
        ///     SeriousConflictsAndNotAmenableToFamilyTreatment = 4.
        /// </summary>
        public static readonly NeedsAndWillingnessToHelpTreatment SeriousConflictsAndNotAmenableToFamilyTreatment = new NeedsAndWillingnessToHelpTreatment
            {
                Code = "SeriousConflictsAndNotAmenableToFamilyTreatment",
                SortOrder = 5,
                Value = 4
            };
    }
}