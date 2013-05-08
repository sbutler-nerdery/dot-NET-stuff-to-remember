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
    }
}