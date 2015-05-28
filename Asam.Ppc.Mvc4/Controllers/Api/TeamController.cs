namespace Asam.Ppc.Mvc4.Controllers.Api
{
    #region Using Statements

    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Web.Http;
    using Agatha.Common;
    using Models;
    using Service.Messages.Common;
    using Service.Messages.Organization;

    #endregion

    public class TeamController : BaseApiController
    {

        #region Public Methods and Operators

        public TeamController(IRequestDispatcherFactory requestDispatcherFactory)
            : base ( requestDispatcherFactory )
        {}

        public async Task<DataTableResponse<TeamSummaryDto>> Get ( string sEcho, int iDisplayStart, int iDisplayLength, string sSearch = null )
        {
            var requestDispatcher = CreateAsyncRequestDispatcher();
            requestDispatcher.Add(new PagedSearchRequest<TeamSummaryDto> { Keyword = sSearch, Page = iDisplayStart / iDisplayLength, PageSize = iDisplayLength });
            var response = await requestDispatcher.GetAsync<PagedSearchResponse<TeamSummaryDto>>();
            return new DataTableResponse<TeamSummaryDto>
            {
                Data = response.Results ?? Enumerable.Empty<TeamSummaryDto> (),
                Echo = sEcho,
                TotalDisplayRecords = response.TotalCount,
                TotalRecords = response.TotalCount
            };
        }

        [HttpGet]
        public async Task<FinderResults<TeamSummaryDto>> FinderSearch(int page, int pageSize, string search = null)
        {
            var requestDispatcher = CreateAsyncRequestDispatcher();
            requestDispatcher.Add(new PagedSearchRequest<TeamSummaryDto> { Keyword = search, Page = page, PageSize = pageSize });
            var response = await requestDispatcher.GetAsync<PagedSearchResponse<TeamSummaryDto>>();
            return new FinderResults<TeamSummaryDto>
                {
                    Data = response.Results,
                    TotalCount = response.TotalCount
                };
        }

        [HttpGet]
        public async Task<IEnumerable<TeamSummaryDto>> GetByStaffKey ( long staffKey )
        {
            var requestDispatcher = CreateAsyncRequestDispatcher();
            requestDispatcher.Add ( new GetTeamsByStaffKeyRequest { StaffKey = staffKey} );
            var response = await requestDispatcher.GetAsync<DtoCollectionResponse<TeamSummaryDto>> ();
            return response.Dtos;
        }

        [HttpGet]
        public async Task<IEnumerable<TeamSummaryDto>> GetByPatientKey(long patientKey)
        {
            var requestDispatcher = CreateAsyncRequestDispatcher();
            requestDispatcher.Add(new GetTeamsByPatientKeyRequest { PatientKey = patientKey });
            var response = await requestDispatcher.GetAsync<DtoCollectionResponse<TeamSummaryDto>>();
            return response.Dtos;
        }

        #endregion
    }
}