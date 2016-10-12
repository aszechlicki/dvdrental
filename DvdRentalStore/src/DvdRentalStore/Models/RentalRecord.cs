using System;

namespace DvdRentalStore.Models
{
    public class RentalRecord : IEntity
    {
        public Guid Id { get; set; }
        public Guid ClientId { get; set; }
        public Guid CopyId { get; set; }
        public Guid DvdId { get; set; }
        public DateTimeOffset RentalTime { get; set; }
        public IEntity Clone()
        {
            return new RentalRecord {ClientId = ClientId, CopyId = CopyId, DvdId = DvdId, RentalTime = RentalTime};
        }
    }
}
