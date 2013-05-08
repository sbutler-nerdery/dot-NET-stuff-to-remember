using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.ViewModels
{
    public class EditCustomPermissionViewModel
    {
        /// <summary>
        /// Get or set the permission to edit.
        /// </summary>
        public CustomPermissionViewModel Permission { get; set; }
        /// <summary>
        /// Get or set a list of all urls
        /// </summary>
        public SelectList AllUrls { get; set; }
        /// <summary>
        /// Get or set a list of all user roles in the system
        /// </summary>
        public SelectList AllRoles { get; set; }
        /// <summary>
        /// Get or set a list of all user names in the system
        /// </summary>
        public SelectList AllUsers { get; set; }
    }
}