using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Asam.Ppc.Mvc4.Models
{
    public class SingleSignOnRequest
    {
        public string PatientId { get; set; }
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string UserEmail { get; set; }
        public string AssessmentId { get; set; }
        public string Token { get; set; }
    }
}