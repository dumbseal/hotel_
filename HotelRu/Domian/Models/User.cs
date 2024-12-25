using System;
using System.Collections.Generic;

namespace Domian.Models
{
    public  class User
    {
        public User()
        {
            Bookings = new HashSet<Booking>();
            Reviews = new HashSet<Review>();
            Hotels = new HashSet<Hotel>();
        }

        public int UserId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string Email { get; set; } = null!;
        public string PasswordHash { get; set; } = null!;

        public virtual ICollection<Booking> Bookings { get; set; }
        public virtual ICollection<Review> Reviews { get; set; }

        public virtual ICollection<Hotel> Hotels { get; set; }
    }
}
