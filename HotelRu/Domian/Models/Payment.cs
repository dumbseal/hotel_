using System;
using System.Collections.Generic;

namespace Domian.Models
{
    public  class Payment
    {
        public int PaymentId { get; set; }
        public int? BookingId { get; set; }
        public int? PaymentMethodId { get; set; }
        public decimal? Amount { get; set; }
        public DateTime? PaymentDate { get; set; }

        public virtual Booking? Booking { get; set; }
        public virtual PaymentMethod? PaymentMethod { get; set; }
    }
}
