using Asam.Ppc.Domain.CommonModule;

namespace Asam.Ppc.Domain.AssessmentModule.Medical
{
    public class TuberculosisInfectionStatus : Lookup
    {
        /// <summary>
        ///     NoKnownInfection = 0.
        /// </summary>
        public static readonly TuberculosisInfectionStatus NoKnownInfection = new TuberculosisInfectionStatus
            {
                Code = "NoKnownInfection",
                SortOrder = 1,
                Value = 0
            };

        /// <summary>
        ///     KnownInfectionMedicallyTreated = 1.
        /// </summary>
        public static readonly TuberculosisInfectionStatus KnownInfectionMedicallyTreated = new TuberculosisInfectionStatus
            {
                Code = "KnownInfectionMedicallyTreated",
                SortOrder = 2,
                Value = 1
            };

        /// <summary>
        ///     KnownInfectionNotMedicallyTreated = 2.
        /// </summary>
        public static readonly TuberculosisInfectionStatus KnownInfectionNotMedicallyTreated = new TuberculosisInfectionStatus
            {
                Code = "KnownInfectionNotMedicallyTreated",
                SortOrder = 3,
                Value = 2
            };
    }
}