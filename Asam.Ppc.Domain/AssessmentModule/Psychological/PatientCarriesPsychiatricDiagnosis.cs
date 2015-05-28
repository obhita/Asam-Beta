using Asam.Ppc.Domain.CommonModule;

namespace Asam.Ppc.Domain.AssessmentModule.Psychological
{
    public class PatientCarriesPsychiatricDiagnosis : Lookup
    {
        /// <summary>
        ///     No = 0.
        /// </summary>
        public static readonly PatientCarriesPsychiatricDiagnosis No = new PatientCarriesPsychiatricDiagnosis
            {
                Code = "No",
                SortOrder = 1,
                Value = 0
            };

        /// <summary>
        ///     YesImpliedByCollateral = 1.
        /// </summary>
        public static readonly PatientCarriesPsychiatricDiagnosis YesImpliedByCollateral = new PatientCarriesPsychiatricDiagnosis
            {
                Code = "YesImpliedByCollateral",
                SortOrder = 2,
                Value = 1
            };

        /// <summary>
        ///     YesReportedByPatient = 2.
        /// </summary>
        public static readonly PatientCarriesPsychiatricDiagnosis YesReportedByPatient = new PatientCarriesPsychiatricDiagnosis
            {
                Code = "YesReportedByPatient",
                SortOrder = 3,
                Value = 2
            };

        /// <summary>
        ///     YesDocumentedByCaregiverPastOrCurrent = 3.
        /// </summary>
        public static readonly PatientCarriesPsychiatricDiagnosis YesDocumentedByCaregiverPastOrCurrent = new PatientCarriesPsychiatricDiagnosis
            {
                Code = "YesDocumentedByCaregiverPastOrCurrent",
                SortOrder = 4,
                Value = 3
            };

        /// <summary>
        ///     Unknown = 9.
        /// </summary>
        public static readonly PatientCarriesPsychiatricDiagnosis Unknown = new PatientCarriesPsychiatricDiagnosis
            {
                Code = "Unknown",
                SortOrder = 5,
                Value = 9
            };
    }
}