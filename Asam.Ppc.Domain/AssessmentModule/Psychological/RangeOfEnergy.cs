using Asam.Ppc.Domain.CommonModule;

namespace Asam.Ppc.Domain.AssessmentModule.Psychological
{
    public class RangeOfEnergy : Lookup
    {
        /// <summary>
        ///     NoneNoProblems = 0.
        /// </summary>
        public static readonly RangeOfEnergy NoneNoProblems = new RangeOfEnergy
            {
                Code = "NoneNoProblems",
                SortOrder = 1,
                Value = 0
            };

        /// <summary>
        ///     MildIntermittentInfrequentLossOfEnergyAndFatigue = 1.
        /// </summary>
        public static readonly RangeOfEnergy MildIntermittentInfrequentLossOfEnergyAndFatigue = new RangeOfEnergy
            {
                Code = "MildIntermittentInfrequentLossOfEnergyAndFatigue",
                SortOrder = 2,
                Value = 1
            };

        /// <summary>
        ///     ProblemsDefinitelyPresentMostEveryDaySubjectivelyExperiencedAsSevere = 2.
        /// </summary>
        public static readonly RangeOfEnergy ProblemsDefinitelyPresentMostEveryDaySubjectivelyExperiencedAsSevere = new RangeOfEnergy
            {
                Code = "ProblemsDefinitelyPresentMostEveryDaySubjectivelyExperiencedAsSevere",
                SortOrder = 3,
                Value = 2
            };
    }
}