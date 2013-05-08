using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Web.Data;
using Web.Helpers;
using WebMatrix.WebData;

namespace Web.Controllers
{
    //Setting the Authorize attribute on the base controller will ensure that the user is logged in.
    [Authorize]
    public class BaseController : Controller
    {
        protected override void OnAuthorization(AuthorizationContext filterContext)
        {
            base.OnAuthorization(filterContext);

            //Note: only controllers that inherit from BaseController will work with this security helper.
            var permissions = SecurityHelper.GetAllControllerPermissions();

            //Make sure that WebSecurity is initialized
            if (!WebSecurity.Initialized)
                WebSecurity.InitializeDatabaseConnection(Constants.DB_CONNECTION_STRING,
                    Constants.DB_USER_TABLE_NAME,
                    Constants.DB_USER_ID_COLUMN,
                    Constants.DB_USER_NAME_COLUMN, autoCreateTables: true);
            
            //Check to see if the user or the user group is in the list of permissions.
            var action = filterContext.ActionDescriptor.ActionName;
            var controller =
                filterContext.ActionDescriptor.ControllerDescriptor.ControllerName.Replace("Controller", "");
            var userRoles = Roles.GetRolesForUser(User.Identity.Name);
            var userPermission = permissions.FirstOrDefault(x => 
                x.ActionName == action &&
                x.ControllerName == controller &&
                (x.UserNames.Contains(User.Identity.Name) || x.Roles.Intersect(userRoles).Any()));

            if (userPermission == null)
            {
                //Redirect the user to the login page
                var url = new UrlHelper(filterContext.RequestContext);
                var loginUrl = url.Action("Login", "Account", null);
                filterContext.Result = new RedirectResult(loginUrl);
            }
        }
    }
}
