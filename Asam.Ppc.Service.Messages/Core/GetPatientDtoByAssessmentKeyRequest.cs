using Agatha.Common;

namespace Asam.Ppc.Service.Messages.Core
{
    /// <summary>
    /// Class GetPatientDtoByAssessmentKeyRequest
    /// </summary>
    public class GetPatientDtoByAssessmentKeyRequest : Request
    {
        /// <summary>
        /// Gets or sets the assessment key.
        /// </summary>
        /// <value>The assessment key.</value>
        public long AssessmentKey { get; set; }
    }
}
