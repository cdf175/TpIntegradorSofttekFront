using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.DTOs
{
    public class WorkDto
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int ProyectId { get; set; }
        public int ServiceId { get; set; }
        public int HourQuantity { get; set; }
        public decimal HourValue { get; set; }
    }
}
