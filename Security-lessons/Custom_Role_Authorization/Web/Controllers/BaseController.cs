using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Web.Data;
using Web.Helpers;
using Web.ViewModels;
using WebMatrix.WebData;

namespace Web.Controllers
{
    
    /// <summary>
    /// All of the other controllers on the site inherit from this controller. 
    /// </summary>
    [Authorize]
    public class BaseController : Controller
    {
        protected List<CustomPermissionViewModel> Permissions;

        protected override void OnAuthorization(AuthorizationContext filterContext)
        {
            base.OnAuthorization(filterContext);

            //Make sure that we are caching this lookup as it could be resource intensive...
            if (!CacheHelper.IsSet(Constants.CACHED_PERMISSIONS))
            {
                //Note: only controllers that inherit from BaseController will work with this security helper.
                CacheHelper.Set(Constants.CACHED_PERMISSIONS, SecurityHelper.GetAllControllerPermissions().ToList(), 120);
            }

            Permissions = CacheHelper.Get(Constants.CACHED_PERMISSIONS) as List<CustomPermissionViewModel>;

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
            var userPermission = Permissions.FirstOrDefault(x => 
                x.ActionName == action &&
                x.ControllerName == controller &&
                (x.UserNames.Contains(Constants.ANONYMOUS_USER) || x.UserNames.Contains(User.Identity.Name) || x.Roles.Intersect(userRoles).Any()));

            if (userPermission == null)
            {
                //Redirect the user to the login page
                var url = new UrlHelper(filterContext.RequestContext);
                var loginUrl = url.Action("Login", "Account", null);
                filterContext.Result = new RedirectResult(loginUrl);
            }
        }

        protected string GetPermisionMessage(string action, string controller)
        {
            var permission =
                Permissions.FirstOrDefault(x => x.ActionName == action && x.ControllerName == controller);

            var roleList = "";
            var userList = "";
            if (permission.Roles != null) permission.Roles.ForEach(role => roleList += (roleList == "") ? role : "," + role);
            if (permission.UserNames != null) permission.UserNames.ForEach(userName => userList += (userList == "") ? userName : "," + userName);

            roleList = (roleList == "") ? "none" : roleList;
            userList = (userList == "") ? "none" : userList;

            return string.Format("To view this page you are logged into one of these roles: (<u>{0}</u>), or you are one of these users: (<u>{1}</u>)", roleList, userList);            
        }
    }
}
