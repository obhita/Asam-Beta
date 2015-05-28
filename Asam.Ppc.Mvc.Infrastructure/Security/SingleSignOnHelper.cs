using System;
using System.Collections.Specialized;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using Asam.Ppc.Common.Crypto;
using Asam.Ppc.Domain.OrganizationModule;
using Pillar.Common.InversionOfControl;

namespace Asam.Ppc.Mvc.Infrastructure.Security
{
    public class SingleSignOnHelper
    {
        public static bool IsApiMode()
        {
            return !string.IsNullOrEmpty(WebConfigurationManager.AppSettings["IsApiMode"]) && WebConfigurationManager.AppSettings["IsApiMode"].Equals("true");
        }

        private static string GetApiKeyForOganization(string organizationId)
        {
            var organizationRepository = IoC.CurrentContainer.Resolve<IOrganizationRepository>();
            var organization = organizationRepository.GetByKey(long.Parse(organizationId));
            if (organization == null || organization.ApiKey == null) return string.Empty;
            return organization.ApiKey;
        }

        private static NameValueCollection FormDecode(string formString)
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

        private static void FillFromString(string queryString, NameValueCollection collection)
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

        public static SingleSignOn GetSingleSignOnParameters(object sender)
        {
            var singleSignOn = new SingleSignOn();
            var app = sender as HttpApplication;
            if (app == null)
            {
                return singleSignOn;
            }
            NameValueCollection form = null;
            var authHeader = app.Request.Headers["SSOAuth"];
            if (!string.IsNullOrEmpty(authHeader))
            {
                form = FormDecode(authHeader);
            }
            else if (app.Request.Cookies.Keys.OfType<string>().Contains("SSOAuth"))
            {
                var ssoAuthCookie = app.Request.Cookies["SSOAuth"];
                if (ssoAuthCookie != null)
                {
                    var crypto = IoC.CurrentContainer.Resolve<ICrypto>();
                    var decryptedCookieValue = crypto.Decrypt(ssoAuthCookie.Value);
                    form = HttpUtility.ParseQueryString(decryptedCookieValue);
                    //form = HttpUtility.ParseQueryString(Encoding.UTF8.GetString(Convert.FromBase64String(ssoAuthCookie.Value)));
                }
            }
            else switch (app.Request.RequestType)
                {
                    case "GET":
                        {
                            var content = app.Request.Url.Query;
                            form = HttpUtility.ParseQueryString(content);
                        }
                        break;
                    case "PUT":
                    case "POST":
                        form = app.Request.Form;
                        break;
                }

            if (form != null && form.Keys.OfType<string>().Contains("Token"))
            {
                singleSignOn.EhrId = form["EhrId"];
                singleSignOn.OrganizationId = form["OrganizationId"];
                singleSignOn.ApiKey = GetApiKeyForOganization(singleSignOn.OrganizationId);
                singleSignOn.Token = Convert.FromBase64String(form["Token"]);

            }
            singleSignOn.Form = form;
            return singleSignOn;
        }

        public static string GetSingleSignOnUserName ( object httpApp )
        {
            var singleSignOn = GetSingleSignOnParameters ( httpApp );

            return singleSignOn.Form["UserName"] ?? string.Empty;
        }

    }
}
