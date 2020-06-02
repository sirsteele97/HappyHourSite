using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class Address
    {
        public int id { get; set; }
        public String Country { get; set; }
        public String State { get; set; }
        public String City { get; set; }
        public String AddressLine1 { get; set; }
        public String AddressLine2 { get; set; }
        public String Zip { get; set; }
    }
}
