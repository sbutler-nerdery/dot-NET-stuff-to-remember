using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Glimpse.API.Web.Data;
using Glimpse.API.Web.Models;

namespace Glimpse.API.Web.Controllers
{
    public class HomeController : Controller
    {
        private IRepository<Person> _PersonRepository;
 
        public HomeController(IRepository<Person> repository)
        {
            _PersonRepository = repository;
        }

        public ActionResult Index()
        {
            var people = _PersonRepository.GetAll("Gadgets");
            return View(people);
        }
    }
}
