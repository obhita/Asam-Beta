using System.Net;
using System.Net.Http;
using System.Web.Http.Filters;
using NLog;

namespace Asam.Ppc.Mvc.Infrastructure
{
    /// <summary>
    /// Extended exception filter attribute.
    /// </summary>
    public class ExtendedExceptionFilterAttribute : ExceptionFilterAttribute
    {
        private readonly Logger logger = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// Called when exception.
        /// </summary>
        /// <param name="context">The context.</param>
        public override void OnException(HttpActionExecutedContext context)
        {
            if (context.Response == null)
            {
                context.Response = new HttpResponseMessage();
            }

            logger.Error(context.Exception.Message, context.Exception);
            context.Response.StatusCode = HttpStatusCode.InternalServerError;
            context.Response.Content = new StringContent("An error occurred while processing your request.");
            base.OnException(context);
        }
    }
}
