using System;
using System.Collections.Generic;

namespace Domian.Models
{
    public  class Hotel
    {
        public Hotel()
        {
            HotelPhotos = new HashSet<HotelPhoto>();
            Reviews = new HashSet<Review>();
            Rooms = new HashSet<Room>();
            SpecialOffers = new HashSet<SpecialOffer>();
            Amenities = new HashSet<Amenity>();
            Users = new HashSet<User>();
        }

        public int HotelId { get; set; }
        public string HotelName { get; set; } = null!;
        public int? CityId { get; set; }
        public byte? Stars { get; set; }
        public string? Description { get; set; }
        public string? Address { get; set; }
        public decimal? Latitude { get; set; }
        public decimal? Longitude { get; set; }

        public virtual City? City { get; set; }
        public virtual ICollection<HotelPhoto> HotelPhotos { get; set; }
        public virtual ICollection<Review> Reviews { get; set; }
        public virtual ICollection<Room> Rooms { get; set; }
        public virtual ICollection<SpecialOffer> SpecialOffers { get; set; }

        public virtual ICollection<Amenity> Amenities { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}
