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
            var response = new Response { Error = false, Message = "Save successful." };

            try
            {
                using (var context = new KnockoutBasicsContext())
                {
                    foreach (var blog in blogs)
                    {
                        //Add or update blog
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
                                //Add or update post
                                if (post.PostId == 0)
                                {
                                    var addPost = post.GetDataModel();
                                    addPost.Blog = updateBlog;
                                    context.Posts.Add(addPost);
                                }
                                else
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

                        //Remove any posts...
                        var notNewPostIds = blog.Posts.Where(x => x.PostId != 0).Select(x => x.PostId);
                        var removeThesePosts = context.Posts.Where(x => !notNewPostIds.Contains(x.PostId)
                            && x.Blog.BlogId == blog.BlogId);

                        removeThesePosts.ToList().ForEach(x => context.Posts.Remove(x));
                    }

                    //Remove any blogs...
                    var notNewBlogIds = blogs.Where(x => x.BlogId != 0).Select(x => x.BlogId);
                    var removeTheseBlogs = context.Blogs.Where(x => !notNewBlogIds.Contains(x.BlogId));

                    removeTheseBlogs.ToList().ForEach(x =>
                        {
                            //Remove all of the blog's posts first...
                            var removePostIds = x.Posts.Select(y => y.PostId).ToArray();
                            foreach (var postId in removePostIds)
                            {
                                var removeMe = context.Posts.FirstOrDefault(y => y.PostId == postId);
                                context.Posts.Remove(removeMe);
                            }

                            //Then remove the blog.
                            context.Blogs.Remove(x);
                        });

                    context.SaveChanges();

                    //Requery the database to get updates...
                    blogs = new List<BlogViewModel>();
                    var data = context.Blogs.Include("Posts").ToList();
                    data.ForEach(model => blogs.Add(new BlogViewModel(model)));
                    blogs = blogs.OrderByDescending(x => x.BlogId).ToList();

                    response.Updated = JsonConvert.SerializeObject(blogs).Replace("'", "\\'");
                }
            }
            catch (Exception ex)
            {
                //Log an error to the database
                using (var context = new KnockoutBasicsContext())
                {
                    var error = new ErrorLog { Message = ex.Message, CallStack = ex.StackTrace };
                    context.ErrorLogs.Add(error);
                    context.SaveChanges();
                }

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
        public string Updated { get; set; }
    }
}
