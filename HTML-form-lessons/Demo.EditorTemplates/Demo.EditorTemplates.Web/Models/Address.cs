using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Demo.EditorTemplates.Web.Models
{
    public class Address
    {
        public int AddressId { get; set; }
        [Required]
        [Display(Name = "Address")]
        public string Address1 { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public AddressState State { get; set; }
        [Required]
        public string Zip { get; set; }
        public IEnumerable<AddressState> States { get; set; } 
    }
}