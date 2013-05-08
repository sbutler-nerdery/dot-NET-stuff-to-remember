using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web.Helpers;

namespace Web.ViewModels
{
    /// <summary>
    /// The view model for data displayed on the /Account/ManageCustomPermissions action
    /// </summary>
    public class ManageCustomPermissionsViewModel
    {
        /// <summary>
        /// Get or set the list of security permissions for this view model.
        /// </summary>
        public List<CustomPermissionViewModel> Permissions { get; set; }
        /// <summary>
        /// Get or set a list of all urls
        /// </summary>
        public IEnumerable<SelectListItem> AllUrls { get; set; }
        /// <summary>
        /// Get or set a list of all user roles in the system
        /// </summary>
        public IEnumerable<SelectListItem> AllRoles { get; set; }
        /// <summary>
        /// Get or set a list of all user names in the system
        /// </summary>
        public IEnumerable<SelectListItem> AllUsers { get; set; }
        /// <summary>
        /// Get or set the new permissions to be added
        /// </summary>
        public CustomPermissionViewModel AddPermission { get; set; }
    }
}