using System;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Agatha.Common;
using Asam.Ppc.Mvc.Infrastructure;
using Asam.Ppc.Mvc.Infrastructure.Security;
using Asam.Ppc.Primitives;
using Asam.Ppc.Service.Messages.Common;
using Asam.Ppc.Service.Messages.Core;

namespace Asam.Ppc.Mvc4.Controllers
{
    using Domain.CommonModule.Lookups;
    using Service.Messages.Common.Lookups;

    public class PatientController : BaseController
    {
        public PatientController(IRequestDispatcherFactory requestDispatcherFactory, IPatientAccessControlManager patientAccessControlManager)
            : base ( requestDispatcherFactory, patientAccessControlManager )
        {
        }

        public async Task<ActionResult> Index(long id = 0, string assessmentId = null)
        {
            object model = null;
            if (id != 0 && _patientAccessControlManager.CanAccessPatient(id))
            {
                var requestDispatcher = CreateAsyncRequestDispatcher ();
                requestDispatcher.Add(new GetPatientDtoByKeyRequest { PatientKey = id });
                var response = await requestDispatcher.GetAsync<GetPatientDtoResponse> ();

                if (response.DataTransferObject == null)
                {
                    throw new HttpException(404, "Patient record not found.");   
                }
                model = response.DataTransferObject;
                ViewData["Patient"] = response.DataTransferObject;
            }
            else if ( !_patientAccessControlManager.CanAccessAllPatients )
            {
                return HttpNotFound ();
            }

            ViewData["AssessmentId"] = assessmentId;

            return View (model);
        }

        public async Task<ActionResult> Create( string assessmentId = null )
        {
            var patientDto = new PatientDto ();
            patientDto.Name = new PersonName("X","X");

            //TODO: Pilot Only
            patientDto.Gender = new LookupDto {Code = Gender.Female.Code};
            patientDto.DateOfBirth = new DateTime(2001,1,1);

            var requestDispatcher = CreateAsyncRequestDispatcher();
            AddLookupRequests(requestDispatcher, typeof(PatientDto));
            requestDispatcher.Add(new CreatePatientRequest { PatientDto = patientDto });
            var response = await requestDispatcher.GetAsync<SaveDtoResponse<PatientDto>>();
            AddLookupResponsesToViewData(requestDispatcher);
            return RedirectToAction ( "Edit", new {id = response.DataTransferObject.Key} );
            ViewData["AssessmentId"] = assessmentId;
            ViewData["Patient"] = patientDto;

            return View ( "Edit", patientDto );
        }

        public async Task<ActionResult> Edit(long id, string assessmentId = null)
        {
            if (_patientAccessControlManager.CanAccessPatient(id))
            {
                var requestDispatcher = CreateAsyncRequestDispatcher ();
                requestDispatcher.Add(new GetPatientDtoByKeyRequest { PatientKey = id });
                AddLookupRequests ( requestDispatcher, typeof(PatientDto) );
                var response = await requestDispatcher.GetAsync<GetPatientDtoResponse> ();
                AddLookupResponsesToViewData ( requestDispatcher );

                if (response.DataTransferObject == null)
                {
                    throw  new HttpException(404, "Patient record not found.");
                }

                ViewData["AssessmentId"] = assessmentId;
                ViewData["Patient"] = response.DataTransferObject;

                return View ( response.DataTransferObject );
            }
            return HttpNotFound ();
        }

        [HttpPost]
        public async Task<ActionResult> Edit(long id, PatientDto patientDto, string assessmentId = null)
        {
            patientDto.Key = id;
            if ( _patientAccessControlManager.CanAccessPatient ( patientDto.Key ) )
            {
                var requestDispatcher = CreateAsyncRequestDispatcher ();
                if ( patientDto.Key == 0 )
                {
                    requestDispatcher.Add ( new CreatePatientRequest {PatientDto = patientDto} );
                }
                else
                {
                    requestDispatcher.Add ( new SaveDtoRequest<PatientDto> {DataTransferObject = patientDto} );
                }
                var response = await requestDispatcher.GetAsync<SaveDtoResponse<PatientDto>> ();

                if (response.DataTransferObject == null)
                {
                    throw new HttpException(500, "Patient cannot be saved.");
                }

                var view = this.HandleErrorsAndWarnings(
                    response.DataTransferObject.DataErrorInfoCollection, response.Notification,
                    () => {
                            requestDispatcher = CreateAsyncRequestDispatcher();
                            AddLookupRequests(requestDispatcher, typeof (PatientDto));
                            AddLookupResponsesToViewData(requestDispatcher);
                            ViewData["AssessmentId"] = assessmentId;
                            ViewData["Patient"] = patientDto;

                            return View(patientDto);
                        });

               if (view != null)
               {
                   return view;
               }

                return RedirectToAction ( "Index", new {id = response.DataTransferObject.Key, assessmentId} );
            }
            return HttpNotFound ();
        }

        public ActionResult Cancel(string id, string assessmentId = null)
        {
            return RedirectToAction ( "Index", new { id, assessmentId} );
        }
    }
}
