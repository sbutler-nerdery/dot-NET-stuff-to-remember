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
        public int Id { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("first_name")]
        public string FirstName { get; set; }
        [JsonProperty("last_name")]
        public string LastName { get; set; }
        [JsonProperty("link")]
        public string Link { get; set; }
        [JsonProperty("username")]
        public string UserName { get; set; }
        [JsonProperty("gender")]
        public string Gender { get; set; }
        [JsonProperty("locale")]
        public string Locale { get; set; }
        public string SmallPhotoUrl { get; set; }
        public string LargePhotoUrl { get; set; }
    }
}