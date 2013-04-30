using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Web.Models;

namespace Web.Data
{
    public class DefaultContext : DbContext
    {
        public DefaultContext()
            : base("DefaultConnection")
        {
        }

        public DbSet<UserProfile> UserProfiles { get; set; }
        public DbSet<FacebookApiInfo> FacebookApiValues { get; set; }
    }
}