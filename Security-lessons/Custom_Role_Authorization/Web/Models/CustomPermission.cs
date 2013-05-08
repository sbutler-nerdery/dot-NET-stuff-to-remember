using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.Models
{
    public class CustomPermission
    {
        public int CustomPermissionId { get; set; }
        public string Controller { get; set; }
        public string Action { get; set; }
        public string UserNames { get; set; }
        public string RoleNames { get; set; }
    }
}