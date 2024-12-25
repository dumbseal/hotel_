using System;
using System.Collections.Generic;

namespace Domian.Models
{
    public  class RoomType
    {
        public RoomType()
        {
            Rooms = new HashSet<Room>();
        }

        public int RoomTypeId { get; set; }
        public string TypeName { get; set; } = null!;
        public string? Description { get; set; }

        public virtual ICollection<Room> Rooms { get; set; }
    }
}
