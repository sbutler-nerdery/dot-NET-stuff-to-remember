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


            /*
            Standard many to many relationships... but why are we creating them this way?
            Well, because we are creating multiple many to many relationships between the same two tables. Left to itself, 
             EF will do something like:
             - in the People table it will add these columns:
                - Person_1 -- this is the PeopleInvited relationship
                - Person_2 -- this is the PeopleWhoAccepted relationship
                - Person_3 -- this is the PeopleWhoDeclined relationship
            I don't want this to happen. I want a separate intermediary table for each relationship. */
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
