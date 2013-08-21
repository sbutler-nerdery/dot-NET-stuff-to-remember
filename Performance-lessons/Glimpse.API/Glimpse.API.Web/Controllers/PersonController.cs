using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Glimpse.API.Web.Data;
using Glimpse.API.Web.Models;

namespace Glimpse.API.Web.Controllers
{
    public class PersonController : ApiController
    {
        private IRepository<Person> _PersonRepository;

        public PersonController(IRepository<Person> repo)
        {
            _PersonRepository = repo;
        }

        // GET api/person
        public IEnumerable<Person> Get()
        {
            return _PersonRepository.GetAll("Gadgets");
        }

        // GET api/person/5
        public Person Get(int id)
        {
            return _PersonRepository.GetAll("Gadgets").FirstOrDefault(x => x.PersonId == id);
        }

        // POST api/person
        public void Post(Person model)
        {
            _PersonRepository.Insert(model);
            _PersonRepository.SubmitChanges();
        }

        // PUT api/person/5
        public void Put(int id, Person model)
        {
            var updateMe = _PersonRepository.GetAll().FirstOrDefault(x => x.PersonId == id);
            updateMe.Name = model.Name;
            _PersonRepository.SubmitChanges();
        }

        // DELETE api/person/5
        public void Delete(int id)
        {
            var deleteMe = _PersonRepository.GetAll().FirstOrDefault(x => x.PersonId == id);
            _PersonRepository.Delete(deleteMe);
            _PersonRepository.SubmitChanges();
        }
    }
}
