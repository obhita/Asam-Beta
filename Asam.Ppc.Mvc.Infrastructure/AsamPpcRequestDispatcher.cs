using Agatha.Common;
using Agatha.Common.Caching;

namespace Asam.Ppc.Mvc.Infrastructure
{
    public class AsamPpcRequestDispatcher : RequestDispatcher
    {
        public AsamPpcRequestDispatcher(IRequestProcessor requestProcessor, ICacheManager cacheManager)
            : base(requestProcessor, cacheManager)
        {
        }
    }
}