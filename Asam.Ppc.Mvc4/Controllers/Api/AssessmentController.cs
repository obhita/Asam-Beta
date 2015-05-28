using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using Agatha.Common;
using Asam.Ppc.Mvc.Infrastructure.Security;
using Asam.Ppc.Mvc.Infrastructure.Service;
using Asam.Ppc.Mvc4.Models;
using Asam.Ppc.Service.Messages.Assessment;
using Asam.Ppc.Service.Messages.AssessmentReport;
using Asam.Ppc.Service.Messages.Core;

namespace Asam.Ppc.Mvc4.Controllers.Api
{
    using System.Collections.Generic;

    public class AssessmentController : BaseApiController
    {
        private readonly IPatientAccessControlManager _patientAccessControlManager;
        private const string AppendixFilePath = "~/Content/StaticFiles/AsamPpcAppendix.pdf";
        private const string ReportTemplateFilePath = "~/Content/StaticFiles/";

        public AssessmentController(IRequestDispatcherFactory requestDispatcherFactory, IPatientAccessControlManager patientAccessControlManager)
            : base(requestDispatcherFactory)
        {
            _patientAccessControlManager = patientAccessControlManager;
        }

        [HttpGet]
        [BusinessTransactionLogFilter]
        public async Task<AssessmentDto> Get(long id)
        {
            AssessmentDto assessmentDto = null;
            var patientRequestDisptacher = CreateAsyncRequestDispatcher();
            patientRequestDisptacher.Add(new GetPatientDtoByAssessmentKeyRequest { AssessmentKey = id });

            var patientResponse = patientRequestDisptacher.Get<GetPatientDtoResponse>();

            if ( patientResponse != null && patientResponse.DataTransferObject != null &&
                 _patientAccessControlManager.CanAccessPatient ( patientResponse.DataTransferObject.Key ) )
            {
                var requestDispatcher = CreateAsyncRequestDispatcher();
                requestDispatcher.Add(new GetAssessmentByKeyRequest { AssessmentKey = id });
                var response = await requestDispatcher.GetAsync<GetAssessmentResponse>();
                assessmentDto = response.DataTransferObject;
                if (assessmentDto == null)
                {
                    HttpContext.Current.Response.StatusCode = (int)HttpStatusCode.NotFound;
                }
            }
            return assessmentDto;
        }

        [HttpPost]
        [BusinessTransactionLogFilter]
        public async Task<KeyResult> Post(long id, [FromBody]IDictionary<string, string> assessmentMetaData) 
        {
            if (_patientAccessControlManager.CanAccessPatient(id) && ModelState.IsValid)
            {
                var requestDispatcher = CreateAsyncRequestDispatcher();
                requestDispatcher.Add(new CreateAssessmentRequest { PatientId = id, AssessmentMetaData = assessmentMetaData });
                var response = await requestDispatcher.GetAsync<CreateAssessmentResponse>();
                return new KeyResult { Key = response.AssessmentId };
            }
            HttpContext.Current.Response.StatusCode = (int)HttpStatusCode.NotFound;
            return null;
        }

        [HttpGet]
        [BusinessTransactionLogFilter]
        public async Task<HttpResponseMessage> Report(long id)
        {
            var response = new HttpResponseMessage(HttpStatusCode.OK);
            try
            {
                var patientRequestDisptacher = CreateAsyncRequestDispatcher();
                patientRequestDisptacher.Add(new GetPatientDtoByAssessmentKeyRequest { AssessmentKey = id });

                var patientResponse = patientRequestDisptacher.Get<GetPatientDtoResponse>();
                if (patientResponse != null && patientResponse.DataTransferObject != null &&
                     _patientAccessControlManager.CanAccessPatient(patientResponse.DataTransferObject.Key))
                {
                    var requestDispatcher = CreateAsyncRequestDispatcher();
                    requestDispatcher.Add(new ViewReportRequest
                    {
                        AssessmentKey = id,
                        ReportTempalteFilePath = HttpContext.Current.Server.MapPath(ReportTemplateFilePath),
                        AppendixFilePath = HttpContext.Current.Server.MapPath(AppendixFilePath),
                        InterviewerName = PatientAccessControlManager.GetCurrentUserName(),
                    });

                    var viewReportResponse = await requestDispatcher.GetAsync<FileStreamResponse>();
                    if (viewReportResponse.FileStream != null)
                    {
                        var stream = new MemoryStream(viewReportResponse.FileStream) { Position = 0 };
                        response.Content = new StreamContent(stream);

                        response.Content.Headers.ContentDisposition =
                            new ContentDispositionHeaderValue("attachment")
                            {
                                FileName = string.Format("AssessmentReport_{0}.pdf", id)
                            };
                        response.Content.Headers.ContentType = new MediaTypeHeaderValue("application/pdf");
                    }
                    else
                    {
                        response.StatusCode = HttpStatusCode.NotFound;
                    }
                }
                else
                {
                    response.StatusCode = HttpStatusCode.NotFound;
                }
            }
            catch (IOException)
            {
                response.StatusCode = HttpStatusCode.InternalServerError;
            }
            return response;
        }
    }
}
