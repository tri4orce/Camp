using Camp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Camp.ViewModels
{
    public class EditOrderViewModel
    {
        public Order Order { get; set; }
        public IEnumerable<Tour> Tours { get; set; }
        public IEnumerable<Voucher> Vouchers { get; set; }
    }
}
