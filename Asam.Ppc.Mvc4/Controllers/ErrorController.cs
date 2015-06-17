using System.Web.Mvc;

namespace Asam.Ppc.Mvc4.Controllers
{
    public class ErrorController : Controller
    {
        public ActionResult HttpError()
        {
            return View();
        }

        public ActionResult Http404()
        {
            return View();
        }
    }
}
