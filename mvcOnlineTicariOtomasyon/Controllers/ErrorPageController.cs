using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace mvcOnlineTicariOtomasyon.Controllers
{
    public class ErrorPageController : Controller
    {
        // GET: ErrorPage
        public ActionResult errorPage()
        {
            Response.TrySkipIisCustomErrors = true;
            return View();
        }

        public ActionResult errorPage400()
        {
            Response.StatusCode = 404;
            Response.TrySkipIisCustomErrors = true;
            return View("errorPage");
        }
    }
}