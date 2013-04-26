using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Model;

namespace Data
{
    public class ExampleContextInitializer : DropCreateDatabaseAlways<ExampleContext>
    {
        protected override void Seed(ExampleContext context)
        {
            var myExampleRow = new Example { SomethingImportant = "I was just added to the database!"};
            context.Examples.Add(myExampleRow);
            context.SaveChanges();
        }
    }
}
