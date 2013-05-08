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
        private List<string> _roleListItems;
        private List<string> _userListItems;
        private string _selectedUrl;

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
        /// <summary>
        /// Get or set the seleced Url for this permission
        /// </summary>
        public string SelectedUrl {
            get
            {
                _selectedUrl = Url;
                return _selectedUrl;
            }
            set
            {
                _selectedUrl = value;
                Url = _selectedUrl;
            }
        }
        public List<string> SelectedListBoxRoles {
            get
            {
                //Build list items from the Roles propery
                _roleListItems = new List<string>();

                Roles.ForEach(role => _roleListItems.Add(role));
                return _roleListItems;
            }
            set
            {
                Roles.Clear();
                _roleListItems = value;
                _roleListItems.ForEach(lisItem => Roles.Add(lisItem));                
            }
        }
        /// <summary>
        /// Get or set the list of Username SelectListItems used by the MVC listbox control
        /// </summary>
        public List<string> SelectedListBoxUserNames
        {
            get
            {
                //Build list items from the UserNames propery
                _userListItems = new List<string>();

                UserNames.ForEach(userName => _userListItems.Add(userName));
                return _userListItems;
            }
            set
            {
                UserNames.Clear();
                _userListItems = value;
                _userListItems.ForEach(lisItem => UserNames.Add(lisItem));
            }
        }
    }
}