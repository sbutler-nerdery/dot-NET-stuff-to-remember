using System.Data.Entity;
using Data.Model;

namespace Data
{
    public class ExampleContext : DbContext
    {
        //To set the name of the database update the value that is passed to the base from the constructor...
        public ExampleContext() : base("MyCustomDatabaseName") { }
        public DbSet<Example> Examples { get; set; }
    }
}
