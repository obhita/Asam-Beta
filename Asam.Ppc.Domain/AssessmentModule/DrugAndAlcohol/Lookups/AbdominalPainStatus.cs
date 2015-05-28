using Asam.Ppc.Domain.CommonModule;

namespace Asam.Ppc.Domain.AssessmentModule.DrugAndAlcohol.Lookups
{
    /// <summary>
    /// Abdominal Pain Status
    /// </summary>
    public class AbdominalPainStatus : Lookup
    {
        /// <summary>
        ///     NoAbdominalComplaintsNormalBowelSounds = 0.
        /// </summary>
        public static readonly AbdominalPainStatus NoAbdominalComplaintsNormalBowelSounds = new AbdominalPainStatus
            {
                Code = "NoAbdominalComplaintsNormalBowelSounds",
                SortOrder = 1,
                Value = 0
            };

        /// <summary>
        ///     ReportsWavesOfAbdominalCrampyPainActiveBowelSounds = 1.
        /// </summary>
        public static readonly AbdominalPainStatus ReportsWavesOfAbdominalCrampyPainActiveBowelSounds = new AbdominalPainStatus
            {
                Code = "ReportsWavesOfAbdominalCrampyPainActiveBowelSounds",
                SortOrder = 2,
                Value = 1
            };

        /// <summary>
        ///     ReportsCrampsPainsDiarrheaActiveBowelSounds = 2.
        /// </summary>
        public static readonly AbdominalPainStatus ReportsCrampsPainsDiarrheaActiveBowelSounds = new AbdominalPainStatus
            {
                Code = "ReportsCrampsPainsDiarrheaActiveBowelSounds",
                SortOrder = 3,
                Value = 2
            };
    }
}