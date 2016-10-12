using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DvdRentalStore.Models;
using DvdRentalStore.Repository;
using Microsoft.AspNetCore.Mvc;

namespace DvdRentalStore.Controllers
{
    [Route("api/[controller]")]
    public class ClientsController : Controller
    {
        private IRepositoryLocator Repository { get; }

        public ClientsController(IRepositoryLocator repositoryLocator)
        {
            Repository = repositoryLocator;
        }

        // GET api/values
        [HttpGet]
        public IEnumerable<Client> Get()
        {
            return Repository.Find<Client>().ToList();
        }
        
        // GET api/values/5
        [HttpGet("{id}")]
        public Client Get(Guid id)
        {
            return Repository.GetById<Client>(id);
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] Client value)
        {
            Repository.Add(value);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put([FromBody] Client value)
        {
            Repository.Update(value);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(Guid id)
        {
            Repository.Delete<Client>(id);
        }
    }
}