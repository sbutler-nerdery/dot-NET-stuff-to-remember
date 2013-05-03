using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
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
            IsInEditMode = false;
            Posts = new List<PostViewModel>();

            blog.Posts.OrderByDescending(x => x.PostId).ToList().ForEach(post =>
            {
                var addMe = new PostViewModel(post);
                Posts.Add(addMe);
            });
        }

        public Blog GetDataModel()
        {
            var blog = new Blog {BlogId = BlogId, Name = Name};
            blog.Posts = new List<Post>();
            Posts.ForEach(post => blog.Posts.Add(post.GetDataModel()));

            return blog;
        }

        [JsonProperty("blogId")]
        public int BlogId { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("isInEditMode")]
        public bool IsInEditMode { get; set; }
        [JsonProperty("posts")]
        public List<PostViewModel> Posts { get; set; }        
    }
}