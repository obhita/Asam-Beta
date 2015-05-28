using Asam.Ppc.Domain.CommonModule;

namespace Asam.Ppc.Domain.AssessmentModule.Medical
{
    public class AuditoryDisturbanceLevel : Lookup
    {
        /// <summary>
        ///     NotPresent = 0.
        /// </summary>
        public static readonly AuditoryDisturbanceLevel NotPresent = new AuditoryDisturbanceLevel
            {
                Code = "NotPresent",
                SortOrder = 1,
                Value = 0
            };

        /// <summary>
        ///     VeryMildHarshnessOrAbilityToFrighten = 1.
        /// </summary>
        public static readonly AuditoryDisturbanceLevel VeryMildHarshnessOrAbilityToFrighten = new AuditoryDisturbanceLevel
            {
                Code = "VeryMildHarshnessOrAbilityToFrighten",
                SortOrder = 2,
                Value = 1
            };

        /// <summary>
        ///     MildHarshnessOrAbilityToFrighten = 2.
        /// </summary>
        public static readonly AuditoryDisturbanceLevel MildHarshnessOrAbilityToFrighten = new AuditoryDisturbanceLevel
            {
                Code = "MildHarshnessOrAbilityToFrighten",
                SortOrder = 3,
                Value = 2
            };

        /// <summary>
        ///     ModerateHarshnessOrAbilityToFrighten = 3.
        /// </summary>
        public static readonly AuditoryDisturbanceLevel ModerateHarshnessOrAbilityToFrighten = new AuditoryDisturbanceLevel
            {
                Code = "ModerateHarshnessOrAbilityToFrighten",
                SortOrder = 4,
                Value = 3
            };

        /// <summary>
        ///     ModeratelySevereHallucinations = 4.
        /// </summary>
        public static readonly AuditoryDisturbanceLevel ModeratelySevereHallucinations = new AuditoryDisturbanceLevel
            {
                Code = "ModeratelySevereHallucinations",
                SortOrder = 5,
                Value = 4
            };

        /// <summary>
        ///     SevereHallucinations = 5.
        /// </summary>
        public static readonly AuditoryDisturbanceLevel SevereHallucinations = new AuditoryDisturbanceLevel
            {
                Code = "SevereHallucinations",
                SortOrder = 6,
                Value = 5
            };

        /// <summary>
        ///     ExtremelySevereHallucinations = 6.
        /// </summary>
        public static readonly AuditoryDisturbanceLevel ExtremelySevereHallucinations = new AuditoryDisturbanceLevel
            {
                Code = "ExtremelySevereHallucinations",
                SortOrder = 7,
                Value = 6
            };

        /// <summary>
        ///     ContinuousHallucinations = 7.
        /// </summary>
        public static readonly AuditoryDisturbanceLevel ContinuousHallucinations = new AuditoryDisturbanceLevel
            {
                Code = "ContinuousHallucinations",
                SortOrder = 8,
                Value = 7
            };
    }
}