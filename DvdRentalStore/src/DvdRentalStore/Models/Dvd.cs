using System;

namespace DvdRentalStore.Models
{
    public class Dvd: IEntity
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Director { get; set; }
        public IEntity Clone()
        {
            return new Dvd {Id = Id, Title = Title, Director = Director};
        }
    }
}
