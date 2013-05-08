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
        private List<SelectListItem> _roleListItems;
        private List<SelectListItem> _userListItems;
        private SelectListItem _selectedUrl;

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
        public SelectListItem SelectedUrl {
            get
            {
                _selectedUrl = new SelectListItem{Selected = true, Text = Url, Value = Url};
                return _selectedUrl;
            }
            set
            {
                _selectedUrl = value;
                Url = _selectedUrl.Value;
            }
        }
        public List<SelectListItem> SelectedListBoxRoles {
            get
            {
                //Build list items from the Roles propery
                _roleListItems = new List<SelectListItem>();

                Roles.ForEach(role => _roleListItems.Add(new SelectListItem { Selected = true, Text = role, Value = role }));
                return _roleListItems;
            }
            set
            {
                Roles.Clear();
                _roleListItems = value;
                _roleListItems.ForEach(lisItem => Roles.Add(lisItem.Value));                
            }
        }
        /// <summary>
        /// Get or set the list of Username SelectListItems used by the MVC listbox control
        /// </summary>
        public List<SelectListItem> SelectedListBoxUserNames
        {
            get
            {
                //Build list items from the UserNames propery
                _userListItems = new List<SelectListItem>();

                UserNames.ForEach(role => _userListItems.Add(new SelectListItem { Selected = true, Text = role, Value = role }));
                return _userListItems;
            }
            set
            {
                UserNames.Clear();
                _userListItems = value;
                _userListItems.ForEach(lisItem => UserNames.Add(lisItem.Value));
            }
        }
    }
}