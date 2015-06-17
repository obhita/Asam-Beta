using Asam.Ppc.Domain.CommonModule;

namespace Asam.Ppc.Domain.AssessmentModule.Psychological
{
    public class PsychologicalEmotionalCounselingImportanceScale : Lookup
    {
        /// <summary>
        ///     NotImportant = 0.
        /// </summary>
        public static readonly PsychologicalEmotionalCounselingImportanceScale NotImportant = new PsychologicalEmotionalCounselingImportanceScale
            {
                Code = "NotImportant",
                SortOrder = 1,
                Value = 0
            };

        /// <summary>
        ///     SlightlyImportant = 1.
        /// </summary>
        public static readonly PsychologicalEmotionalCounselingImportanceScale SlightlyImportant = new PsychologicalEmotionalCounselingImportanceScale
            {
                Code = "SlightlyImportant",
                SortOrder = 2,
                Value = 1
            };

        /// <summary>
        ///     ModeratelyImportant = 2.
        /// </summary>
        public static readonly PsychologicalEmotionalCounselingImportanceScale ModeratelyImportant = new PsychologicalEmotionalCounselingImportanceScale
            {
                Code = "ModeratelyImportant",
                SortOrder = 3,
                Value = 2
            };

        /// <summary>
        ///     ConsiderablyImportant = 3.
        /// </summary>
        public static readonly PsychologicalEmotionalCounselingImportanceScale ConsiderablyImportant = new PsychologicalEmotionalCounselingImportanceScale
            {
                Code = "ConsiderablyImportant",
                SortOrder = 4,
                Value = 3
            };

        /// <summary>
        ///     ExtremelyImportant = 4.
        /// </summary>
        public static readonly PsychologicalEmotionalCounselingImportanceScale ExtremelyImportant = new PsychologicalEmotionalCounselingImportanceScale
            {
                Code = "ExtremelyImportant",
                SortOrder = 5,
                Value = 4
            };
    }
}