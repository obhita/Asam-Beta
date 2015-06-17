using System;
using System.Threading.Tasks;
using Agatha.Common;

namespace Asam.Ppc.Mvc.Infrastructure.Service
{
    public interface IAsyncRequestDispatcher : IRequestDispatcher
    {
        Task<T> GetAsync<T>()
            where T : Response;

        Task<object> GetAsync(Type type);

        Task GetAllAsync ();
    }
}