using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;

namespace Web.ViewModels
{
    /// <summary>
    /// This is a class stores controller / action data along with username and role information.
    /// </summary>
    public class CustomPermissionViewModel
    {
        /// <summary>
        /// Get or set the custom permissions id
        /// </summary>
        public int CustomPermissionId { get; set; }
        /// <summary>
        /// Get or set the name of the controller 
        /// </summary>
        public string ControllerName { get; set; }
        /// <summary>
        /// Get or set the name of the action
        /// </summary>
        public string ActionName { get; set; }
        /// <summary>
        /// Get the url displayed in the query string for this controller and action combination
        /// </summary>
        public string Url { get; set; }
        /// <summary>
        /// Get or set the list of roles that are allowed access to this controller / action combination
        /// </summary>
        public List<string> Roles { get; set; }
        /// <summary>
        /// Get or set the list of user names that are allowed access to this controller / action combination
        /// </summary>
        public List<string> UserNames { get; set; }
    }
}