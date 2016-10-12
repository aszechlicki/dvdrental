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
    public class RentalsController : Controller
    {
        private IRepositoryLocator Repository { get; }

        public RentalsController(IRepositoryLocator repositoryLocator)
        {
            Repository = repositoryLocator;
        }

        // GET api/values
        [HttpGet]
        public IEnumerable<RentalDTO> Get()
        {
            return Repository.Find<RentalRecord>().Select(rental => new RentalDTO
            {
                Rental = rental,
                Client = Repository.GetById<Client>(rental.ClientId),
                Dvd = Repository.GetById<Dvd>(rental.DvdId)
            });
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public RentalDTO Get(Guid id)
        {
            var rental = Repository.GetById<RentalRecord>(id);
            return new RentalDTO
            {
                Rental = rental,
                Client = Repository.GetById<Client>(rental.ClientId),
                Dvd = Repository.GetById<Dvd>(rental.DvdId)
            };
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] RentalRecord value)
        {
            value.RentalTime = DateTimeOffset.Now;
            var rentals = Repository.Find<RentalRecord>().Where(r => r.DvdId == value.DvdId).Select(r => r.CopyId);
            // find first available copy
            var copyId = Repository.Find<DvdCopy>().Select(c => c.Id).Except(rentals).FirstOrDefault();
            if (copyId == null)
            {
                throw new Exception("There are no copies available");
            }
            value.CopyId = copyId;
            Repository.Add(value);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put([FromBody] RentalRecord value)
        {
            Repository.Update(value);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(Guid id)
        {
            Repository.Delete<RentalRecord>(id);
        }

        public class RentalDTO
        {
            public RentalRecord Rental { get; set; }
            public Client Client { get; set; }
            public Dvd Dvd { get; set; }
        }
    }
}