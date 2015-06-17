using Asam.Ppc.Domain.CommonModule;

namespace Asam.Ppc.Domain.AssessmentModule.DrugAndAlcohol.Lookups
{
    /// <summary>
    /// Body Temperature Status
    /// </summary>
    public class BodyTemperatureStatus : Lookup
    {
        /// <summary>
        ///     NoReportOfTemperatureChanges = 0.
        /// </summary>
        public static readonly BodyTemperatureStatus NoReportOfTemperatureChanges = new BodyTemperatureStatus
            {
                Code = "NoReportOfTemperatureChanges",
                SortOrder = 1,
                Value = 0
            };

        /// <summary>
        ///     ReportsFeelingColdHandsColdAndClammyToTouch = 1.
        /// </summary>
        public static readonly BodyTemperatureStatus ReportsFeelingColdHandsColdAndClammyToTouch = new BodyTemperatureStatus
            {
                Code = "ReportsFeelingColdHandsColdAndClammyToTouch",
                SortOrder = 2,
                Value = 1
            };

        /// <summary>
        ///     UncontrollableShivering = 2.
        /// </summary>
        public static readonly BodyTemperatureStatus UncontrollableShivering = new BodyTemperatureStatus
            {
                Code = "UncontrollableShivering",
                SortOrder = 3,
                Value = 2
            };
    }
}