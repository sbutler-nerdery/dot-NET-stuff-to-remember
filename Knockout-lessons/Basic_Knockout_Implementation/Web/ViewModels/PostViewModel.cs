using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using Web.Models;

namespace Web.ViewModels
{
    public class PostViewModel
    {
        public PostViewModel()
        {
        }

        public PostViewModel(Post dataModel)
        {
            PostId = dataModel.PostId;
            Title = dataModel.Title;
            Content = dataModel.Content;
        }

        public Post GetDataModel()
        {
            var dataModel = new Post
                {
                    PostId = PostId,
                    Title = Title,
                    Content = Content
                };
            return dataModel;
        }

        [JsonProperty("postId")]
        public int PostId { get; set; }
        [JsonProperty("title")]
        public string Title { get; set; }
        [JsonProperty("content")]
        public string Content { get; set; }
    }
}