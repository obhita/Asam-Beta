using Agatha.Common;

namespace Asam.Ppc.Service.Messages.Core
{
    public class GetPatientAssessmentsRequest : Request
    {
        /// <summary>
        /// Gets or sets the Patient key.
        /// </summary>
        /// <value>The Patient key.</value>
        public long PatientKey { get; set; }

        public int PageIndex { get; set; }
        public int PageSize { get; set; }
    }
}