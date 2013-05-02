using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Web.Models;

namespace Web.ViewModels
{
    public class BlogViewModel
    {
        public BlogViewModel()
        {
        }

        public BlogViewModel(Blog blog)
        {
            BlogId = blog.BlogId;
            Name = blog.Name;
            Posts = new List<PostViewModel>();
            blog.Posts.ForEach(post =>
                {
                    var addMe = new PostViewModel
                        {
                            PostId = post.PostId,
                            Title = post.Title,
                            Content = post.Content
                        };
                    Posts.Add(addMe);
                });
        }

        public int BlogId { get; set; }
        public string Name { get; set; }
        public List<PostViewModel> Posts { get; set; }        
    }
}