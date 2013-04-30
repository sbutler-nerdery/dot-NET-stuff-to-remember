using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Web.Data;
using Web.Helpers;
using Web.Models;

namespace Web.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        public const string FACEBOOK_GRAPH_URL = "https://graph.facebook.com/";

        public ActionResult Index()
        {
            ViewBag.Message = "You are logged into facebook!";

            //Make sure that the access token is set if the user is returning from another session.
            if (string.IsNullOrEmpty(AccountController.AccessToken))
                AccountController.AccessToken = FacebookRepository.GetAccessToken();

            return View();
        }

        public Task<ActionResult> MyFriends()
        {
            //Get a list of friends for the currently logged in user
            var getFriendsUrl = string.Format("{0}/me/friends?access_token={1}", FACEBOOK_GRAPH_URL,
                                              AccountController.AccessToken);
            var json = HttpHelper.GetJson(getFriendsUrl);
            var myFriends = JObject.Parse(json);
            var friendIds = (from friend in myFriends["data"]
                            select (string)friend["id"]).Take(20).ToList();

            var friendsList = JsonConvert.DeserializeObject<List<FacebookUser>>(json);

            //Get the pic for each user from facebook because they are retarded and don't include a link to that in the user information!

            return View(friendsList);
        }

        public static List<FacebookUser> GetFacebookFriends(List<string> friendIds)
        {
            var friendsList = new List<FacebookUser>();

            friendIds.ForEach(f =>
            {
                var getFriendDetailsUrl = string.Format("{0}{1}?access_token={2}", FACEBOOK_GRAPH_URL, f,
                                                       AccountController.AccessToken);
                var friendDetailJson = HttpHelper.GetJson(getFriendDetailsUrl);
                var addMe = JsonConvert.DeserializeObject<FacebookUser>(friendDetailJson);
                friendsList.Add(addMe);
            });

            return friendsList;
        }
    }
}
