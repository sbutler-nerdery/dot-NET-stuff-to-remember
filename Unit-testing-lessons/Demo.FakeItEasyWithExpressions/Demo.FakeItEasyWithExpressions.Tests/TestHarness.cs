using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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

        public IEnumerable<Person> Find(Func<Person, bool> where)
        {
            return _service.FindByFunc(where);
        }

        public IQueryable<Person> FindInDataStore(Expression<Func<Person, bool>> where)
        {
            return _service.FindByExpression(where);
        }
    }
}
