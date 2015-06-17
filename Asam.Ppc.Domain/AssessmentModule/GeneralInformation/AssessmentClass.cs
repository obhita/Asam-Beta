using Asam.Ppc.Domain.CommonModule;

namespace Asam.Ppc.Domain.AssessmentModule.GeneralInformation
{
    public class AssessmentClass : Lookup
    {
        /// <summary>
        ///     Intake = 1.
        /// </summary>
        public static readonly AssessmentClass Intake = new AssessmentClass
            {
                Code = "Intake",
                SortOrder = 1,
                Value = 1
            };

        /// <summary>
        ///     FollowUp = 2.
        /// </summary>
        public static readonly AssessmentClass FollowUp = new AssessmentClass
            {
                Code = "FollowUp",
                SortOrder = 2,
                Value = 2
            };
    }
}