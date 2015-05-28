using System;
using System.Collections.Specialized;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;
using Asam.Ppc.Common.Crypto;
using Asam.Ppc.Domain.SecurityModule;

namespace Asam.Ppc.Mvc4.Controllers
{
    public class SingleSignOnController : Controller
    {
        private readonly ICrypto _crypto;
        private readonly IApiSystemAccountRepository _apiSystemAccountRepository;

        public SingleSignOnController(
            ICrypto crypto,
            IApiSystemAccountRepository apiSystemAccountRepository)
        {
            _crypto = crypto;
            _apiSystemAccountRepository = apiSystemAccountRepository;
        }

        [HttpPost]
        public ActionResult Index(string patientId, DateTime timestamp, string assessmentId)
        {
            var timeout = double.Parse(WebConfigurationManager.AppSettings["SingleSignOnRequestTimeoutInSeconds"]);
            if ((DateTime.Now - timestamp).TotalSeconds <= timeout)
            {
                var form = HttpContext.Request.Form;
                var cookieValue = _crypto.Encrypt(form.ToString());
                HttpContext.Response.Cookies.Add(new HttpCookie("SSOAuth", cookieValue ) { Secure = true });

                // check to see if this user has already agreed to the EULA
                if (!HasAgreedToEula(form))
                {
                    return RedirectToAction("Eula", "Home");
                }

                if (!string.IsNullOrWhiteSpace ( assessmentId ))
                {
                    return RedirectToAction("Edit", "Assessment", new { id = assessmentId });
                }
                if (!string.IsNullOrWhiteSpace ( patientId ))
                {
                    return RedirectToAction("Index", "Patient", new { id = patientId });
                }
            }
            return new HttpNotFoundResult();
        }

        private bool HasAgreedToEula(NameValueCollection form)
        {
            var apiSystemAccount = new ApiSystemAccount(
                long.Parse(GetKeyFromCollection(form, "EhrId")), 
                long.Parse(GetKeyFromCollection(form, "OrganizationId")), 
                GetKeyFromCollection(form, "userId"), 
                GetKeyFromCollection(form, "userName"),
                GetKeyFromCollection(form, "userEmail"));
            apiSystemAccount = _apiSystemAccountRepository.GetByApiCombinationKey(apiSystemAccount);
            
            if (apiSystemAccount == null) {
                return false;
            }
            return apiSystemAccount.EulaAgreeDate != null;
        }

        private static string GetKeyFromCollection(NameValueCollection nameValueCollection, string key)
        {
            foreach (var item in nameValueCollection.AllKeys.Where(item => String.Equals(item, key, StringComparison.CurrentCultureIgnoreCase)))
            {
                return nameValueCollection.Get(item);
            }
            return string.Empty;
        }
    }
}
