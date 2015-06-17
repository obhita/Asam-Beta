using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Web;
using System.Web.Configuration;

namespace Asam.Ppc.Mvc.Infrastructure.Security
{
    using Ppc.Infrastructure;

    public class SingleSignOnClaimsModule : IHttpModule
    {
        public const string CertificatePublicKeyName = "CertPublicKey";

        private static Dictionary<string, string> _formKeyClaimsMap = new Dictionary<string, string>
            {
                {"UserId", ClaimTypes.NameIdentifier},
                {"UserName", ClaimTypes.Name},
                {"UserEmail", ClaimTypes.Email},
                {"PatientId", AsamClaimTypes.PatientIdClaimType}
            };

        public void Init(HttpApplication context)
        {
            context.BeginRequest += CheckSingleSignOnHandler;
        }

        private void CheckSingleSignOnHandler(object sender, EventArgs e)
        {
            var app = sender as HttpApplication;
            NameValueCollection form = null;
            var authHeader = app.Request.Headers["SSOAuth"];
            if ( !string.IsNullOrEmpty ( authHeader ) )
            {
                form = FormDecode ( authHeader );
            }
            else if (app.Request.Cookies.Keys.OfType<string>().Contains("SSOAuth"))
            {
                var ssoAuthCookie = app.Request.Cookies["SSOAuth"];
                form = HttpUtility.ParseQueryString(Encoding.UTF8.GetString(Convert.FromBase64String(ssoAuthCookie.Value)));
            }
            else switch ( app.Request.RequestType )
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
                var signature = Convert.FromBase64String(form["Token"]);
                var noTokenForm = new NameValueCollection(form);
                noTokenForm.Remove("Token");
                var contentString = FormEncode(noTokenForm);
                var hash = SHA1Managed.Create().ComputeHash(Encoding.Unicode.GetBytes(contentString));

                var key = GetPublicKey ();

                var deformatter = new RSAPKCS1SignatureDeformatter(key);
                deformatter.SetHashAlgorithm("SHA1");
                var verify = deformatter.VerifySignature(hash, signature);
                if (verify)
                {
                    CreatePrinciple(form);
                    return;
                }

            }

            app.Response.StatusCode = 404;
            app.CompleteRequest();
        }

        private static AsymmetricAlgorithm GetPublicKey ()
        {
            var my = new X509Store(StoreName.My, StoreLocation.LocalMachine);
            my.Open(OpenFlags.ReadOnly);

            // Look for the certificate with specific subject 
            var publicKey = my.Certificates.Cast<X509Certificate2>()
                .Where(cert => cert.Subject.Contains("CN=" + WebConfigurationManager.AppSettings["SigningCertName"]))
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
            var claims = ( from string key in form.Keys
                           where _formKeyClaimsMap.ContainsKey ( key )
                           select new Claim ( _formKeyClaimsMap[key], form[key] ) ).ToList ();
            HttpContext.Current.User = new ClaimsPrincipal(new ClaimsIdentity(claims, "CustomSSO"));
        }

        private static string FormEncode(NameValueCollection nameValueCollection)
        {
            return string.Join("&", nameValueCollection.Keys.OfType<string>().Select(key => string.Format("{0}={1}", key, nameValueCollection[key])));
        }

        private static NameValueCollection FormDecode ( string formString )
        {
            if ( !string.IsNullOrWhiteSpace ( formString ) )
            {
                var nameValueCollection = new NameValueCollection ();
                var parrseString = formString;
                if (parrseString.StartsWith("?"))
                {
                    parrseString = parrseString.Substring ( 1, parrseString.Length - 1 );
                }
                FillFromString ( parrseString, nameValueCollection );
                return nameValueCollection;
            }
            return null;
        }

        private static void FillFromString(string queryString, NameValueCollection collection)
        {
            var length = (queryString != null) ? queryString.Length : 0;
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
                String value = null;

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

        public void Dispose()
        {
        }
    }
}
