using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.Controllers
{
    public class AnotherController : BaseController
    {
        //
        // GET: /Another/

        public ActionResult Index()
        {
            ViewBag.Message = GetPermisionMessage("Index", "Another");
            return View();
        }

    }
}
