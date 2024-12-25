using System;
using System.Collections.Generic;

namespace Domian.Models
{
    public  class Region
    {
        public Region()
        {
            Cities = new HashSet<City>();
        }

        public int RegionId { get; set; }
        public string RegionName { get; set; } = null!;

        public virtual ICollection<City> Cities { get; set; }
    }
}
