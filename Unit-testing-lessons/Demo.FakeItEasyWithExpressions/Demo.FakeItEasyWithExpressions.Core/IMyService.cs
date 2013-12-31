using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Demo.FakeItEasyWithExpressions.Core
{
    public interface IMyService
    {
        IEnumerable<Person> Find(Func<Person, bool> where);
    }
}
