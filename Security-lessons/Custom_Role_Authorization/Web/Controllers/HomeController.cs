using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Web.Helpers;

namespace Web.Controllers
{
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            ViewBag.Message = GetPermisionMessage("Index", "Home");

            return View();
        }

        [HttpPost]
        public ActionResult Index(string data)
        {
            ViewBag.Message = "Post back works! " + GetPermisionMessage("Index", "Home"); ;

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = GetPermisionMessage("About", "Home");

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = GetPermisionMessage("Contact", "Home");

            return View();
        }
    }
}
