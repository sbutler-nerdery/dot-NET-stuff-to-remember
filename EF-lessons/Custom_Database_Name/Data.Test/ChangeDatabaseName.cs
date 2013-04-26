using System.Data.Entity;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Data.Test
{
    [TestClass]
    public class ChangeDatabaseName
    {
        [TestMethod]
        public void UpdateDatabaseName()
        {
            Database.SetInitializer(new ExampleContextInitializer());

            using (var context = new ExampleContext())
            {
                var example = context.Examples.FirstOrDefault();
                Assert.AreNotEqual(example, null);
            }
        }
    }
}
