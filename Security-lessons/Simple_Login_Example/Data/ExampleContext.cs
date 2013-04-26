using System.Data.Entity;
using Data.Models;

namespace Data
{
    public class ExampleContext : DbContext
    {
        public ExampleContext() : base("SimpleLoginExample"){ }

        public static readonly string ConnectionString = "DefaultConnection";
        public static readonly string UserTableName = "Users";
        public static readonly string UserIdProperty = "ExampleUserId";
        public static readonly string UserNameProperty = "UserName";

        public DbSet<ExampleUser> Users { get; set; }
    }
}
