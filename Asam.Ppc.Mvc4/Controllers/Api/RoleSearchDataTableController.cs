namespace Asam.Ppc.Mvc4.Controllers.Api
{
    using System.Threading.Tasks;
    using Agatha.Common;
    using Models;
    using Service.Messages.Common;
    using Service.Messages.Security;

    public class RoleSearchDataTableController : BaseApiController
    {
        public RoleSearchDataTableController(IRequestDispatcherFactory requestDispatcherFactory)
            : base ( requestDispatcherFactory )
        {}

        public async Task<DataTableResponse<RoleDto>> Get(string sEcho, int iDisplayStart, int iDisplayLength, string sSearch = null)
        {
            var requestDispatcher = CreateAsyncRequestDispatcher();
            requestDispatcher.Add(new PagedSearchRequest<RoleDto> { Keyword = sSearch, Page = iDisplayStart / iDisplayLength, PageSize = iDisplayLength });
            var response = await requestDispatcher.GetAsync<PagedSearchResponse<RoleDto>>();
            return new DataTableResponse<RoleDto>
            {
                Data = response.Results,
                Echo = sEcho,
                TotalDisplayRecords = response.TotalCount,
                TotalRecords = response.TotalCount
            };
        }
    }
}