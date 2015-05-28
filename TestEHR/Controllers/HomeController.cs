using System.Text;
using System.Web.Configuration;
using Newtonsoft.Json;

namespace TestEHR.Controllers
{
    #region Using Statements

    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Threading.Tasks;
    using System.Web.Mvc;
    using Models;

    #endregion

    public class HomeController : Controller
    {
        public static long EhrId = 1;
        public static long OrganizationId = 1;
        public static string ApiKey = "7LL3KCGXVSJNFUZET35OZKNEU5FE6UHP7IADIQFS"; 
        public static string BaseUri = "";
        public static string BaseUriApp = "";

        public HomeController()
        {
            if (string.IsNullOrWhiteSpace(BaseUri)) {
                BaseUri = WebConfigurationManager.AppSettings["BaseUri"];
            }
        }

        private static readonly List<PatientViewModel> CreatedPatients = new List<PatientViewModel>
            {
                new PatientViewModel {PatientKey = "1001", PatientName = "Jane Jones", AssessmentKeys = new List<string> {"1002", "2002"}},
                new PatientViewModel {PatientKey = "1002", PatientName = "John Doe", AssessmentKeys = new List<string> {"1001"}},
                new PatientViewModel {PatientKey = "50050", PatientName = "Sam Jones", AssessmentKeys = new List<string> {"51052"}}
            };

        public ActionResult ChangeBaseUri(string apiKey, string baseUri)
        {
            BaseUri = baseUri;
            ApiKey = apiKey;
            var homeViewModel = new HomeViewModel
            {
                Patients = CreatedPatients,
                ErrorMessage = null,
                BaseUri = BaseUri,
                ApiKey = apiKey
            };
            return RedirectToAction("Index", homeViewModel);
        }

        public ActionResult Index ( string errorMessage = null )
        {
            return View ( new HomeViewModel
                {
                    Patients = CreatedPatients,
                    ErrorMessage = errorMessage,
                    BaseUri = BaseUri,
                    ApiKey = ApiKey
                } );
        }

        public async Task<ActionResult> CreateAssessment ( string id )
        {
            var httpRequest = new HttpClient ();
            httpRequest.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var userModel = new UserModel
            {
                EhrId = EhrId,
                ApiKey = ApiKey,
                Email = "fred.jones@blah.com",
                OrganizationId = OrganizationId,
                Username = "Fred Jones",
                PatientId = long.Parse(id),
                UserId = 123
            };
            CertSignService.SetSignedCertificateHeader(httpRequest, userModel);
            IDictionary<string, string> metaData = new Dictionary<string, string>();
            metaData.Add("PatientZipCode", "12345");
            metaData.Add("ProviderDegree", "Degree");
            metaData.Add("PatientData1", "Data1");

            HttpContent content = new StringContent(JsonConvert.SerializeObject(metaData), Encoding.UTF8, "application/json");

            var response = await httpRequest.PostAsync(BaseUri + "api/Assessment/post/" + id, content);

            if ( response.StatusCode == HttpStatusCode.OK )
            {
                var key = ( await response.Content.ReadAsAsync<KeyResult> () ).Key;
                var patient = CreatedPatients.First ( p => p.PatientKey == id );
                patient.AssessmentKeys.Add ( key );
                return RedirectToAction ( "Index" );
            }
            return RedirectToAction ( "Index", new {errorMessage = "Error Creating Assessment."} );
        }

        [HttpPost]
        public async Task<ActionResult> GetAssessmentData ( string assessmentId, string patientId )
        {
            var httpRequest = new HttpClient();
            httpRequest.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var userModel = new UserModel
            {
                EhrId = EhrId,
                ApiKey = ApiKey,
                Email = "fred.jones@blah.com",
                OrganizationId = OrganizationId,
                Username = "Fred Jones",
                PatientId = long.Parse(patientId),
                UserId = 123
            };
            CertSignService.SetSignedCertificateHeader(httpRequest, userModel);
            var response = await httpRequest.GetAsync ( BaseUri + "api/Assessment/Get/" + assessmentId );

            if ( response.StatusCode == HttpStatusCode.OK )
            {
                var assessment = await response.Content.ReadAsStringAsync ();
                return View ( "Index",
                              new HomeViewModel
                                  {
                                      AssessmentData = assessment,
                                      Patients = CreatedPatients,
                                      BaseUri = BaseUri,
                                      ApiKey = ApiKey
                                  });
            }
            return RedirectToAction ( "Index", new {errorMessage = "Error Getting Assessment Data."} );
        }

        [HttpPost]
        public async Task<ActionResult> GetAssessmentReport ( string assessmentId )
        {
            var httpRequest = new HttpClient ();
            httpRequest.DefaultRequestHeaders.Accept.Add (
                                                          new MediaTypeWithQualityHeaderValue ( "application/json" ) );

            var userModel = new UserModel
            {
                EhrId = EhrId,
                ApiKey = ApiKey,
                Email = "fred.jones@blah.com",
                OrganizationId = OrganizationId,
                Username = "Fred Jones",
                PatientId = 50050,
                UserId = 123
            };
            CertSignService.SetSignedCertificateHeader(httpRequest, userModel);

            var response = await httpRequest.GetAsync ( BaseUri + "api/Assessment/Report/" + assessmentId );
            await response.Content.ReadAsStringAsync ();
            if ( response.StatusCode == HttpStatusCode.OK )
            {
                return File(await response.Content.ReadAsByteArrayAsync(), "application/pdf", string.Format("AssessmentReport_{0}.pdf", assessmentId));
            }
            return RedirectToAction ("Index", new {errorMessage = "Error Getting Assessment Report."} );
        }

        [HttpPost]
        public async Task<ActionResult> CreatePatient ( string firstName, string lastName, string dateOfBirth, string gender )
        {
            if (dateOfBirth == null) throw new ArgumentNullException("dateOfBirth");
            if (gender == null) throw new ArgumentNullException("gender");

            var httpRequest = new HttpClient ();
            httpRequest.DefaultRequestHeaders.Accept.Add (new MediaTypeWithQualityHeaderValue ( "application/json" ) );
            var userModel = new UserModel
            {
                EhrId = EhrId,
                ApiKey = ApiKey,
                Email = "fred.jones@blah.com",
                OrganizationId = OrganizationId,
                Username = "Fred Jones",
                PatientId = 0,
                UserId = 123
            };
            CertSignService.SetSignedCertificateHeader(httpRequest, userModel);
            dateOfBirth = "1/1/2001";
            var response = await httpRequest.PostAsJsonAsync ( BaseUri + "api/Patient/",
                                                               new PatientDto
                                                                   {
                                                                       Name = new PersonName ( firstName, lastName ),
                                                                       DateOfBirth = DateTime.Parse ( dateOfBirth ),
                                                                       Gender = new LookupDto {Code = gender},
                                                                       Ethnicity = new LookupDto { Code = "Undeclared" },
                                                                       Religion = new LookupDto { Code = "Other" }
                                                                   } );

            if ( response.StatusCode == HttpStatusCode.OK )
            {
                var key = ( await response.Content.ReadAsAsync<KeyResult> () ).Key;
                CreatedPatients.Add ( new PatientViewModel
                    {
                        PatientKey = key,
                        PatientName = firstName + " " + lastName
                    } );
                return RedirectToAction ( "Index" );
            }
            return RedirectToAction ( "Index", new {errorMessage = "Error Creating Patient."} );
        }
    }
}