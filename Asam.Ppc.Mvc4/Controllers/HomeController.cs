using System;
using System.Collections.Generic;
using System.Configuration;
using System.Web.Mvc;
using Agatha.Common;
using Asam.Ppc.Common.Crypto;
using Asam.Ppc.Domain.SecurityModule;
using Asam.Ppc.Infrastructure;
using Asam.Ppc.Mvc.Infrastructure.Security;

namespace Asam.Ppc.Mvc4.Controllers
{
    public class HomeController : BaseController
    {
        private readonly IApiSystemAccountRepository _apiSystemAccountRepository;
        private readonly ISystemAccountRepository _systemAccountRepository;
        private readonly ICrypto _crypto;

        public HomeController(
            IRequestDispatcherFactory requestDispatcherFactory, 
            IPatientAccessControlManager patientAccessControlManager,
            IApiSystemAccountRepository apiSystemAccountRepository,
            ISystemAccountRepository systemAccountRepository,
            ICrypto crypto) 
            : base(requestDispatcherFactory, patientAccessControlManager)
        {
            _apiSystemAccountRepository = apiSystemAccountRepository;
            _systemAccountRepository = systemAccountRepository;
            _crypto = crypto;
        }

        public virtual ActionResult Index(string assessmentId = null)
        {
            if ( UserContext.IsSystemAdmin )
            {
                return RedirectToAction ( "Index", "SystemAdmin" );
            }
            if (!_patientAccessControlManager.CanAccessAllPatients) return HttpNotFound();
            var referrer = string.Empty;
            if (Request.UrlReferrer != null)
            {
                referrer = Request.UrlReferrer.ToString();
            }
            if (Request.Cookies["SSOAuth"] != null && ConfigurationManager.AppSettings["IsApiMode"] == "true")
            {
                // TODO: Show EULA if this user has not already agreed to it
                var apiSystemAccount = GetApiSystemAccount();
                var systemAccount = _apiSystemAccountRepository.GetByApiCombinationKey(apiSystemAccount);
                if (systemAccount.EulaAgreeDate == null)
                {
                    // must show the EULA page now and nothing else until they agree
                    return PartialView("Eula", referrer);
                }
            }
            else
            {
                // not in API mode
                var systemAccount = _systemAccountRepository.GetByKey(UserContext.SystemAccountKey);
                if (systemAccount != null)
                {
                    if (systemAccount.EulaAgreeDate == null)
                    {
                        // must show the EULA page now and nothing else until they agree
                        return PartialView("Eula", referrer);
                    }
                }
            }

            ViewData["AssessmentId"] = assessmentId;
            return View ();
        }

        [HttpGet]
        public virtual ActionResult Eula()
        {
            var referrer = string.Empty;
            if (Request.UrlReferrer != null)
            {
                referrer = Request.UrlReferrer.ToString();
            }
            return PartialView("Eula", referrer);
        }

        [HttpPost]
        public virtual ActionResult EulaSave(string agree, string referrer)
        {
            if (agree != "true") return PartialView("NoAccess");

            if (ConfigurationManager.AppSettings["IsApiMode"] == "true")
            {
                var apiSystemAccount = GetApiSystemAccount();
                apiSystemAccount = _apiSystemAccountRepository.GetByApiCombinationKey(apiSystemAccount);
                apiSystemAccount.ReviseEulaSignDate(DateTime.Now);
                _apiSystemAccountRepository.Save(apiSystemAccount);
            }
            else
            {
                var systemAccount = _systemAccountRepository.GetByKey(UserContext.SystemAccountKey);
                systemAccount.ReviseEulaSignDate(DateTime.Now);
                _systemAccountRepository.Save(systemAccount);
            }
            return Redirect(referrer);
        }

        public virtual ActionResult NoAccess()
        {
            return PartialView();
        }

        private ApiSystemAccount GetApiSystemAccount()
        {
            if (Request.Cookies["SSOAuth"] == null)
            {
                return null;
            }
            var cookieValue = _crypto.Decrypt(Request.Cookies["SSOAuth"].Value);
            var keyValPairs = cookieValue.Split('&');
            return new ApiSystemAccount(
                      long.Parse(GetValueByKey(keyValPairs, "ehrId")),
                      long.Parse(GetValueByKey(keyValPairs, "organizationId")),
                      GetValueByKey(keyValPairs, "userId"),
                      GetValueByKey(keyValPairs, "userName"),
                      GetValueByKey(keyValPairs, "userEmail"));
        }

        private string GetValueByKey(IEnumerable<string> keyValues, string keyName)
        {
            foreach (var key in keyValues)
            {
                var keySplit = key.Split('=');
                if (string.Equals(keySplit[0], keyName, StringComparison.OrdinalIgnoreCase))
                {
                    return Server.UrlDecode( keySplit[1] );
                }
            }
            return string.Empty;
        }
    }
}
