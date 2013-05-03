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