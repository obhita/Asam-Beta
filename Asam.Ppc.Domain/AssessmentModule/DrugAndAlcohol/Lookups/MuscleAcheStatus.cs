using Asam.Ppc.Domain.CommonModule;

namespace Asam.Ppc.Domain.AssessmentModule.DrugAndAlcohol.Lookups
{
    /// <summary>
    /// Muscle Ache Status
    /// </summary>
    public class MuscleAcheStatus : Lookup
    {
        /// <summary>
        ///     NoMuscleAchingReportedArmAndNeckMusclesSoftAtRest = 0.
        /// </summary>
        public static readonly MuscleAcheStatus NoMuscleAchingReportedArmAndNeckMusclesSoftAtRest = new MuscleAcheStatus
            {
                Code = "NoMuscleAchingReportedArmAndNeckMusclesSoftAtRest",
                SortOrder = 1,
                Value = 0
            };

        /// <summary>
        ///     MildMusclePains = 1.
        /// </summary>
        public static readonly MuscleAcheStatus MildMusclePains = new MuscleAcheStatus
            {
                Code = "MildMusclePains",
                SortOrder = 2,
                Value = 1
            };

        /// <summary>
        ///     SeverePainsAndConstantContractionOfTheMusclesOfLegsArmsAndNeck = 2.
        /// </summary>
        public static readonly MuscleAcheStatus SeverePainsAndConstantContractionOfTheMusclesOfLegsArmsAndNeck = new MuscleAcheStatus
            {
                Code = "SeverePainsAndConstantContractionOfTheMusclesOfLegsArmsAndNeck",
                SortOrder = 3,
                Value = 2
            };
    }
}