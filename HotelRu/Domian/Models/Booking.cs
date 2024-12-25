using System;
using System.Collections.Generic;

namespace Domian.Models
{
    public  class Booking
    {
        public Booking()
        {
            BookedOffers = new HashSet<BookedOffer>();
            BookingStatusHistories = new HashSet<BookingStatusHistory>();
            Payments = new HashSet<Payment>();
        }

        public int BookingId { get; set; }
        public int? UserId { get; set; }
        public int? RoomId { get; set; }
        public DateTime? CheckInDate { get; set; }
        public DateTime? CheckOutDate { get; set; }
        public byte? NumberOfGuests { get; set; }
        public decimal? TotalPrice { get; set; }
        public DateTime? BookingDate { get; set; }

        public virtual Room? Room { get; set; }
        public virtual User? User { get; set; }
        public virtual Admin? Admin { get; set; }
        public virtual ICollection<BookedOffer> BookedOffers { get; set; }
        public virtual ICollection<BookingStatusHistory> BookingStatusHistories { get; set; }
        public virtual ICollection<Payment> Payments { get; set; }
    }
}
