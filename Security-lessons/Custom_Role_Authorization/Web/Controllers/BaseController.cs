using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web.Data;
using Web.Helpers;

namespace Web.Controllers
{
    public class BaseController : Controller
    {
        protected override void OnAuthorization(AuthorizationContext filterContext)
        {
            base.OnAuthorization(filterContext);
            var permissions = SecurityHelper.GetAllControllerPermissions();
            
            //Check to see if the user or the user group is in the list of permissions.
            var userPermission = permissions.FirstOrDefault(x => 
                x.UserNames.Contains(User.Identity.Name) || x.Roles.Intersect(x.Roles).Any());

            if (userPermission == null)
            {
                var url = new UrlHelper(filterContext.RequestContext);
                var loginUrl = url.Action("Login", "Account", null);
                filterContext.Result = new RedirectResult(loginUrl);
            }
        }
    }
}
