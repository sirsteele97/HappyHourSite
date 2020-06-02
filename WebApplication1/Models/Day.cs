using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class Day
    {
        public int id { get; set; }
        public String DayName { get; set; }
        public List<Deal> Deals { get; set; }
        public String OpenTime { get; set; }
        public String CloseTime { get; set; }


    }
}
