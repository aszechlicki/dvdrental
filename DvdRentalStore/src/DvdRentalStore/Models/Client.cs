using System;

namespace DvdRentalStore.Models
{
    public class Client : IEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public IEntity Clone()
        {
            return new Client {Id = Id, Name = Name};
        }
    }
}
