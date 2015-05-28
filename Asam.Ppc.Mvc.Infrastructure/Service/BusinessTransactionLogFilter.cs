using System.Collections.Generic;
using System.Collections.Specialized;
using System.Web;
using Asam.Ppc.Common.Crypto;
using Asam.Ppc.Domain.BillingModule;
using Asam.Ppc.Mvc.Infrastructure.Security;
using Pillar.Common.InversionOfControl;

namespace Asam.Ppc.Mvc.Infrastructure.Service
{
    #region Using Statements

    using System;
    using System.Linq;
    using System.Net.Http;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Web.Http.Controllers;
    using System.Web.Mvc;
    using IActionFilter = System.Web.Http.Filters.IActionFilter;

    #endregion

    public class BusinessTransactionLogFilter : ActionFilterAttribute, IActionFilter
    {
        #region Public Methods and Operators

        public override void OnActionExecuting ( ActionExecutingContext filterContext )
        {
            if (!SingleSignOnHelper.IsApiMode())
            {
                return;
            }

            var request = filterContext.RequestContext.HttpContext.Request;
            var ssoAuth = request["SSOAuth"];
            if (ssoAuth != null)
            {
                var crypto = IoC.CurrentContainer.Resolve<ICrypto>();
                ssoAuth = crypto.Decrypt(ssoAuth);
                LogParameters(ssoAuth, request.Url != null ? request.Url.AbsolutePath : "Method Not Found!");
            }

            base.OnActionExecuting ( filterContext );
        }

        public async Task<HttpResponseMessage> ExecuteActionFilterAsync(HttpActionContext actionContext, CancellationToken cancellationToken, Func<Task<HttpResponseMessage>> continuation)
        {
            if (!SingleSignOnHelper.IsApiMode())
            {
                return await continuation(); ;
            }

            if (actionContext == null)
            {
                throw new ArgumentNullException("actionContext");
            }
            if (continuation == null)
            {
                throw new ArgumentNullException("continuation");
            }
            
            // to handle View Report button click event when the assessment is launched from the API
            IEnumerable<string> ssoAuths;
            var request = actionContext.Request;
            request.Headers.TryGetValues("SSOAuth", out ssoAuths);
            // when assessment is launched from the API, the ssoAuths object will be null; and when the report is retrieved directly from
            // the external application via the API, the object will not be null
            if (ssoAuths != null)
            {
                LogParameters(ssoAuths.First(), request.RequestUri.AbsolutePath);
            }

            var response = await continuation();

            return response;
        }

        private void LogParameters(string ssoAuth, string methodName)
        {
            var formValues = FormDecode(ssoAuth);
            var billingTransactionRepo = IoC.CurrentContainer.Resolve<IBillingTransactionRepository>();
            var ehrKey = Convert.ToInt64(formValues["EhrId"]);
            var organizationKey = Convert.ToInt64(formValues["OrganizationId"]);
            var userName = formValues["UserName"];
            var userEmail = HttpUtility.UrlDecode(formValues["UserEmail"]);
            var billingTransaction = new BillingTransaction(ehrKey, organizationKey, userEmail, userName, methodName, ssoAuth);
            billingTransactionRepo.Save(billingTransaction);
        }

        private NameValueCollection FormDecode(string formString)
        {
            if (!string.IsNullOrWhiteSpace(formString))
            {
                var nameValueCollection = new NameValueCollection();
                var parrseString = formString;
                if (parrseString.StartsWith("?"))
                {
                    parrseString = parrseString.Substring(1, parrseString.Length - 1);
                }
                FillFromString(parrseString, nameValueCollection);
                return nameValueCollection;
            }
            return null;
        }

        private void FillFromString(string queryString, NameValueCollection collection)
        {
            if (string.IsNullOrWhiteSpace(queryString))
            {
                return;
            }
            var length = queryString.Length;
            var i = 0;
            while (i < length)
            {
                // find next & while noting first = on the way (and if there are more)
                var startIndex = i;
                var tailIndex = -1;

                while (i < length)
                {
                    var ch = queryString[i];

                    if (ch == '=')
                    {
                        if (tailIndex < 0)
                            tailIndex = i;
                    }
                    else if (ch == '&')
                    {
                        break;
                    }
                    i++;
                }

                // extract the name / value pair 
                String name = null;
                String value;

                if (tailIndex >= 0)
                {
                    name = queryString.Substring(startIndex, tailIndex - startIndex);
                    value = queryString.Substring(tailIndex + 1, i - tailIndex - 1);
                }
                else
                {
                    value = queryString.Substring(startIndex, i - startIndex);
                }

                // add name / value pair to the collection
                collection.Add(name, value);
                i++;
            }
        } 

        #endregion

    }
}