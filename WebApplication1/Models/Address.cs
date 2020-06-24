using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class Address
    {
        public int id { get; set; }
        [Required]
        public String Country { get; set; }
        [Required]
        public String State { get; set; }
        [Required]
        public String City { get; set; }
        [Required]
        public String AddressLine1 { get; set; }
        public String AddressLine2 { get; set; }
        [Required]
        public String Zip { get; set; }
    }
}
