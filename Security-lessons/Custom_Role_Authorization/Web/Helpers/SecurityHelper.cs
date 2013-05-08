using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using Web.Controllers;
using Web.Data;
using Web.Models;
using Web.ViewModels;

namespace Web.Helpers
{
    /// <summary>
    /// A helper that can read and write from the custom permissions table in the database.
    /// </summary>
    public class SecurityHelper
    {
        private static List<UrlLookupHelper> _urlLookupList = new List<UrlLookupHelper>();

        /// <summary>
        /// Get a collection of permissions for each controller on the site that inherit from base controller.
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<CustomPermissionViewModel> GetAllControllerPermissions()
        {
            _urlLookupList.Clear();
            var permissions = new List<CustomPermissionViewModel>();
            var assembly = Assembly.GetCallingAssembly();
            Type baseType = typeof(BaseController);
            var controllers = assembly.GetTypes().Where(x => baseType.IsAssignableFrom(x) && x.Name != "BaseController");

            foreach (var crtl in controllers)
            {
                var methods = crtl.GetMethods().Where(x => x.ReturnType == typeof(ActionResult));
                var controllerName = crtl.Name.Replace("Controller", "");
                foreach (var method in methods)
                {
                    var permissionExists =
                        permissions.FirstOrDefault(
                            x => x.ActionName == method.Name && x.ControllerName == controllerName);

                    //Only add the new permission if there is not already a permission for the current controller / action 
                    if (permissionExists == null)
                    {
                        var permission = new CustomPermissionViewModel
                        {
                            ControllerName = controllerName,
                            ActionName = method.Name,
                            UserNames = new List<string>(),
                            Roles = new List<string>()
                        };

                        using (var context = new UserRolesContext())
                        {
                            var row = context.Permissions.FirstOrDefault(x => x.Action == permission.ActionName
                                                                              && x.Controller == permission.ControllerName);
                            if (row != null)
                            {
                                permission.UserNames = (row.UserNames != null) ? row.UserNames.Split(new[] { ',' }).ToList() : new List<string>();
                                permission.Roles = (row.RoleNames != null) ? row.RoleNames.Split(new[] { ',' }).ToList() : new List<string>();
                                permission.CustomPermissionId = row.CustomPermissionId;
                            }
                        }

                        var urlHelper = new UrlHelper(HttpContext.Current.Request.RequestContext);
                        permission.Url = urlHelper.Action(permission.ActionName, permission.ControllerName);

                        permissions.Add(permission);

                        //Keep a list of all the available URLs
                        _urlLookupList.Add(new UrlLookupHelper
                            {
                                ActionName = permission.ActionName, 
                                ControllerName = permission.ControllerName, 
                                Url = permission.Url
                            });
                    }
                }
            }

            return permissions;
        }

        /// <summary>
        /// Update the permissions in the database 
        /// </summary>
        /// <param name="permissions">A collection of CustomPermissionViewModel</param>
        public static void UpdateSecurityPermission(CustomPermissionViewModel permission)
        {
            using (var context = new UserRolesContext())
            {
                //Get the appropriate action and controller for the updated URL...
                var lookup = _urlLookupList.FirstOrDefault(x => x.Url == permission.Url);

                var roleList = "";
                var userList = "";
                if (permission.Roles != null) permission.Roles.ForEach(role => roleList += (roleList == "") ? role : "," + role);
                if (permission.UserNames != null) permission.UserNames.ForEach(userName => userList += (userList == "") ? userName : "," + userName);

                var updateMe =
                    context.Permissions.FirstOrDefault(x => x.CustomPermissionId == permission.CustomPermissionId);

                if (updateMe != null)
                {
                    updateMe.Controller = lookup.ControllerName;
                    updateMe.Action = lookup.ActionName;
                    updateMe.RoleNames = roleList;
                    updateMe.UserNames = userList;                    
                }else
                {
                    var addMe = new CustomPermission();
                    addMe.Action = lookup.ActionName;
                    addMe.Controller = lookup.ControllerName;
                    addMe.RoleNames = roleList;
                    addMe.UserNames = userList;
                    context.Permissions.Add(addMe);
                }

                context.SaveChanges();
            }
        }

        /// <summary>
        /// Get a list of all the securable URLs on the site.
        /// </summary>
        /// <returns></returns>
        public static List<string> GetAllUrls()
        {
            return _urlLookupList.Select(x => x.Url).ToList();
        }

        /// <summary>
        /// A helper class to keep track of the URL association with different controller / action combinations
        /// </summary>
        private class UrlLookupHelper
        {
            public string Url { get; set; }
            public string ControllerName { get; set; }
            public string ActionName { get; set; }
        }
    }
}