using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Common.Data;
using Common.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Common.Tests
{
    [TestClass]
    public class PersonTests
    {
        [TestInitialize]
        public void SpinUp()
        {
            Database.SetInitializer(new ComplexRelationshipContextInitializer());
        }

        [TestMethod]
        public void John_Has_Two_Friends()
        {
            using (var context = new ComplexRelationshipContext())
            {
                var john = context.People.FirstOrDefault();
                
                Assert.AreEqual(john.Friends.Count, 2);
            }
        }

        [TestMethod]
        public void Joe_And_Paul_Are_Friends_With_John()
        {
            using (var context = new ComplexRelationshipContext())
            {
                var joe = context.People.FirstOrDefault(x => x.Name == "Joe Blow");
                var paul = context.People.FirstOrDefault(x => x.Name == "Paul Hart");

                //They should both be friends with John Smith, so a count of one friend
                Assert.AreEqual(joe.Friends.Count, 1);
                Assert.AreEqual(paul.Friends.Count, 1);
            }
        }

        [TestMethod]
        public void People_Were_Invted_To_Event()
        {
            using (var context = new ComplexRelationshipContext())
            {
                var theBigEvent = context.CompanyEvents.FirstOrDefault();
                var john = context.People.FirstOrDefault(x => x.Name.Contains("John"));
                var joe = context.People.FirstOrDefault(x => x.Name.Contains("Joe"));
                var paul = context.People.FirstOrDefault(x => x.Name.Contains("Paul"));

                john.MyEventInvitations =
                    context.CompanyEvents.Where(x => x.PeopleInvited.Select(y => y.PersonId).Contains(john.PersonId))
                           .ToList();

                joe.MyEventInvitations =
                    context.CompanyEvents.Where(x => x.PeopleInvited.Select(y => y.PersonId).Contains(joe.PersonId))
                           .ToList();

                paul.MyEventInvitations =
                    context.CompanyEvents.Where(x => x.PeopleInvited.Select(y => y.PersonId).Contains(paul.PersonId))
                           .ToList();

                Assert.AreEqual(theBigEvent.PeopleInvited.Count, 3);
                Assert.AreEqual(john.MyEventInvitations.Count, 1);
                Assert.AreEqual(joe.MyEventInvitations.Count, 1);
                Assert.AreEqual(paul.MyEventInvitations.Count, 1);
            }            
        }

        [TestMethod]
        public void John_Accepted_The_Invite()
        {
            using (var context = new ComplexRelationshipContext())
            {
                var theBigEvent = context.CompanyEvents.FirstOrDefault();
                var joe = context.People.FirstOrDefault(x => x.Name == "Joe Blow");

                joe.MyEventInvitations =
                    context.CompanyEvents.Where(x => x.PeopleWhoAccepted.Select(y => y.PersonId).Contains(joe.PersonId))
                           .ToList();

                Assert.AreEqual(theBigEvent.PeopleWhoAccepted.Count, 1);
                Assert.AreEqual(joe.AcceptedInvitations.Count, 1);
            }
        }

        [TestMethod]
        public void Paul_Declined_The_Invite()
        {
            using (var context = new ComplexRelationshipContext())
            {
                var theBigEvent = context.CompanyEvents.FirstOrDefault();
                var paul = context.People.FirstOrDefault(x => x.Name == "Paul hart");

                paul.MyEventInvitations =
                    context.CompanyEvents.Where(x => x.PeopleWhoDeclined.Select(y => y.PersonId).Contains(paul.PersonId))
                           .ToList();

                Assert.AreEqual(theBigEvent.PeopleWhoDeclined.Count, 1);
                Assert.AreEqual(paul.DeclinedInvitations.Count, 1);
            }
        }
    }
}
