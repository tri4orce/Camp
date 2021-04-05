using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Camp.Models
{
    public class Tour
    {
        public int TourId { get; set; }
        public string Name { get; set; } // Наименование смены
        
        [Column(TypeName = "date")]
        public DateTime StartDate { get; set; } // Дата начала смены
        public int CountOfPlace { get; set; } // Количество свободных мест

        public List<Order> Orders { get; set; } = new List<Order>();
    }
}
