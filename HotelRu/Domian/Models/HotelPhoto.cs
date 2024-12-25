using System;
using System.Collections.Generic;

namespace Domian.Models
{
    public  class HotelPhoto
    {
        public int PhotoId { get; set; }
        public int? HotelId { get; set; }
        public string? PhotoUrl { get; set; }

        public virtual Hotel? Hotel { get; set; }
    }
}
