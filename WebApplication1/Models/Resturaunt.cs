using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class Resturaunt
    {
        public int id { get; set; }
        public String Name { get; set; }
        public String Owner { get; set; }
        public String Phone { get; set; }
        public String Email { get; set; }
        public String Website { get; set; }

        public Address Address { get; set; }
        public Location Location { get; set; }

        public ResturauntPage ResturauntPage { get; set; }
    }
}
