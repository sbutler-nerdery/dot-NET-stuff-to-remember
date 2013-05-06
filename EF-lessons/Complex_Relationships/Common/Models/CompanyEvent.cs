using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Models
{
    public class CompanyEvent
    {
        public CompanyEvent()
        {
            PeopleInvited = new List<Person>();
            PeopleWhoAccepted = new List<Person>();
            PeopleWhoDeclined = new List<Person>();
        }
        public int CompanyEventId { get; set; }
        public string Name { get; set; }
        public virtual List<Person> PeopleInvited { get; set; }
        public virtual List<Person> PeopleWhoAccepted { get; set; }
        public virtual List<Person> PeopleWhoDeclined { get; set; }
    }
}
