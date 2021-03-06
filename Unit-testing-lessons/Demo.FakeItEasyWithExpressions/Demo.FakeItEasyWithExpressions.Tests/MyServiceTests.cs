﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Demo.FakeItEasyWithExpressions.Core;
using FakeItEasy;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Demo.FakeItEasyWithExpressions.Tests
{
    [TestClass]
    public class MyServiceTests
    {
        private IMyService _service;

        [TestInitialize]
        public void SpinUp()
        {
            _service = A.Fake<IMyService>();
        }

        [TestMethod]
        public void Fake_service_call_predicate_with_one_parameter_returns_value()
        {
            //Arrange
            var testHarness = new TestHarness(_service);
            var person = new Person {PersonId = 1, Name = "bob"};

            A.CallTo(() => _service.FindByFunc(A<Func<Person, bool>>.That.Matches(x => x.Invoke(person))))
             .Returns(new List<Person> { person });
            //Act
            var people = testHarness.Find(x => x.PersonId == 1) as List<Person>;

            //Assert
            Assert.AreEqual(people.Count, 1);
        }

        [TestMethod]
        public void Fake_service_call_predicate_with_two_parameter_returns_value()
        {
            //Arrange
            var testHarness = new TestHarness(_service);
            var person = new Person { PersonId = 1, Name = "bob" };
            
            A.CallTo(() => _service.FindByExpression(
                A<Expression<Func<Person, bool>>>
                    .That.Matches(x => true))).Returns(new List<Person> { person }.AsQueryable());
            //Act
            var people = testHarness.FindInDataStore(x => x.PersonId == 1 && x.Name == "bob");

            //Assert
            Assert.AreEqual(people.Count(), 1);            
        }
    }
}
