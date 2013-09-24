using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Demo.EditorTemplates.Web.Models;

namespace Demo.EditorTemplates.Web.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            var colorado = new AddressState {StateId = 1, StateAbbreviation = "CO"};
            var missouri = new AddressState {StateId = 2, StateAbbreviation = "MO"};

            var person = new Person
                {
                    PersonId = 0,
                    FirstName = "Stan",
                    LastName = "Butler",
                    MyAddress = new Address
                        {
                            AddressId = 0,
                            Address1 = "519 Spruce",
                            City = "Kansas City",
                            State = missouri,
                            Zip = "64122",
                            States = new [] { colorado, missouri }
                        }
                };

            return View(person);
        }

        [HttpPost]
        public ActionResult Index(Person model)
        {
            var colorado = new AddressState { StateId = 1, StateAbbreviation = "CO" };
            var missouri = new AddressState { StateId = 2, StateAbbreviation = "MO" };

            model.MyAddress.States = new[] {colorado, missouri};

            return View(model);
        }
    }
}
