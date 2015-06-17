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
    using Asam.Ppc.Primitives;
    using Asam.Ppc.Service.Messages.Common.Lookups;
    using Asam.Ppc.Service.Messages.Core;
    using Models;

    #endregion

    public class HomeController : Controller
    {
        public static string BaseUri = "https://localhost:44300/";

        private static readonly List<PatientViewModel> _createdPatients = new List<PatientViewModel>
            {
                new PatientViewModel {PatientKey = "1001", PatientName = "Jane Jones", AssessmentKeys = new List<string> {"1002", "2002"}},
                new PatientViewModel {PatientKey = "1002", PatientName = "John Doe", AssessmentKeys = new List<string> {"1001"}}
            };

        public ActionResult ChangeBaseUri ( string baseUri )
        {
            BaseUri = baseUri;
            return RedirectToAction ( "Index" );
        }

        //
        // GET: /Home/

        public ActionResult Index ( string errorMessage = null )
        {
            return View ( new HomeViewModel
                {
                    Patients = _createdPatients,
                    ErrorMessage = errorMessage,
                    BaseUri = BaseUri
                } );
        }

        public async Task<ActionResult> CreateAssessment ( string id )
        {
            var httpRequest = new HttpClient ();
            httpRequest.DefaultRequestHeaders.Accept.Add (
                                                          new MediaTypeWithQualityHeaderValue ( "application/json" ) );

            var authHeaderString = "UserId=123&UserName=Fred Jones&UserEmail=fred.johns@blah.com&PatientId=" + id;

            var signature = CertSignService.SignCertificate ( authHeaderString );

            authHeaderString += "&Token=" + Convert.ToBase64String ( signature );

            httpRequest.DefaultRequestHeaders.Add ( "SSOAuth", authHeaderString );

            var response = await httpRequest.PostAsync ( BaseUri + "api/Assessment/Post/" + id, new StringContent ( "" ) );

            if ( response.StatusCode == HttpStatusCode.OK )
            {
                var key = ( await response.Content.ReadAsAsync<KeyResult> () ).Key;
                var patient = _createdPatients.First ( p => p.PatientKey == id );
                patient.AssessmentKeys.Add ( key );
                return RedirectToAction ( "Index" );
            }
            return RedirectToAction ( "Index", new {errorMessage = "Error Creating Assessment."} );
        }

        [HttpPost]
        public async Task<ActionResult> GetAssessmentData ( string assessmentId )
        {
            var httpRequest = new HttpClient ();
            httpRequest.DefaultRequestHeaders.Accept.Add (
                                                          new MediaTypeWithQualityHeaderValue ( "application/json" ) );

            var id = _createdPatients.First ( p => p.AssessmentKeys.Any ( a => a == assessmentId ) ).PatientKey;

            var authHeaderString = "UserId=123&UserName=Fred Jones&UserEmail=fred.johns@blah.com&PatientId=" + id;

            var signature = CertSignService.SignCertificate ( authHeaderString );

            authHeaderString += "&Token=" + Convert.ToBase64String ( signature );

            httpRequest.DefaultRequestHeaders.Add ( "SSOAuth", authHeaderString );

            var response = await httpRequest.GetAsync ( BaseUri + "api/Assessment/" + assessmentId );

            if ( response.StatusCode == HttpStatusCode.OK )
            {
                var assessment = await response.Content.ReadAsStringAsync ();
                return View ( "Index",
                              new HomeViewModel
                                  {
                                      Patients = _createdPatients,
                                      ErrorMessage = null,
                                      AssessmentData = assessment,
                                      BaseUri = BaseUri
                                  } );
            }
            return RedirectToAction ( "Index", new {errorMessage = "Error Getting Assessment Data."} );
        }

        [HttpPost]
        public async Task<ActionResult> GetAssessmentReport ( string assessmentId )
        {
            var httpRequest = new HttpClient ();
            httpRequest.DefaultRequestHeaders.Accept.Add (
                                                          new MediaTypeWithQualityHeaderValue ( "application/json" ) );

            var id = _createdPatients.First ( p => p.AssessmentKeys.Any ( a => a == assessmentId ) ).PatientKey;

            var authHeaderString = "UserId=123&UserName=Fred Jones&UserEmail=fred.johns@blah.com&PatientId=" + id;

            var signature = CertSignService.SignCertificate ( authHeaderString );

            authHeaderString += "&Token=" + Convert.ToBase64String ( signature );

            httpRequest.DefaultRequestHeaders.Add ( "SSOAuth", authHeaderString );

            var response = await httpRequest.GetAsync ( BaseUri + "api/Assessment/" + assessmentId + "/Report" );

            var responseContent = await response.Content.ReadAsStringAsync ();

            if ( response.StatusCode == HttpStatusCode.OK )
            {
                return File ( await response.Content.ReadAsByteArrayAsync (), "application/pdf" );
            }
            return RedirectToAction ( "Index", new {errorMessage = "Error Getting Assessment Report."} );
        }

        [HttpPost]
        public async Task<ActionResult> CreatePatient ( string firstName, string lastName, string dateOfBirth, string gender )
        {
            var httpRequest = new HttpClient ();
            httpRequest.DefaultRequestHeaders.Accept.Add (
                                                          new MediaTypeWithQualityHeaderValue ( "application/json" ) );

            var authHeaderString = "UserId=123&UserName=Fred Jones&UserEmail=fred.johns@blah.com";

            var signature = CertSignService.SignCertificate ( authHeaderString );

            authHeaderString += "&Token=" + Convert.ToBase64String ( signature );

            httpRequest.DefaultRequestHeaders.Add ( "SSOAuth", authHeaderString );

            //TODO: Pilot Only
            lastName = firstName = "X";
            dateOfBirth = "1/1/2001";
            gender = "Female";

            var response = await httpRequest.PostAsJsonAsync ( BaseUri + "api/Patient/",
                                                               new PatientDto
                                                                   {
                                                                       Name = new PersonName ( firstName, lastName ),
                                                                       DateOfBirth = DateTime.Parse ( dateOfBirth ),
                                                                       Gender = new LookupDto {Code = gender}
                                                                   } );

            if ( response.StatusCode == HttpStatusCode.OK )
            {
                var key = ( await response.Content.ReadAsAsync<KeyResult> () ).Key;
                _createdPatients.Add ( new PatientViewModel
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