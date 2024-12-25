using System;
using System.Collections.Generic;

namespace Domian.Models
{
    public  class PaymentMethod
    {
        public PaymentMethod()
        {
            Payments = new HashSet<Payment>();
        }

        public int PaymentMethodId { get; set; }
        public string MethodName { get; set; } = null!;

        public virtual ICollection<Payment> Payments { get; set; }
    }
}
