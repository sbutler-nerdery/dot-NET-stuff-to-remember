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
    public class KnockoutController : Controller
    {
        //
        // POST: /Knockout/
        [HttpPost]
        public ActionResult Update(string json)
        {
            var blogs = JsonConvert.DeserializeObject<List<BlogViewModel>>(json);
            var response = new Response { Error = false, Message = "Save successful."};

            try
            {
                using (var context = new KnockoutBasicsContext())
                {
                    foreach (var blog in blogs)
                    {
                        if (blog.BlogId == 0)
                        {
                            var addMe = blog.GetDataModel();
                            context.Blogs.Add(addMe);
                        }
                        else
                        {
                            var updateBlog = context.Blogs.FirstOrDefault(x => x.BlogId == blog.BlogId);

                            if (updateBlog == null)
                            {
                                response.Error = true;
                                response.Message = string.Format("Unable to find blog id '{0}'.", blog.BlogId);
                                return Json(response);
                            }

                            updateBlog.Name = blog.Name;
                            
                            foreach (var post in blog.Posts)
                            {
                                var updatePost = context.Posts.FirstOrDefault(x => x.PostId == post.PostId);

                                if (updatePost == null)
                                {
                                    response.Error = true;
                                    response.Message = string.Format("Unable to find post id '{0}'.", post.PostId);
                                    return Json(response);
                                }

                                updatePost.Title = post.Title;
                                updatePost.Content = post.Content;
                            }
                        }
                    }

                    context.SaveChanges();
                }
            }
            catch (Exception)
            {
                response.Error = true;
                response.Message = "An error occurred on the server while trying to save.";
            }

            return Json(response);
        }

    }

    public class Response
    {
        public bool Error { get; set; }
        public string Message { get; set; }
    }
}
