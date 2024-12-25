using System;
using System.Collections.Generic;

namespace Domian.Models
{
    public  class City
    {
        public City()
        {
            Hotels = new HashSet<Hotel>();
        }

        public int CityId { get; set; }
        public string CityName { get; set; } = null!;
        public int? RegionId { get; set; }

        public virtual Region? Region { get; set; }
        public virtual ICollection<Hotel> Hotels { get; set; }
    }
}
