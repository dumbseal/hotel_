using System;
using System.Collections.Generic;

namespace Domian.Models
{
    public  class Review
    {
        public int ReviewId { get; set; }
        public int? UserId { get; set; }
        public int? HotelId { get; set; }
        public byte? Rating { get; set; }
        public string? Comment { get; set; }
        public DateTime? ReviewDate { get; set; }

        public virtual Hotel? Hotel { get; set; }
        public virtual User? User { get; set; }
    }
}
