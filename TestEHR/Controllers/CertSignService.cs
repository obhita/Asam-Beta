using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Web;
using System.Web.Configuration;

namespace TestEHR.Controllers
{
    public static class CertSignService
    {
        public static byte[] SignCertificate(string text)
        {
            // Open certificate store of current user
            var my = new X509Store(StoreName.My, StoreLocation.LocalMachine);
            my.Open(OpenFlags.ReadOnly);

            // Look for the certificate with specific subject 
            var csp = my.Certificates.Cast<X509Certificate2>()
                .Where(cert => cert.Subject.Contains("CN=" + WebConfigurationManager.AppSettings["SigningCertName"]))
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