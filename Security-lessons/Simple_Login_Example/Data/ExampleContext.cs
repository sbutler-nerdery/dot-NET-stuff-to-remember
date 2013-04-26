using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Model;

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
