namespace Asam.Ppc.Mvc4.Controllers.Api
{
    using System.Threading.Tasks;
    using Agatha.Common;
    using Models;
    using Service.Messages.Common;
    using Service.Messages.Organization;

    public class StaffSearchDataTableController : BaseApiController
    {
        public StaffSearchDataTableController ( IRequestDispatcherFactory requestDispatcherFactory )
            : base ( requestDispatcherFactory )
        {}

        public async Task<DataTableResponse<StaffDto>> Get(string sEcho, int iDisplayStart, int iDisplayLength, string sSearch = null)
        {
            var requestDispatcher = CreateAsyncRequestDispatcher ();
            requestDispatcher.Add ( new PagedSearchRequest<StaffDto> { Keyword = sSearch, Page = iDisplayStart/iDisplayLength, PageSize = iDisplayLength } );
            var response = await requestDispatcher.GetAsync<PagedSearchResponse<StaffDto>> ();
            return new DataTableResponse<StaffDto>
                {
                    Data = response.Results,
                    Echo = sEcho,
                    TotalDisplayRecords = response.TotalCount,
                    TotalRecords = response.TotalCount
                };
        }
    }
}