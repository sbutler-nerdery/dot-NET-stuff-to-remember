using Newtonsoft.Json;
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
                builder.AppendLine(string.Format(template, "Phone number", model.PhoneNumber));

                ViewBag.Message = builder.ToString();                
            }

            return View();
        }

        public ActionResult ComplexForm()
        {
            //NOTE: this would normally be a call to the database.
            Person model = new Person
            {
                FirstName = "Joe",
                Email = "joe@hotmail.com",
                Template = new School{ IsTemplate = true },
                SchoolsIWentTo = new List<School> { 
                    new School {Name = "Some college", PhoneNumber = "123.123.1234", IsTemplate = false}
                }
            };

            return View(model);
        }

        [HttpPost]
        public ActionResult ComplexForm(Person model)
        {
            return View(model);
        }

        public ActionResult AjaxForm()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AjaxForm(School model)
        {
            return PartialView("_UpdateMePartial", model);
        }

        [HttpPost]
        public JsonResult GetJson(School model)
        {
            //This will return a JSON object of the model
            return Json(model);
        }

        [HttpPost]
        public JsonResult ThrowError(School model)
        {
            throw new Exception("The website crapped all over itself.");
        }
    }
}
