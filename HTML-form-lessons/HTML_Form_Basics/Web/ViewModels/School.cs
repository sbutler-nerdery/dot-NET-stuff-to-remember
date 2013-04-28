using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Web.ViewModels
{
    public class School
    {
        public int Index { get; set; }
        [Required]
        [Display(Name= "School name")]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Phone number")]
        public string PhoneNumber { get; set; }
        public bool IsTemplate { get; set; }
    }
}