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

        public ActionResult MyFriends()
        {
            //Get a list of friends for the currently logged in user
            var getFriendsUrl = 
                string.Format(
                    "{0}fql?q={{\"friendsIds\":\"SELECT+uid2+FROM+friend+WHERE+uid1=me()\",\"friends\":\"SELECT+id,+name,+url,+pic,+pic_big+FROM+profile+WHERE+id+IN+(SELECT+uid2+FROM+%23friendsIds)\"}}&access_token={1}",
                    FACEBOOK_GRAPH_URL, AccountController.AccessToken);
            
            var json = HttpHelper.GetJson(getFriendsUrl);
            var myFriends = JObject.Parse(json);
            var friends = (from friend in myFriends["data"][1]["fql_result_set"]
                             select friend).ToList();

            var friendsList = JsonConvert.DeserializeObject<List<FacebookUser>>(JsonConvert.SerializeObject(friends));

            return View(friendsList.OrderBy(x => x.Name));
        }
    }
}
