using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web.Models;

namespace Web.Controllers
{
    public class KnockoutController : Controller
    {
        //
        // GET: /Knockout/

        public JsonResult Update(Blog updateMe)
        {
            return Json(updateMe);
        }

    }
}
