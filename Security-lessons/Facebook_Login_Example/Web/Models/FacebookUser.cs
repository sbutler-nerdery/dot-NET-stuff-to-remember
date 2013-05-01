using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace Web.Models
{
    public class FacebookUser
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("url")]
        public string Link { get; set; }
        [JsonProperty("username")]
        public string UserName { get; set; }
        [JsonProperty("pic")]
        public string SmallPhotoUrl { get; set; }
        [JsonProperty("pic_square")]
        public string LargePhotoUrl { get; set; }
    }
}