using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class Location
    {
        public int id { get; set; }
        public double Long { get; set; }
        public double Lang { get; set; }

        public int ResturauntId { get; set; }
    }
}
