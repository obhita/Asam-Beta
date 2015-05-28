using Asam.Ppc.Domain.CommonModule;

namespace Asam.Ppc.Domain.AssessmentModule.GeneralInformation
{
    public class InterviewCircumstances : Lookup
    {
        /// <summary>
        ///     None = 0.
        /// </summary>
        public static readonly InterviewCircumstances None = new InterviewCircumstances
            {
                Code = "None",
                SortOrder = 1,
                Value = 0
            };

        /// <summary>
        ///     PatientTerminated = 1.
        /// </summary>
        public static readonly InterviewCircumstances PatientTerminated = new InterviewCircumstances
            {
                Code = "PatientTerminated",
                SortOrder = 2,
                Value = 1
            };

        /// <summary>
        ///     PatientRefused = 2.
        /// </summary>
        public static readonly InterviewCircumstances PatientRefused = new InterviewCircumstances
            {
                Code = "PatientRefused",
                SortOrder = 3,
                Value = 2
            };

        /// <summary>
        ///     PatientUnableToRespond = 3.
        /// </summary>
        public static readonly InterviewCircumstances PatientUnableToRespond = new InterviewCircumstances
            {
                Code = "PatientUnableToRespond",
                SortOrder = 4,
                Value = 3
            };
    }
}