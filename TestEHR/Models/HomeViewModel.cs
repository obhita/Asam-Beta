using System.Collections.Generic;

namespace TestEHR.Models
{
    public class HomeViewModel
    {
        public IEnumerable<PatientViewModel> Patients { get; set; }
        public string ErrorMessage { get; set; }

        public string AssessmentData { get; set; }

        public string ApiKey { get; set; }

        public string BaseUri { get; set; }
    }
}