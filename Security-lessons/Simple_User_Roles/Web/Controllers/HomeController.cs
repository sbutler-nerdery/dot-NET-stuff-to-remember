using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Web.Controllers
{
    public class HomeController : Controller
    {
        private const string DEFAULT_USER_ROLES = Constants.ROLES_ADMIN + "," + Constants.ROLES_VIEWER;

        [Authorize(Roles = DEFAULT_USER_ROLES)]
        public ActionResult Index()
        {
            ViewBag.Message = "You must be logged in as a regular user!";

            return View();
        }

        [Authorize(Roles = Constants.ROLES_ADMIN)]
        public ActionResult About()
        {
            ViewBag.Message = "You must be logged in as an admin!";

            return View();
        }

        [Authorize(Roles = Constants.ROLES_ADMIN)]
        public ActionResult Contact()
        {
            ViewBag.Message = "You must be logged in as an admin!";

            return View();
        }
    }
}
