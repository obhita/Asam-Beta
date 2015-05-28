using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using Agatha.Common;
using Asam.Ppc.Mvc.Infrastructure.Security;
using Asam.Ppc.Mvc4.Models;
using Asam.Ppc.Service.Messages.Core;

namespace Asam.Ppc.Mvc4.Controllers.Api
{
    public class PatientSearchDataTableController : BaseApiController
    {
        private readonly IPatientAccessControlManager _patientAccessControlManager;

        public PatientSearchDataTableController(IRequestDispatcherFactory requestDispatcherFactory, IPatientAccessControlManager patientAccessControlManager)
            : base ( requestDispatcherFactory )
        {
            _patientAccessControlManager = patientAccessControlManager;
        }

        public async Task<DataTableResponse<PatientDto>> Get(string sEcho, int iDisplayStart, int iDisplayLength, string sSearch)
        {
            if ( _patientAccessControlManager.CanAccessAllPatients )
            {
                var request = new PatientSearchByKeywordRequest
                    {
                        Keyword = sSearch,
                        PageIndex = iDisplayStart/iDisplayLength,
                        PageSize = iDisplayLength
                    };

                var requestDispatcher = CreateAsyncRequestDispatcher ();
                requestDispatcher.Add ( request );
                var result = await requestDispatcher.GetAsync<PatientSearchResponse> ();

                var dataTableResponse = new DataTableResponse<PatientDto>
                    {
                        Data = result.Patients,
                        Echo = sEcho,
                        TotalDisplayRecords = result.TotalCount,
                        TotalRecords = result.TotalCount
                    };

                return dataTableResponse;
            }

            HttpContext.Current.Response.StatusCode = (int) HttpStatusCode.NotFound;
            return null;
        }
    }
}