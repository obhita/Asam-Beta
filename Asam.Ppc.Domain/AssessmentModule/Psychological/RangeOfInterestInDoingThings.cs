using Asam.Ppc.Domain.CommonModule;

namespace Asam.Ppc.Domain.AssessmentModule.Psychological
{
    public class RangeOfInterestInDoingThings : Lookup
    {
        /// <summary>
        ///     NoDifficulty = 0.
        /// </summary>
        public static readonly RangeOfInterestInDoingThings NoDifficulty = new RangeOfInterestInDoingThings
            {
                Code = "NoDifficulty",
                SortOrder = 1,
                Value = 0
            };

        /// <summary>
        ///     ThoughtsAndFeelingsOfIncapacityFatigueOrWeakness = 1.
        /// </summary>
        public static readonly RangeOfInterestInDoingThings ThoughtsAndFeelingsOfIncapacityFatigueOrWeakness = new RangeOfInterestInDoingThings
            {
                Code = "ThoughtsAndFeelingsOfIncapacityFatigueOrWeakness",
                SortOrder = 2,
                Value = 1
            };

        /// <summary>
        ///     DecreaseInActualTimeSpentInActivitiesOrDecreaseInProductivity = 3.
        /// </summary>
        public static readonly RangeOfInterestInDoingThings
            DecreaseInActualTimeSpentInActivitiesOrDecreaseInProductivity = new RangeOfInterestInDoingThings
                {
                    Code = "DecreaseInActualTimeSpentInActivitiesOrDecreaseInProductivity",
                    SortOrder = 3,
                    Value = 3
                };

        /// <summary>
        ///     StoppedWorkingBecauseOfPresentIllness = 4.
        /// </summary>
        public static readonly RangeOfInterestInDoingThings StoppedWorkingBecauseOfPresentIllness = new RangeOfInterestInDoingThings
            {
                Code = "StoppedWorkingBecauseOfPresentIllness",
                SortOrder = 4,
                Value = 4
            };

        /// <summary>
        ///     LossOfInterestInActivityHobbiesOrWork = 2.
        /// </summary>
        public static readonly RangeOfInterestInDoingThings LossOfInterestInActivityHobbiesOrWork = new RangeOfInterestInDoingThings
            {
                Code = "LossOfInterestInActivityHobbiesOrWork",
                SortOrder = 5,
                Value = 2
            };
    }
}