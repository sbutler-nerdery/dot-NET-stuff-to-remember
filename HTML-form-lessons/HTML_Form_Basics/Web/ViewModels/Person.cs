using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Web.ViewModels
{
    public class Person
    {
        [Required]
        [Display(Name = "First name")]
        public string FirstName { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        public List<School> SchoolsIWentTo { get; set; }
    }
}