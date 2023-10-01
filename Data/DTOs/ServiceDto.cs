using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.DTOs
{
	public class ServiceDto
	{
        public  int Id { get; set; }
        public string Description { get; set; }
        public bool State { get; set; }
        public decimal HourValue { get; set; }
    }
}
