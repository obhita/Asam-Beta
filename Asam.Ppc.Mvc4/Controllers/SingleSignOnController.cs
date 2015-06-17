using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;
using Asam.Ppc.Mvc4.Models;

namespace Asam.Ppc.Mvc4.Controllers
{
    public class SingleSignOnController : Controller
    {
        //
        // GET: /SingleSignOn/
        [HttpPost]
        public ActionResult Index(string patientId, DateTime timestamp, string assessmentId)
        {
            var timeout = double.Parse(WebConfigurationManager.AppSettings["SingleSignOnRequestTimeoutInSeconds"]);
            if ((DateTime.Now - timestamp).TotalSeconds <= timeout)
            {
                var form = HttpContext.Request.Form;
                HttpContext.Response.Cookies.Add(new HttpCookie("SSOAuth", Convert.ToBase64String(Encoding.UTF8.GetBytes(form.ToString()))) { Secure = true });

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
    }
}
