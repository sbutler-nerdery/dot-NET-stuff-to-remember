using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Model
{
    /// <summary>
    /// On line 42 of InitializeSimpleMembershipAttribute, this is the table name specified for the custom user's table
    /// </summary>
    [Table("Users")]
    public class ExampleUser
    {
        public int ExampleUserId { get; set; }
        public string UserName { get; set; }
        public string EmailAddress { get; set; }
        public string PhoneNumber { get; set; }
    }
}
