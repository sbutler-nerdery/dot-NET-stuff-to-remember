using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demo.FakeItEasyWithExpressions.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Demo.FakeItEasyWithExpressions.Tests
{
    [TestClass]
    public class MyServiceLiveTests
    {
        private MyService _service;

        [TestInitialize]
        public void SpinUp()
        {
            _service = new MyService();
        }

        [TestMethod]
        public void Can_find_person_by_name()
        {
            var results = _service.Find(x => x.Name.Contains("Charles"));
            Assert.AreEqual(results.Count(), 1);
        }

        [TestMethod]
        public void Can_find_person_by_DOB()
        {
            var results = _service.Find(x => x.DOB == DateTime.Parse("9/3/1985"));
            Assert.AreEqual(results.Count(), 1);
        }

        [TestMethod]
        public void Can_find_person_by_Id()
        {
            var results = _service.Find(x => x.PersonId == 1);
            Assert.AreEqual(results.Count(), 1);
        }
    }
}
