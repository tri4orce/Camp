using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Camp.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ContactPhone { get; set; }
        public bool Processed { get; set; }

        public int VoucherId { get; set; }
        public Voucher Voucher { get; set; }

        public int TourId { get; set; }
        public Tour Tour { get; set; }
    }
}
