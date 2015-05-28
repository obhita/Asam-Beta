using Asam.Ppc.Domain.CommonModule;

namespace Asam.Ppc.Domain.AssessmentModule.Psychological
{
    public class RetardationOfThoughtOrSpeech : Lookup
    {
        /// <summary>
        ///     NormalSpeechAndThought = 0.
        /// </summary>
        public static readonly RetardationOfThoughtOrSpeech NormalSpeechAndThought = new RetardationOfThoughtOrSpeech
            {
                Code = "NormalSpeechAndThought",
                SortOrder = 1,
                Value = 0
            };

        /// <summary>
        ///     SlightRetardationAtInterview = 1.
        /// </summary>
        public static readonly RetardationOfThoughtOrSpeech SlightRetardationAtInterview = new RetardationOfThoughtOrSpeech
            {
                Code = "SlightRetardationAtInterview",
                SortOrder = 2,
                Value = 1
            };

        /// <summary>
        ///     ObviousRetardationAtInterview = 2.
        /// </summary>
        public static readonly RetardationOfThoughtOrSpeech ObviousRetardationAtInterview = new RetardationOfThoughtOrSpeech
            {
                Code = "ObviousRetardationAtInterview",
                SortOrder = 3,
                Value = 2
            };

        /// <summary>
        ///     InterviewDifficult = 3.
        /// </summary>
        public static readonly RetardationOfThoughtOrSpeech InterviewDifficult = new RetardationOfThoughtOrSpeech
            {
                Code = "InterviewDifficult",
                SortOrder = 4,
                Value = 3
            };

        /// <summary>
        ///     CompleteStupor = 4.
        /// </summary>
        public static readonly RetardationOfThoughtOrSpeech CompleteStupor = new RetardationOfThoughtOrSpeech
            {
                Code = "CompleteStupor",
                SortOrder = 5,
                Value = 4
            };
    }
}