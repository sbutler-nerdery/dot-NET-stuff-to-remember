using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Models;

namespace Common.Data
{
    public class ComplexRelationshipContextInitializer : DropCreateDatabaseIfModelChanges<ComplexRelationshipContext>
    {
        protected override void Seed(ComplexRelationshipContext context)
        {
            //Table that has a many to many relationship with itself
            var johnSmith = new Person { Name = "John Smith", Friends = new List<Person>()};
            var joeBlow = new Person { Name = "Joe Blow", Friends = new List<Person>() };
            var paulHart = new Person { Name = "Paul Hart", Friends = new List<Person>() };

            johnSmith.Friends.Add(joeBlow);
            johnSmith.Friends.Add(paulHart);

            context.People.Add(johnSmith);

            //Save to call the save function here in order to have person ids since the order of execution cannot be forced in EF
            context.SaveChanges();

            //Standard many to many relationships
            var aBigEvent = new CompanyEvent { Name = "The big event" };

            aBigEvent.PeopleInvited.AddRange( new[] {
                johnSmith, joeBlow, paulHart
            });

            johnSmith.AcceptedInvitations.Add(aBigEvent);
            joeBlow.DeclinedInvitations.Add(aBigEvent);

            context.CompanyEvents.Add(aBigEvent);

            context.SaveChanges();
        }
    }
}
