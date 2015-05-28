using System;
using System.Web.Mvc;
using TestEHR.Models;

namespace TestEHR.Controllers
{
    public class PatientController : Controller
    {
        public ActionResult Index(string id, string assessmentId = null)
        {
            const string username = "Fred Jones";
            const string userEmail = "fred.jones@blah.com";
            const int userId = 123;
            const string apiKey = "7LL3KCGXVSJNFUZET35OZKNEU5FE6UHP7IADIQFS";

            var timestamp = DateTime.Now.ToString();
            var tokenString = string.Format("EhrId={0}&OrganizationId={1}&UserId={2}&UserName={3}&UserEmail={4}&PatientId={5}&Timestamp={6}&AssessmentId={7}&ApiKey={8}",
                1, 
                1, 
                userId,
                username,
                userEmail, 
                id,
                timestamp, 
                assessmentId,
                apiKey);
            var signature = CertSignService.SignCertificate(tokenString);
            var model = new RequestModel
            {
                Url = HomeController.BaseUri + "SingleSignOn/?patientId=" + id + "&timestamp=" + timestamp + "&assessmentId=" + assessmentId,
                PatientId = id,
                AssessmentId = assessmentId,
                UserId = userId.ToString(),
                UserName = username,
                UserEmail = userEmail,
                Timestamp = timestamp,
                Token = Convert.ToBase64String(signature),
                OrganizationId = 1,
                EhrId = 1
            };
            return View(model);
        }
    }
}
