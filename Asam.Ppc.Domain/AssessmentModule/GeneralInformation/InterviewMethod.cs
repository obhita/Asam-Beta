using Asam.Ppc.Domain.CommonModule;

namespace Asam.Ppc.Domain.AssessmentModule.GeneralInformation
{
    public class InterviewMethod : Lookup
    {
        /// <summary>
        ///     InPerson = 1.
        /// </summary>
        public static readonly InterviewMethod InPerson = new InterviewMethod
            {
                Code = "InPerson",
                SortOrder = 1,
                Value = 1
            };

        /// <summary>
        ///     ByPhone = 2.
        /// </summary>
        public static readonly InterviewMethod ByPhone = new InterviewMethod
            {
                Code = "ByPhone",
                SortOrder = 2,
                Value = 2
            };

        /// <summary>
        ///     ByMail = 3.
        /// </summary>
        public static readonly InterviewMethod ByMail = new InterviewMethod
            {
                Code = "ByMail",
                SortOrder = 3,
                Value = 3
            };
    }
}