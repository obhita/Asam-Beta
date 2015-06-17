using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Asam.Ppc.Service.Messages.Core;

namespace TestEHR.Models
{
    public class PatientViewModel
    {
        public PatientViewModel ()
        {
            AssessmentKeys = new List<string> ();
        }

        public string PatientKey { get; set; }
        public string PatientName { get; set; }
        public List<string> AssessmentKeys { get; set; }
    }
}