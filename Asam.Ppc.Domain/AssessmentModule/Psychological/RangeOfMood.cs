using Asam.Ppc.Domain.CommonModule;

namespace Asam.Ppc.Domain.AssessmentModule.Psychological
{
    public class RangeOfMood : Lookup
    {
        /// <summary>
        ///     Absent = 0.
        /// </summary>
        public static readonly RangeOfMood Absent = new RangeOfMood
            {
                Code = "Absent",
                SortOrder = 1,
                Value = 0
            };

        /// <summary>
        ///     IndicatedOnlyOnQuestioning = 1.
        /// </summary>
        public static readonly RangeOfMood IndicatedOnlyOnQuestioning = new RangeOfMood
            {
                Code = "IndicatedOnlyOnQuestioning",
                SortOrder = 2,
                Value = 1
            };

        /// <summary>
        ///     SpontaneouslyReportedVerbally = 2.
        /// </summary>
        public static readonly RangeOfMood SpontaneouslyReportedVerbally = new RangeOfMood
            {
                Code = "SpontaneouslyReportedVerbally",
                SortOrder = 3,
                Value = 2
            };

        /// <summary>
        ///     CommunicatedNonverbally = 3.
        /// </summary>
        public static readonly RangeOfMood CommunicatedNonverbally = new RangeOfMood
            {
                Code = "CommunicatedNonverbally",
                SortOrder = 4,
                Value = 3
            };

        /// <summary>
        ///     PredominantMoodBySpontaneousAndNonverbalCommunication = 4.
        /// </summary>
        public static readonly RangeOfMood PredominantMoodBySpontaneousAndNonverbalCommunication = new RangeOfMood
            {
                Code = "PredominantMoodBySpontaneousAndNonverbalCommunication",
                SortOrder = 5,
                Value = 4
            };
    }
}