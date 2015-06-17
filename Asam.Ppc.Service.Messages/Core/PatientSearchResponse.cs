using System.Collections.Generic;
using Agatha.Common;

namespace Asam.Ppc.Service.Messages.Core
{
    public class PatientSearchResponse : Response
    {
        public IEnumerable<PatientDto> Patients { get; set; }
        public int TotalCount { get; set; }
    }
}
