using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Demo.FakeItEasyWithExpressions.Core
{
    public class MyService :IMyService
    {
        private readonly List<Person> _people;

        public MyService()
        {
            _people = new List<Person>
                {
                    new Person{ PersonId = 1, Name = "Charles Bronson", DOB = DateTime.Parse("7/20/1971")},
                    new Person{ PersonId = 2, Name = "Edward Pointer", DOB = DateTime.Parse("9/3/1985")},
                    new Person{ PersonId = 3, Name = "Bart Simpson", DOB = DateTime.Parse("3/17/1950")},
                };    
        }
        public IEnumerable<Person> Find(Func<Person, bool> where)
        {
            return _people.Where(where);
        }
    }
}
