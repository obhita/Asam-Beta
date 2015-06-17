using System;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Web.Mvc;
using TestEHR.Models;

namespace TestEHR.Controllers
{
    public class PatientController : Controller
    {
        //
        // GET: /Patient/

        public ActionResult Index(string id, string assessmentId = null)
        {
            var timestamp = DateTime.Now.ToString();
            var testString = "PatientId=" + id + "&UserId=123&UserName=Fred Jones&UserEmail=fred.johns@blah.com&Timestamp=" + timestamp + "&AssessmentId=" + assessmentId ?? string.Empty;
            var signature = CertSignService.SignCertificate(testString);
            var model = new RequestModel
            {
                Url = HomeController.BaseUri + "SingleSignOn/",
                PatientId = id,
                AssessmentId = assessmentId,
                UserId = "123",
                UserName = "Fred Jones",
                UserEmail = "fred.johns@blah.com",
                Timestamp = timestamp,
                Token = Convert.ToBase64String(signature)
            };
            return View(model);
        }

    }
}
