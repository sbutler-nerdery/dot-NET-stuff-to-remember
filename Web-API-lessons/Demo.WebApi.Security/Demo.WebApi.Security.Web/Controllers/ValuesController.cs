using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Demo.WebApi.Security.Web.Controllers
{
    public class PersonController : ApiController
    {
        private List<Person> _Data;

        public PersonController()
        {
            _Data = new List<Person>();
            _Data.Add(new Person{ PersonId = 1, PersonName = "Sam Smith"});
        }

        // GET api/values
        public IEnumerable<Person> Get()
        {
            return _Data;
        }

        // GET api/values/5
        public Person Get(int id)
        {
            return _Data.FirstOrDefault(x => x.PersonId == id);
        }

        // POST api/values
        public void Post(Person model)
        {
            throw new NotImplementedException("The POST service has not been implimented");
        }

        // PUT api/values/5
        public void Put(int id, Person model)
        {
            throw new NotImplementedException("The POST service has not been implimented");
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
            throw new NotImplementedException("The POST service has not been implimented");
        }
    }

    public class Person
    {
        public int PersonId { get; set; }
        public string PersonName { get; set; }
    }
}