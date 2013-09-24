using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Demo.WebApi.OData.Web.Controllers
{
    public class PeopleController : ApiController
    {
        private List<Person> _Data;

        public PeopleController()
        {
            _Data = new List<Person>();

            for (int i = 0; i < 100; i++)
            {
                _Data.Add(new Person
                    {
                        PersonId = i,
                        FirstName = string.Format("First Name #{0}", i),
                        LastName = string.Format("Last Name #{0}", i),
                        MyFriend = new Person
                            {
                                PersonId = i + 100,
                                FirstName = string.Format("Friend First Name {0}", i + 100),
                                LastName = string.Format("Friend Last Name {0}", i + 100),
                            }
                    });
            }
        }

        /// <summary>
        /// Get stuff from a data source using OData conventions. see http://www.odata.org/documentation/odata-v3-documentation/url-conventions/
        /// for full list of options. Names used in the OData filters are case sensative!
        /// </summary>
        /// <example>
        /// api/values?$filter=substringof('First', FirstName) eq true --> return data were first name contains a value
        /// api/values?$filter=startswith(FirstName,'First') --> return data were first name starts with a value
        /// api/values?$filter=endswith(MyFriend/FirstName,'111') --> filter by child objects!
        /// api/values?$filter=PersonId ge 95 and PersonId le 105 --> return data were person id id between two values
        /// api/values?$orderby=FirstName desc&$top=10 --> order by a field and only return 10 values
        /// </example>
        /// <returns></returns>
        [Queryable]
        public IQueryable<Person> Get()
        {
            return _Data.AsQueryable();
        }

        // GET api/values/5
        public Person Get(int id)
        {
            return _Data.FirstOrDefault(x => x.PersonId == id);
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
            throw new NotImplementedException("The POST service has not been implimented!");
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
            throw new NotImplementedException("The PUT service has not been implimented!");
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
            throw new NotImplementedException("The DELETE service has not been implimented!");
        }
    }

    public class Person
    {
        public int PersonId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Person MyFriend { get; set; }
    }
}