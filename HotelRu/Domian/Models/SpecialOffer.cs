using System;
using System.Collections.Generic;

namespace Domian.Models
{
    public  class SpecialOffer
    {
        public SpecialOffer()
        {
            BookedOffers = new HashSet<BookedOffer>();
        }

        public int OfferId { get; set; }
        public int? HotelId { get; set; }
        public string OfferName { get; set; } = null!;
        public string? Description { get; set; }
        public int? DiscountPercentage { get; set; }
        public DateTime? ValidFrom { get; set; }
        public DateTime? ValidTo { get; set; }

        public virtual Hotel? Hotel { get; set; }
        public virtual ICollection<BookedOffer> BookedOffers { get; set; }
    }
}
