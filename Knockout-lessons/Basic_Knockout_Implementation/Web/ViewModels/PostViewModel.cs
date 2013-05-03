using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace Web.ViewModels
{
    public class PostViewModel
    {
        [JsonProperty("postId")]
        public int PostId { get; set; }
        [JsonProperty("title")]
        public string Title { get; set; }
        [JsonProperty("content")]
        public string Content { get; set; }
        [JsonProperty("isInEditMode")]
        public bool IsInEditMode { get; set; }
    }
}