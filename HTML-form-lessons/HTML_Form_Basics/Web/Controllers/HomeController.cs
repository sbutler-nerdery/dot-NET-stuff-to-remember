using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using Web.ViewModels;

namespace Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "What is this site all about?";

            return View();
        }

        public ActionResult BasicForm()
        {
            return View();
        }

        [HttpPost]
        public ActionResult BasicForm(School model)
        {
            if (ModelState.IsValid)
            {
                var template = "{0}: {1}<br/>";
                StringBuilder builder = new StringBuilder();
                builder.AppendLine("You sumitted the following values:<br/>");
                builder.AppendLine(string.Format(template, "Name", model.Name));
                builder.AppendLine(string.Format(template, "Phone number", model.PhoneNumer));

                ViewBag.Message = builder.ToString();                
            }

            return View();
        }

        public ActionResult AjaxForm()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AjaxForm(School model   )
        {
            return View();
        }
    }
}
