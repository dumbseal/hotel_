using System;
using System.Collections.Generic;

namespace Domian.Models
{
    public  class Amenity
    {
        public Amenity()
        {
            Hotels = new HashSet<Hotel>();
        }

        public int AmenityId { get; set; }
        public string AmenityName { get; set; } = null!;

        public virtual ICollection<Hotel> Hotels { get; set; }
    }
}
