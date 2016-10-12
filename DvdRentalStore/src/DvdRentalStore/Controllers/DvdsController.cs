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
    public class DvdsController : Controller
    {
        private IRepositoryLocator Repository { get; }

        public DvdsController(IRepositoryLocator repositoryLocator)
        {
            Repository = repositoryLocator;
        }

        // GET api/values
        [HttpGet]
        public IEnumerable<MovieDTO> Get()
        {
            return Repository.Find<Dvd>().Select(movie => new MovieDTO(movie, CountCopies(movie.Id))).ToList();
        }
        
        // GET api/values/5
        [HttpGet("{id}")]
        public MovieDTO Get(Guid id)
        {
            return new MovieDTO(Repository.GetById<Dvd>(id), CountCopies(id));
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] Dvd value)
        {
            Repository.Add(value);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put([FromBody] Dvd value)
        {
            Repository.Update(value);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(Guid id)
        {
            Repository.Delete<Dvd>(id);
        }

        private int CountCopies(Guid id)
        {
            var totalCopies = Repository.Find<DvdCopy>().Count(copy => copy.BookId == id);
            return totalCopies - Repository.Find<RentalRecord>().Count(record => record.DvdId == id);
        }

        public class MovieDTO
        {
            public MovieDTO(Dvd movie, int availableCopies)
            {
                Movie = movie;
                AvailableCopies = availableCopies;
            }

            public Dvd Movie { get; }
            public int AvailableCopies { get; }
        }
    }
}