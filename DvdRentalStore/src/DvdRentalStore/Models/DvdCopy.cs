using System;

namespace DvdRentalStore.Models
{
    public class DvdCopy: IEntity
    {
        public Guid Id { get; set; }
        public Guid BookId { get; set; }
        public IEntity Clone()
        {
            return new DvdCopy {Id = Id, BookId = BookId};
        }
    }
}