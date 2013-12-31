using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demo.FakeItEasyWithExpressions.Core;

namespace Demo.FakeItEasyWithExpressions.Tests
{
    public class TestHarness
    {
        private IMyService _service;

        public TestHarness(IMyService service)
        {
            _service = service;
        }

        public IEnumerable<Person> FindAPerson(Func<Person, bool> where)
        {
            return _service.Find(where);
        }
    }
}
