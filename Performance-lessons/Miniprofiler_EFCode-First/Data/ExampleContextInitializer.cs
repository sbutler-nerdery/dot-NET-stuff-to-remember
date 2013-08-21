using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Miniprofiler.CodeFirst.Models;

namespace Miniprofiler.CodeFirst.Data
{
    public class ExampleContextInitializer : DropCreateDatabaseIfModelChanges<ExampleContext>
    {
        protected override void Seed(ExampleContext context)
        {
            //Spawn users
            var people = new List<Person>();
            for (int i = 1; i <= 100; i++)
            {
                var person = new Person { Name = string.Format("Person #{0}", i), Gadgets = new List<Gadget>()};
                context.People.Add(person);
                people.Add(person);
            }

            context.SaveChanges();

            //Spawn gadgets
            for (int i = 1; i <= 1000; i++)
            {
                var personId = (i / 10 > 0) ? i / 10 : 1;
                var person = context.People.FirstOrDefault(x => x.PersonId == personId);
                var gadget = new Gadget { Name = string.Format("Gadget #{0}", i) };
                person.Gadgets.Add(gadget);
            }

            context.SaveChanges();
        }
    }
}