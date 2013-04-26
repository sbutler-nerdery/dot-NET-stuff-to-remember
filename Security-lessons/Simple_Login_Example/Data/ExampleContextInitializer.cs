using System.Data.Entity;

namespace Data
{
    public class ExampleContextInitializer : DropCreateDatabaseIfModelChanges<ExampleContext>
    {
        protected override void Seed(ExampleContext context)
        {
            //ExampleUser dummyUser = new ExampleUser { UserName = "Dummy"};
            //context.Users.Add(dummyUser);
            //context.SaveChanges();
        }
    }
}
