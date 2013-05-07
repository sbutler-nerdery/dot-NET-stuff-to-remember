using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using Web.Controllers;
using Web.Data;

namespace Web.Helpers
{
    public class SecurityHelper
    {
        /// <summary>
        /// Get a collection of permissions for each controller on the site that inherit from base controller.
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<SecurityPermissionDefinition> GetAllControllerPermissions()
        {
            var permissions = new List<SecurityPermissionDefinition>();
            var assembly = Assembly.GetCallingAssembly();
            Type baseType = typeof(BaseController);
            var controllers = assembly.GetTypes().Where(x => baseType.IsAssignableFrom(x) && x.Name != "BaseController");

            foreach (var crtl in controllers)
            {
                var methods = crtl.GetMethods().Where(x => x.ReturnType == typeof(ActionResult));
                foreach (var method in methods)
                {
                    var permission = new SecurityPermissionDefinition
                        {
                            ControllerName = crtl.Name.Replace("Controller",""),
                            ActionName = method.Name
                        };

                    using (var context = new UserRolesContext())
                    {
                        var row = context.Permissions.FirstOrDefault(x => x.Action == permission.ActionName
                                                                          && x.Controller == permission.ControllerName);
                        if (row != null)
                        {
                            permission.UserNames = row.UserNames.Split(new[] { ',' }).ToList();
                            permission.Roles = row.RoleNames.Split(new[] { ',' }).ToList();                            
                        }
                    }

                    permissions.Add(permission);
                }
            }

            return permissions;
        }
    }

    public class SecurityPermissionDefinition
    {
        public SecurityPermissionDefinition()
        {
            Roles = new List<string>();
            UserNames = new List<string>();
        }
        public string ControllerName { get; set; }
        public string ActionName { get; set; }
        public string Url {
            get
            {
                var urlHelper = new UrlHelper(HttpContext.Current.Request.RequestContext);
                return urlHelper.Action(ActionName, ControllerName);
            }
        }
        public List<string> Roles { get; set; }
        public List<string> UserNames { get; set; }
    }
}