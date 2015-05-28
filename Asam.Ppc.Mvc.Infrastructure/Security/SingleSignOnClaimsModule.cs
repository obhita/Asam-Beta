using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Web;
using Asam.Ppc.Domain.EhrModule;
using Asam.Ppc.Domain.SecurityModule;
using NLog;
using Pillar.Common.InversionOfControl;

namespace Asam.Ppc.Mvc.Infrastructure.Security
{
    using System.Web.Configuration;

    using Ppc.Infrastructure;

    public class SingleSignOnClaimsModule : IHttpModule
    {
        protected readonly Logger Logger = LogManager.GetCurrentClassLogger();
        public const string CertificatePublicKeyName = "CertPublicKey";

        private static readonly Dictionary<string, string> FormKeyClaimsMap = new Dictionary<string, string>
            {
                {"UserId", ClaimTypes.NameIdentifier},
                {"UserName", ClaimTypes.Name},
                {"UserEmail", ClaimTypes.Email},
                {"PatientId", AsamClaimTypes.PatientIdClaimType},
                {"OrganizationId", AsamClaimTypes.OrganizationIdClaimType},
                {"EhrId", AsamClaimTypes.EhrIdClaimType}
            };

        public void Init(HttpApplication context)
        {
            context.BeginRequest += CheckSingleSignOnHandler;
        }

        private void AddApiSystemAccount(long ehrId, long organizationKey, string userId, string userName, string userEmail)
        {
            var apiSystemRepository = IoC.CurrentContainer.Resolve<IApiSystemAccountRepository>();
            var apiSystemAccount = new ApiSystemAccount(ehrId, organizationKey, userId, userName, userEmail);
            apiSystemAccount = apiSystemRepository.GetByApiCombinationKey(apiSystemAccount);
            if (apiSystemAccount != null) return;
            // insert a new row
            apiSystemAccount = new ApiSystemAccount(ehrId, organizationKey, userId, userName, userEmail);
            apiSystemRepository.Save(apiSystemAccount);
        }

        private void CheckSingleSignOnHandler(object sender, EventArgs e)
        {
            var singleSignOn = SingleSignOnHelper.GetSingleSignOnParameters(sender);
            var app = sender as HttpApplication;
            if (app == null)
            {
                return;
            }
            var noTokenForm = new NameValueCollection(singleSignOn.Form);
            noTokenForm.Remove("Token");
            var contentString = FormEncode(noTokenForm);
            Logger.Info("EHRId {0}", singleSignOn.EhrId);
            Logger.Info("organizationId {0}", singleSignOn.OrganizationId);
            Logger.Info("ApiKey {0}", singleSignOn.ApiKey);
            var hash = SHA1Managed.Create().ComputeHash(Encoding.Unicode.GetBytes(contentString + "&ApiKey=" + singleSignOn.ApiKey));
            var key = GetPublicKey(singleSignOn.EhrId);

            var deformatter = new RSAPKCS1SignatureDeformatter(key);
            deformatter.SetHashAlgorithm("SHA1");
            if (singleSignOn.Form.Count <= 0)
            {
                app.Response.StatusCode = 401;
                app.CompleteRequest();
                return;
            }

            var signature = Convert.FromBase64String(singleSignOn.Form["Token"]);
            var verify = deformatter.VerifySignature(hash, signature);
            Logger.Info("verify is {0}", verify);

            if (verify)
            {
                AddApiSystemAccount(
                    long.Parse(singleSignOn.EhrId), 
                    long.Parse(singleSignOn.OrganizationId),
                    GetKeyFromCollection(noTokenForm, "userId"),
                    GetKeyFromCollection(noTokenForm, "userName"),
                    GetKeyFromCollection(noTokenForm, "userEmail"));
                CreatePrinciple(singleSignOn.Form);
                return;
            }

            app.Response.StatusCode = 401;
            app.CompleteRequest();
        }

        private static string GetKeyFromCollection(NameValueCollection nameValueCollection, string key)
        {
            foreach (var item in nameValueCollection.AllKeys.Where(item => String.Equals(item, key, StringComparison.CurrentCultureIgnoreCase)))
            {
                return nameValueCollection.Get(item);
            }
            return string.Empty;
        }

        private static string GetSigningCertNameForEhr(string ehrId)
        {
            if (string.IsNullOrEmpty(ehrId))
            {
                return string.Empty;
            }

            var ehrRepository = IoC.CurrentContainer.Resolve<IEhrRepository>();
            var ehr = ehrRepository.GetByKey(long.Parse(ehrId));
            if (ehr == null || string.IsNullOrWhiteSpace(ehr.SigningCertName)) return string.Empty;
            return ehr.SigningCertName;
        }

        private static AsymmetricAlgorithm GetPublicKey(string ehrId)
        {
            var my = new X509Store(StoreName.My, StoreLocation.LocalMachine);
            my.Open(OpenFlags.ReadOnly);
            var signingCertName = GetSigningCertNameForEhr(ehrId);
            // Look for the certificate with specific subject 
            var publicKey = my.Certificates.Cast<X509Certificate2>()
                .Where(cert => cert.Subject.Contains("CN=" + signingCertName))
                .Select(cert => cert.PublicKey)
                .FirstOrDefault();
            if (publicKey == null)
            {
                throw new Exception("Valid certificate was not found");
            }

            return publicKey.Key;
        }

        private void CreatePrinciple(NameValueCollection form)
        {
            var claims = (from string key in form.Keys
                          where FormKeyClaimsMap.ContainsKey(key)
                          select new Claim(FormKeyClaimsMap[key], form[key])).ToList();

            var permissionClaimsManager = IoC.CurrentContainer.Resolve<IPermissionClaimsManager>();
            var systemAccountRepository = IoC.CurrentContainer.Resolve<ISystemAccountRepository>();
            // all the api users use the same emailid, and thus principle will be created for the same user
            // this is mainly to avoid creating accounts for every api user
            var nameIdentifier = WebConfigurationManager.AppSettings["ApiUserEmailId"];
            var systemAccount = systemAccountRepository.GetByIdentifier(nameIdentifier);
            var claimsPrincipal = new ClaimsPrincipal(new ClaimsIdentity(claims, "CustomSSO"));
            permissionClaimsManager.IssueSystemPermissionClaims(claimsPrincipal, systemAccount);

            HttpContext.Current.User = claimsPrincipal;
        }

        private static string FormEncode(NameValueCollection nameValueCollection)
        {
            return string.Join("&", nameValueCollection.Keys.OfType<string>().Select(key => string.Format("{0}={1}", key, nameValueCollection[key])));
        }

        public void Dispose()
        {
        }
    }
}
