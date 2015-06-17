using Asam.Ppc.Domain.CommonModule;

namespace Asam.Ppc.Domain.AssessmentModule.Medical
{
    public class VisualDisturbanceLevel : Lookup
    {
        /// <summary>
        ///     NotPresent = 0.
        /// </summary>
        public static readonly VisualDisturbanceLevel NotPresent = new VisualDisturbanceLevel
            {
                Code = "NotPresent",
                SortOrder = 1,
                Value = 0
            };

        /// <summary>
        ///     VeryMildSensitivity = 1.
        /// </summary>
        public static readonly VisualDisturbanceLevel VeryMildSensitivity = new VisualDisturbanceLevel
            {
                Code = "VeryMildSensitivity",
                SortOrder = 2,
                Value = 1
            };

        /// <summary>
        ///     MildSensitivity = 2.
        /// </summary>
        public static readonly VisualDisturbanceLevel MildSensitivity = new VisualDisturbanceLevel
            {
                Code = "MildSensitivity",
                SortOrder = 3,
                Value = 2
            };

        /// <summary>
        ///     ModerateSensitivity = 3.
        /// </summary>
        public static readonly VisualDisturbanceLevel ModerateSensitivity = new VisualDisturbanceLevel
            {
                Code = "ModerateSensitivity",
                SortOrder = 4,
                Value = 3
            };

        /// <summary>
        ///     ModeratelySevereHallucinations = 4.
        /// </summary>
        public static readonly VisualDisturbanceLevel ModeratelySevereHallucinations = new VisualDisturbanceLevel
            {
                Code = "ModeratelySevereHallucinations",
                SortOrder = 5,
                Value = 4
            };

        /// <summary>
        ///     SevereHallucinations = 5.
        /// </summary>
        public static readonly VisualDisturbanceLevel SevereHallucinations = new VisualDisturbanceLevel
            {
                Code = "SevereHallucinations",
                SortOrder = 6,
                Value = 5
            };

        /// <summary>
        ///     ExtremelySevereHallucinations = 6.
        /// </summary>
        public static readonly VisualDisturbanceLevel ExtremelySevereHallucinations = new VisualDisturbanceLevel
            {
                Code = "ExtremelySevereHallucinations",
                SortOrder = 7,
                Value = 6
            };

        /// <summary>
        ///     ContinuousHallucinations = 7.
        /// </summary>
        public static readonly VisualDisturbanceLevel ContinuousHallucinations = new VisualDisturbanceLevel
            {
                Code = "ContinuousHallucinations",
                SortOrder = 8,
                Value = 7
            };
    }
}