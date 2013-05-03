using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using Web.Data;
using Web.Models;
using Web.ViewModels;

namespace Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            GetSeedBlogs();

            return View();
        }

        public ActionResult EditForm()
        {
            GetSeedBlogs();
            return View();
        }

        private void GetSeedBlogs()
        {
            var blogs = new List<BlogViewModel>();

            using (var context = new KnockoutBasicsContext())
            {
                var data = context.Blogs.Include("Posts").ToList();
                data.ForEach(model => blogs.Add(new BlogViewModel(model)));
            }

            blogs = blogs.OrderByDescending(x => x.BlogId).ToList();

            ViewBag.Json = JsonConvert.SerializeObject(blogs).Replace("'", "\\'");            
        }
    }
}
