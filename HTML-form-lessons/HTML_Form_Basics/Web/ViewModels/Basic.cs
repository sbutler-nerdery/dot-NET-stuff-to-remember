using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Web.ViewModels
{
    public class School
    {
        [Required]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Phone number")]
        public string PhoneNumer { get; set; }
    }
}