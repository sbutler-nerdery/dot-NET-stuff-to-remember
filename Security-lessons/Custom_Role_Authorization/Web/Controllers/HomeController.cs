using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Web.Controllers
{
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            ViewBag.Message = "You must be logged in as a regular user!";

            return View();
        }

        [HttpPost]
        public ActionResult Index(string data)
        {
            ViewBag.Message = "Post back!";

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "You must be logged in as an admin!";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "You must be logged in as an admin!";

            return View();
        }
    }
}
