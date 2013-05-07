using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using Web.Controllers;

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

                    //TODO: call database to get users and roles that belong to this permission
                    permissions.Add(permission);
                }
            }

            return permissions;
        }
    }

    public class SecurityPermissionDefinition
    {
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