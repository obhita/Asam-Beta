using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using Agatha.Common;
using Asam.Ppc.Mvc.Infrastructure.Security;
using Asam.Ppc.Mvc4.Models;
using Asam.Ppc.Service.Messages.Common;
using Asam.Ppc.Service.Messages.Core;

namespace Asam.Ppc.Mvc4.Controllers.Api
{
    public class PatientController : BaseApiController
    {
        private readonly IPatientAccessControlManager _patientAccessControlManager;

        public PatientController ( IRequestDispatcherFactory requestDispatcherFactory, IPatientAccessControlManager patientAccessControlManager )
            : base ( requestDispatcherFactory )
        {
            _patientAccessControlManager = patientAccessControlManager;
        }

        public async Task<PatientDto> Get(long key)
        {
            if (_patientAccessControlManager.CanAccessPatient(key))
            {
                var requestDispatcher = CreateAsyncRequestDispatcher ();
                requestDispatcher.Add(new GetPatientDtoByKeyRequest { PatientKey = key });
                var response = await requestDispatcher.GetAsync<GetPatientDtoResponse> ();

                var patientDto = response.DataTransferObject;
                if ( patientDto == null )
                {
                    throw new HttpResponseException ( new HttpResponseMessage ( HttpStatusCode.NotFound ) );
                }
                return patientDto;
            }
            HttpContext.Current.Response.StatusCode = (int) HttpStatusCode.NotFound;
            return null;
        }

        public async Task<KeyResult> Post (PatientDto patientDto)
        {
            if ( ModelState.IsValid )
            {
                var requestDispatcher = CreateAsyncRequestDispatcher ( );
                requestDispatcher.Add ( new CreatePatientRequest {PatientDto = patientDto} );
                var response = await requestDispatcher.GetAsync<SaveDtoResponse<PatientDto>> ( );
                return new KeyResult { Key = response.DataTransferObject.Key };
            }
            HttpContext.Current.Response.StatusCode = (int)HttpStatusCode.BadRequest;
            return null;
        }

        public async Task<KeyResult> Put(PatientDto patientDto)
        {
            if ( _patientAccessControlManager.CanAccessPatient ( patientDto.Key ) )
            {
                if ( ModelState.IsValid )
                {
                    var requestDispatcher = CreateAsyncRequestDispatcher ();
                    requestDispatcher.Add ( new SaveDtoRequest<PatientDto> {DataTransferObject = patientDto} );
                    var response = await requestDispatcher.GetAsync<SaveDtoResponse<PatientDto>> ();
                    return new KeyResult {Key = response.DataTransferObject.Key};
                }
                HttpContext.Current.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return null;
            }
            HttpContext.Current.Response.StatusCode = (int)HttpStatusCode.NotFound;
            return null;
        }
    }
}
