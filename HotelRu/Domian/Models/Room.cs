using System;
using System.Collections.Generic;

namespace Domian.Models
{
    public  class Room
    {
        public Room()
        {
            Bookings = new HashSet<Booking>();
        }

        public int RoomId { get; set; }
        public int? HotelId { get; set; }
        public int? RoomTypeId { get; set; }
        public string? RoomNumber { get; set; }
        public decimal? PricePerNight { get; set; }
        public byte? Capacity { get; set; }

        public virtual Hotel? Hotel { get; set; }
        public virtual RoomType? RoomType { get; set; }
        public virtual ICollection<Booking> Bookings { get; set; }
    }
}
