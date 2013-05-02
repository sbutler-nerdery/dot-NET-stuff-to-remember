using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using Web.Models;

namespace Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var blogs = new List<Blog>();

            for (var i = 0; i < 5; i++)
            {
                var blog = new Blog {BlogId = i, Name = string.Format("Blog {0}",i),
                Posts = new List<Post>()};
                for (var j = 0; j < 2; j++)
                {
                    var post = new Post { PostId = j, Title = string.Format("Post #{0}",j), 
                        Content = string.Format("Meaning full content for post #{0}",j)};
                    blog.Posts.Add(post);
                }
                blogs.Add(blog);
            }

            ViewBag.Json = JsonConvert.SerializeObject(blogs);

            return View();
        }
    }
}
