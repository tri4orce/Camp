using Camp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Camp.ViewModels
{
    public class OrderIndexViewModel
    {
        public IEnumerable<Tour> Tours { get; set; }
        public IEnumerable<Voucher> Vouchers { get; set; }
    }
}
