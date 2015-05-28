using System;
using System.Linq;
using System.Net.Http;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Web.Configuration;
using TestEHR.Models;

namespace TestEHR.Controllers
{
    public static class CertSignService
    {
        public static void SetSignedCertificateHeader(HttpClient httpRequest, UserModel userModel)
        {
            var authHeaderString = string.Format("EhrId={0}&OrganizationId={1}&UserId={2}&UserName={3}&UserEmail={4}&PatientId={5}&ApiKey={6}", 
                userModel.EhrId, userModel.OrganizationId, userModel.UserId, userModel.Username, userModel.Email, userModel.PatientId, userModel.ApiKey);

            var signature = SignCertificate(authHeaderString);

            authHeaderString += "&Token=" + Convert.ToBase64String(signature);
            httpRequest.DefaultRequestHeaders.Add("SSOAuth", authHeaderString.Replace(string.Format("&ApiKey={0}",userModel.ApiKey), ""));            
        }

        public static byte[] SignCertificate(string text)
        {
            // Open certificate store of current user
            var my = new X509Store(StoreName.My, StoreLocation.LocalMachine);
            my.Open(OpenFlags.ReadOnly);
            var signingCertName = WebConfigurationManager.AppSettings["SigningCertName"];
            // Look for the certificate with specific subject 
            var csp = my.Certificates.Cast<X509Certificate2>()
                .Where(cert => cert.Subject.Contains("CN=" + signingCertName))
                .Select(cert => (RSACryptoServiceProvider)cert.PrivateKey)
                .FirstOrDefault();
            if (csp == null)
            {
                throw new Exception("Valid certificate was not found");
            }

            // Hash the data
            var sha1 = new SHA1Managed();
            var data = Encoding.Unicode.GetBytes(text);
            var hash = sha1.ComputeHash(data);

            // Sign the hash
            return csp.SignHash(hash, CryptoConfig.MapNameToOID("SHA1"));
        }
    }
}