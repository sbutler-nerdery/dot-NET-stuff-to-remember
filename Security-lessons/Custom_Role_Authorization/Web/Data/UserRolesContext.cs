using System.Data.Entity;
using Web.Models;

namespace Web.Data
{
    public class UserRolesContext : DbContext
    {
        #region Constructors
        public UserRolesContext()
            : base(Constants.DB_CONNECTION_STRING)
        {
        }

        #endregion

        #region Properties

        public DbSet<UserProfile> UserProfiles { get; set; }
        public DbSet<CustomPermission> Permissions { get; set; }

        #endregion
    }
}