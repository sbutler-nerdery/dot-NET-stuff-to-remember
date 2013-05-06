using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Models;

namespace Common.Data
{
    public class ComplexRelationshipContext : DbContext
    {
        public DbSet<Person> People { get; set; }
        public DbSet<CompanyEvent> CompanyEvents { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //A many to many table that maps to itself.
            modelBuilder.Entity<Person>().HasMany(p => p.Friends)
                .WithMany()
                .Map(mc =>
                    {
                        mc.ToTable("PersonFriends");
                        mc.MapLeftKey("PersonId");
                        mc.MapRightKey("FriendId");
                    });


            //Standard many to many relationships
            modelBuilder.Entity<CompanyEvent>().HasMany(c => c.PeopleInvited)
                .WithMany(p => p.MyEventInvitations)
                .Map(mc =>
                {
                    mc.ToTable("PeopleInvited");
                    mc.MapLeftKey("CompanyEventId");
                    mc.MapRightKey("PersonId");
                });

            modelBuilder.Entity<CompanyEvent>().HasMany(c => c.PeopleWhoAccepted)
                .WithMany(p => p.AcceptedInvitations)
                .Map(mc =>
                {
                    mc.ToTable("PeopleWhoExcepted");
                    mc.MapLeftKey("CompanyEventId");
                    mc.MapRightKey("PersonId");
                });

            modelBuilder.Entity<CompanyEvent>().HasMany(c => c.PeopleWhoDeclined)
                .WithMany(p => p.DeclinedInvitations)
                .Map(mc =>
                {
                    mc.ToTable("PeopleWhoDeclined");
                    mc.MapLeftKey("CompanyEventId");
                    mc.MapRightKey("PersonId");
                });
        }
    }
}
