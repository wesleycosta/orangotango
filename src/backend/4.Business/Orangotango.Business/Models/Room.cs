using Orangotango.Core.DomainObjects;
using System;

namespace Orangotango.Business.Models
{
    public class Room : Entity
    {
        public string Name { get; set; }
        public byte Number { get; set; }
        public Guid RoomTypeId { get; set; }
    }
}
