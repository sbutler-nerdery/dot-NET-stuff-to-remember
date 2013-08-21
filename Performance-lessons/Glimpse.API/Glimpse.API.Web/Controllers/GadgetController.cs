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
    public class GadgetController : ApiController
    {
        private IRepository<Gadget> _GadgetRepository;

        public GadgetController(IRepository<Gadget> repo)
        {
            _GadgetRepository = repo;
        }

        // GET api/gadget
        public IEnumerable<Gadget> Get()
        {
            return _GadgetRepository.GetAll();
        }

        // GET api/gadget/5
        public Gadget Get(int id)
        {
            return _GadgetRepository.GetAll().FirstOrDefault(x => x.GadgetId == id);
        }

        // POST api/gadget
        public void Post(Gadget model)
        {
            _GadgetRepository.Insert(model);
            _GadgetRepository.SubmitChanges();
        }

        // PUT api/gadget/5
        public void Put(int id, Gadget model)
        {
            var updateMe = _GadgetRepository.GetAll().FirstOrDefault(x => x.GadgetId == id);
            updateMe.Name = model.Name;
            _GadgetRepository.SubmitChanges();
        }

        // DELETE api/gadget/5
        public void Delete(int id)
        {
            var deleteMe = _GadgetRepository.GetAll().FirstOrDefault(x => x.GadgetId == id);
            _GadgetRepository.Delete(deleteMe);
            _GadgetRepository.SubmitChanges();
        }
    }
}
