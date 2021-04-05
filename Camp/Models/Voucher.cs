using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Camp.Models
{
    public class Voucher
    {
        public int VoucherId { get; set; }
        public string Name { get; set; } // Наименование путевки
        public int Price { get; set; }
        public int CountOfDay { get; set; }
        public string Description { get; set; } // Описание
        public string ServiceList { get; set; } // Перечень предоставляемых услуг

        public List<Order> Orders { get; set; } = new List<Order>();
    }
}
