using System.Data.Entity;

namespace Data
{
    public class SimpleLoginExampleContextInitializer : DropCreateDatabaseIfModelChanges<SimpleLoginExampleContext>
    {
        protected override void Seed(SimpleLoginExampleContext context)
        {
            //ExampleUser dummyUser = new ExampleUser { UserName = "Dummy"};
            //context.Users.Add(dummyUser);
            //context.SaveChanges();
        }
    }
}
