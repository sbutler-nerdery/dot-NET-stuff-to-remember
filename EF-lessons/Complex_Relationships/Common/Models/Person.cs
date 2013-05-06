using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Models
{
    /// <summary>
    /// This model has a simple many to many relationship using an intermediary table to link back to itself.
    /// </summary>
    public class Person
    {
        public Person()
        {
            Friends = new List<Person>();
            MyEventInvitations = new List<CompanyEvent>();
            AcceptedInvitations = new List<CompanyEvent>();
            DeclinedInvitations = new List<CompanyEvent>();
        }
        public int PersonId { get; set; }
        public string Name { get; set; }
        public virtual List<Person> Friends { get; set; }
        public virtual List<CompanyEvent> MyEventInvitations { get; set; }
        public virtual List<CompanyEvent> AcceptedInvitations { get; set; }
        public virtual List<CompanyEvent> DeclinedInvitations { get; set; }
    }
}
