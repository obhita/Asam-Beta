using Asam.Ppc.Domain.CommonModule;

namespace Asam.Ppc.Domain.AssessmentModule.Psychological
{
    public class PsychiatricDiagnosis : Lookup
    {
        /// <summary>
        ///     None = 0.
        /// </summary>
        public static readonly PsychiatricDiagnosis None = new PsychiatricDiagnosis
            {
                Code = "None",
                SortOrder = 1,
                Value = 0
            };

        /// <summary>
        ///     AnxietyDisorder = 1.
        /// </summary>
        public static readonly PsychiatricDiagnosis AnxietyDisorder = new PsychiatricDiagnosis
            {
                Code = "AnxietyDisorder",
                SortOrder = 2,
                Value = 1
            };

        /// <summary>
        ///     PanicDisorder = 2.
        /// </summary>
        public static readonly PsychiatricDiagnosis PanicDisorder = new PsychiatricDiagnosis
            {
                Code = "PanicDisorder",
                SortOrder = 3,
                Value = 2
            };

        /// <summary>
        ///     Agoraphobia = 3.
        /// </summary>
        public static readonly PsychiatricDiagnosis Agoraphobia = new PsychiatricDiagnosis
            {
                Code = "Agoraphobia",
                SortOrder = 4,
                Value = 3
            };

        /// <summary>
        ///     PostTraumaticStressDisorder = 4.
        /// </summary>
        public static readonly PsychiatricDiagnosis PostTraumaticStressDisorder = new PsychiatricDiagnosis
            {
                Code = "PostTraumaticStressDisorder",
                SortOrder = 5,
                Value = 4
            };

        /// <summary>
        ///     SocialPhobia = 5.
        /// </summary>
        public static readonly PsychiatricDiagnosis SocialPhobia = new PsychiatricDiagnosis
            {
                Code = "SocialPhobia",
                SortOrder = 6,
                Value = 5
            };

        /// <summary>
        ///     ObsessiveCompulsiveDisorder = 6.
        /// </summary>
        public static readonly PsychiatricDiagnosis ObsessiveCompulsiveDisorder = new PsychiatricDiagnosis
            {
                Code = "ObsessiveCompulsiveDisorder",
                SortOrder = 7,
                Value = 6
            };

        /// <summary>
        ///     EatingDisorder = 7.
        /// </summary>
        public static readonly PsychiatricDiagnosis EatingDisorder = new PsychiatricDiagnosis
            {
                Code = "EatingDisorder",
                SortOrder = 8,
                Value = 7
            };

        /// <summary>
        ///     DepressiveDisorder = 8.
        /// </summary>
        public static readonly PsychiatricDiagnosis DepressiveDisorder = new PsychiatricDiagnosis
            {
                Code = "DepressiveDisorder",
                SortOrder = 9,
                Value = 8
            };

        /// <summary>
        ///     ManiaOrBipolarDisorder = 9.
        /// </summary>
        public static readonly PsychiatricDiagnosis ManiaOrBipolarDisorder = new PsychiatricDiagnosis
            {
                Code = "ManiaOrBipolarDisorder",
                SortOrder = 10,
                Value = 9
            };

        /// <summary>
        ///     SchizophreniaPsychoticOrThoughtDisorder = 10.
        /// </summary>
        public static readonly PsychiatricDiagnosis SchizophreniaPsychoticOrThoughtDisorder = new PsychiatricDiagnosis
            {
                Code = "SchizophreniaPsychoticOrThoughtDisorder",
                SortOrder = 11,
                Value = 10
            };

        /// <summary>
        ///     BorderlineParanoidAntisocialOrOtherPersonalityDisorder = 11.
        /// </summary>
        public static readonly PsychiatricDiagnosis BorderlineParanoidAntisocialOrOtherPersonalityDisorder = new PsychiatricDiagnosis
            {
                Code = "BorderlineParanoidAntisocialOrOtherPersonalityDisorder",
                SortOrder = 12,
                Value = 11
            };

        /// <summary>
        ///     Other = 12.
        /// </summary>
        public static readonly PsychiatricDiagnosis Other = new PsychiatricDiagnosis
            {
                Code = "Other",
                SortOrder = 13,
                Value = 12
            };
    }
}