using System;

namespace DvdRentalStore.Models
{
    public interface IEntity
    {
        Guid Id { get; set; }
        IEntity Clone();
    }
}