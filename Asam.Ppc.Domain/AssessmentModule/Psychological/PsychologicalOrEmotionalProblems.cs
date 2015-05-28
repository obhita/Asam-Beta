using Asam.Ppc.Domain.CommonModule;

namespace Asam.Ppc.Domain.AssessmentModule.Psychological
{
    public class PsychologicalOrEmotionalProblems : Lookup
    {
        /// <summary>
        ///     None = 0.
        /// </summary>
        public static readonly PsychologicalOrEmotionalProblems ProblemsWontInterfere = new PsychologicalOrEmotionalProblems
            {
                Code = "None",
                SortOrder = 1,
                Value = 0
            };

        /// <summary>
        ///     AnxietyDisorder = 1.
        /// </summary>
        public static readonly PsychologicalOrEmotionalProblems AnxietyDisorder = new PsychologicalOrEmotionalProblems
            {
                Code = "AnxietyDisorder",
                SortOrder = 2,
                Value = 1
            };

        /// <summary>
        ///     PanicDisorder = 2.
        /// </summary>
        public static readonly PsychologicalOrEmotionalProblems PanicDisorder = new PsychologicalOrEmotionalProblems
            {
                Code = "PanicDisorder",
                SortOrder = 3,
                Value = 2
            };

        /// <summary>
        ///     Agoraphobia = 3.
        /// </summary>
        public static readonly PsychologicalOrEmotionalProblems Agoraphobia = new PsychologicalOrEmotionalProblems
            {
                Code = "Agoraphobia",
                SortOrder = 4,
                Value = 3
            };

        /// <summary>
        ///     PostTraumaticStressDisorder = 4.
        /// </summary>
        public static readonly PsychologicalOrEmotionalProblems PostTraumaticStressDisorder = new PsychologicalOrEmotionalProblems
            {
                Code = "PostTraumaticStressDisorder",
                SortOrder = 5,
                Value = 4
            };

        /// <summary>
        ///     SocialPhobia = 5.
        /// </summary>
        public static readonly PsychologicalOrEmotionalProblems SocialPhobia = new PsychologicalOrEmotionalProblems
            {
                Code = "SocialPhobia",
                SortOrder = 6,
                Value = 5
            };

        /// <summary>
        ///     ObsessiveCompulsiveDisorder = 6.
        /// </summary>
        public static readonly PsychologicalOrEmotionalProblems ObsessiveCompulsiveDisorder = new PsychologicalOrEmotionalProblems
            {
                Code = "ObsessiveCompulsiveDisorder",
                SortOrder = 7,
                Value = 6
            };

        /// <summary>
        ///     EatingDisorder = 7.
        /// </summary>
        public static readonly PsychologicalOrEmotionalProblems EatingDisorder = new PsychologicalOrEmotionalProblems
            {
                Code = "EatingDisorder",
                SortOrder = 8,
                Value = 7
            };

        /// <summary>
        ///     DepressiveDisorder = 8.
        /// </summary>
        public static readonly PsychologicalOrEmotionalProblems DepressiveDisorder = new PsychologicalOrEmotionalProblems
            {
                Code = "DepressiveDisorder",
                SortOrder = 9,
                Value = 8
            };

        /// <summary>
        ///     ManiaOrBipolarDisorder = 9.
        /// </summary>
        public static readonly PsychologicalOrEmotionalProblems ManiaOrBipolarDisorder = new PsychologicalOrEmotionalProblems
            {
                Code = "ManiaOrBipolarDisorder",
                SortOrder = 10,
                Value = 9
            };

        /// <summary>
        ///     SchizophreniaPsychoticOrThoughtDisorder = 10.
        /// </summary>
        public static readonly PsychologicalOrEmotionalProblems SchizophreniaPsychoticOrThoughtDisorder = new PsychologicalOrEmotionalProblems
            {
                Code = "SchizophreniaPsychoticOrThoughtDisorder",
                SortOrder = 11,
                Value = 10
            };

        /// <summary>
        ///     BorderlineParanoidAntisocialOrOtherPersonalityDisorder = 11.
        /// </summary>
        public static readonly PsychologicalOrEmotionalProblems BorderlineParanoidAntisocialOrOtherPersonalityDisorder = new PsychologicalOrEmotionalProblems
            {
                Code = "BorderlineParanoidAntisocialOrOtherPersonalityDisorder",
                SortOrder = 12,
                Value = 11
            };

        /// <summary>
        ///     Other = 12.
        /// </summary>
        public static readonly PsychologicalOrEmotionalProblems Other = new PsychologicalOrEmotionalProblems
            {
                Code = "Other",
                SortOrder = 13,
                Value = 12
            };
    }
}