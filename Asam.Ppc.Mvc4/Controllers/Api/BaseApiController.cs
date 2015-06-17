using System.Web.Http;
using Agatha.Common;
using IAsyncRequestDispatcher = Asam.Ppc.Mvc.Infrastructure.Service.IAsyncRequestDispatcher;

namespace Asam.Ppc.Mvc4.Controllers.Api
{
    public class BaseApiController : ApiController
    {
        private readonly IRequestDispatcherFactory _requestDispatcherFactory;

        protected BaseApiController(IRequestDispatcherFactory requestDispatcherFactory)
        {
            _requestDispatcherFactory = requestDispatcherFactory;
        }

        public IAsyncRequestDispatcher CreateAsyncRequestDispatcher()
        {
            return _requestDispatcherFactory.CreateRequestDispatcher() as IAsyncRequestDispatcher;
        }
    }
}