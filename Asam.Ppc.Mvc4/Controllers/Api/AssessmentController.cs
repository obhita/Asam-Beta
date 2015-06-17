using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using Agatha.Common;
using Asam.Ppc.Mvc.Infrastructure.Security;
using Asam.Ppc.Mvc4.Models;
using Asam.Ppc.Service.Messages.Assessment;
using Asam.Ppc.Service.Messages.AssessmentReport;
using Asam.Ppc.Service.Messages.Core;

namespace Asam.Ppc.Mvc4.Controllers.Api
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using Primitives;
    using Service.Messages.Common;
    using Service.Messages.Common.Lookups;

    public class AssessmentController : BaseApiController
    {
        private readonly IPatientAccessControlManager _patientAccessControlManager;
        private readonly string _appendixFilePath = "~/Content/StaticFiles/AsamPpcAppendix.pdf";
        private readonly string _reportTemplateFilePath = "~/Content/StaticFiles/";

        public AssessmentController(IRequestDispatcherFactory requestDispatcherFactory, IPatientAccessControlManager patientAccessControlManager)
            : base(requestDispatcherFactory)
        {
            _patientAccessControlManager = patientAccessControlManager;
        }

        [HttpGet]
        public async Task<AssessmentDto> Get(long id)
        {
            AssessmentDto assessmentDto = null;
            var patientRequestDisptacher = CreateAsyncRequestDispatcher();
                patientRequestDisptacher.Add(new GetPatientDtoByAssessmentKeyRequest { AssessmentKey = id });

            var patientResponse = patientRequestDisptacher.Get<GetPatientDtoResponse>();

            if ( patientResponse != null && patientResponse.DataTransferObject != null &&
                 _patientAccessControlManager.CanAccessPatient ( patientResponse.DataTransferObject.Key ) )
            {
                var requestDispatcher = CreateAsyncRequestDispatcher ();
                requestDispatcher.Add ( new GetAssessmentByKeyRequest {AssessmentKey = id} );
                var response = await requestDispatcher.GetAsync<GetAssessmentResponse> ();

                assessmentDto = response.DataTransferObject;
            }
            if (assessmentDto == null)
            {
                HttpContext.Current.Response.StatusCode = (int)HttpStatusCode.NotFound;
            }
            return assessmentDto;
        }

        public async Task<KeyResult> Post(long id) // Note: key = patient key
        {
            if (_patientAccessControlManager.CanAccessPatient(id) && ModelState.IsValid)
            {
                var requestDispatcher = CreateAsyncRequestDispatcher();
                requestDispatcher.Add(new CreateAssessmentRequest { PatientId = id });
                var response = await requestDispatcher.GetAsync<CreateAssessmentResponse>();
                return new KeyResult { Key = response.AssessmentId };
            }
            HttpContext.Current.Response.StatusCode = (int)HttpStatusCode.NotFound;
            return null;
        }

        [HttpGet]
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
                            ReportTempalteFilePath = HttpContext.Current.Server.MapPath(_reportTemplateFilePath),
                            AppendixFilePath = HttpContext.Current.Server.MapPath(_appendixFilePath),
                            InterviewerName = PatientAccessControlManager.GetCurrentUserName(),
                        });

                    var viewReportResponse = await requestDispatcher.GetAsync<FileStreamResponse>();
                    if (viewReportResponse.FileStream != null)
                    {
                        var stream = new MemoryStream(viewReportResponse.FileStream) { Position = 0 };
                        response.Content = new StreamContent ( stream );

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

        [HttpGet]
        public HttpResponseMessage CsvFile(long id)
        {
            var response = new HttpResponseMessage(HttpStatusCode.OK);
            try
            {
                var requestDisptacher = CreateAsyncRequestDispatcher();
                requestDisptacher.Add(new GetPatientDtoByAssessmentKeyRequest { AssessmentKey = id });
                requestDisptacher.Add(new GetAssessmentByKeyRequest { AssessmentKey = id });

                var patientResponse = requestDisptacher.Get<GetPatientDtoResponse>();
                var assessmentResponse = requestDisptacher.Get<GetAssessmentResponse> ();


                if ( patientResponse != null && patientResponse.DataTransferObject != null &&
                     _patientAccessControlManager.CanAccessPatient ( patientResponse.DataTransferObject.Key ) &&
                     assessmentResponse.DataTransferObject != null )
                {

                    var stream = new MemoryStream {Position = 0};
                    var writer = new StreamWriter ( stream );
                    RecurseHelper( assessmentResponse.DataTransferObject, writer );
                    writer.Flush ();
                    stream.Flush ();
                    stream.Position = 0;
                    response.Content = new StreamContent ( stream );

                    response.Content.Headers.ContentDisposition =
                        new ContentDispositionHeaderValue ( "attachment" )
                            {
                                FileName = string.Format ( "AssessmentExport_{0}_{1}_{2}_{3}.csv", 
                                                           patientResponse.DataTransferObject.Name.FirstName,
                                                           patientResponse.DataTransferObject.Name.LastName,
                                                           assessmentResponse.DataTransferObject.CreatedTimestamp.ToShortDateString (),
                                                           id)
                            };
                    response.Content.Headers.ContentType = new MediaTypeHeaderValue("text/csv");
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

        [HttpGet]
        public async Task<HttpResponseMessage> GetAssessmentExcelFile(long id)
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
                    requestDispatcher.Add(new ExportToExcelRequest 
                    {
                        AssessmentKey = id
                    });

                    var viewReportResponse = await requestDispatcher.GetAsync<FileStreamResponse>();
                    if (viewReportResponse.FileStream != null)
                    {
                        var stream = new MemoryStream(viewReportResponse.FileStream) { Position = 0 };
                        response.Content = new StreamContent(stream);

                        response.Content.Headers.ContentDisposition =
                            new ContentDispositionHeaderValue("attachment")
                            {
                                FileName = string.Format("AssessmentExport_{0}.xlsx", id)
                            };
                        response.Content.Headers.ContentType = new MediaTypeHeaderValue("application/vnd.ms-excel");
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

        [HttpGet]
        public async Task<HttpResponseMessage> GetAssessmentScoreExcelFile(long id)
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
                    requestDispatcher.Add(new ExportToExcelRequest
                    {
                        AssessmentKey = id,
                        GetScore = true
                    });

                    var viewReportResponse = await requestDispatcher.GetAsync<FileStreamResponse>();
                    if (viewReportResponse.FileStream != null)
                    {
                        var stream = new MemoryStream(viewReportResponse.FileStream) { Position = 0 };
                        response.Content = new StreamContent(stream);

                        response.Content.Headers.ContentDisposition =
                            new ContentDispositionHeaderValue("attachment")
                            {
                                FileName = string.Format("AssessmentScoreExport_{0}.xlsx", id)
                            };
                        response.Content.Headers.ContentType = new MediaTypeHeaderValue("application/vnd.ms-excel");
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

        private List<string> _propertiesToIgnore = new List<string> { "Patient", "AllVisited", "IsCompleted", "CreatedSystemAccount", "UpdatedSystemAccount", "DataErrorInfoCollection", "MetadataDto" }; 

        /// <summary>
        /// Recurses the helper.
        /// </summary>
        /// <param name="entity">The entity.</param>
        private void RecurseHelper(object entity, StreamWriter writer)
        {
            if (entity == null)
            {
                return;
            }
            var entityType = entity.GetType ();
            var prefix = entityType == typeof(AssessmentDto) ? "" : entityType.Name + ",";
            var entityProperties = entityType.GetProperties();
            foreach ( var entityProperty in entityProperties )
            {
                var line = string.Empty;
                if ( _propertiesToIgnore.Contains ( entityProperty.Name ) )
                {
                    continue;
                }
                if ( typeof(SectionDtoBase).IsAssignableFrom ( entityProperty.PropertyType ) )
                {
                    var revisionBase = entityProperty.GetValue ( entity ) as SectionDtoBase;

                    RecurseHelper ( revisionBase, writer );
                }
                else
                {
                    line += (prefix + entityProperty.Name + ",");
                    if ( entityType == typeof(AssessmentDto) )
                    {
                        line += ",";
                    }
                    var propertyValue = entityProperty.GetValue ( entity );
                    if ( propertyValue == null )
                    {
                        line += "null,";
                    }
                    else if ( typeof(LookupDto).IsAssignableFrom ( entityProperty.PropertyType ) )
                    {
                        line += ( propertyValue as LookupDto ).Value;
                    }
                    else if ( entityProperty.PropertyType.IsGenericType && entityProperty.PropertyType.GetGenericTypeDefinition () == typeof(IEnumerable<>) )
                    {
                        var innerType = entityProperty.PropertyType.GetGenericArguments ().First ();
                        foreach ( var innerValue in ( propertyValue as IEnumerable ) )
                        {
                            if ( typeof(LookupDto).IsAssignableFrom ( innerType ) )
                            {
                                line += ( innerValue as LookupDto ).Value + ",";
                            }
                            else
                            {
                                line += innerValue + ",";
                            }
                        }
                        line = line.Substring ( 0, line.Length - 1 );
                    }
                    else if (entityProperty.PropertyType == typeof(TimeSpanPicker))
                    {
                        line += (propertyValue as TimeSpanPicker).TotalMonths ();
                    }
                    else if (entityProperty.PropertyType == typeof(Scale))
                    {
                        line += (propertyValue as Scale).Value;
                    }
                    else if ( typeof(IPrimitive).IsAssignableFrom ( entityProperty.PropertyType ) )
                    {
                        foreach ( var propertyInfo in entityProperty.PropertyType.GetProperties() )
                        {
                            line = null;
                            writer.WriteLine(prefix + entityProperty.Name + "_" + propertyInfo.Name + ","+ propertyInfo.GetValue(propertyValue));
                        }
                    }
                    else if ( entityProperty.PropertyType == typeof(MoneyDto) )
                    {
                        line += ( propertyValue as MoneyDto ).Amount;
                    }
                    else
                    {
                        line += propertyValue;
                    }
                    if ( line != null )
                    {
                        writer.WriteLine(line);
                    }
                }
            }
        }
    }
}
