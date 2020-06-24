using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class Resturaunt
    {
        public int id { get; set; }
        [Required]
        [MaxLength(50), MinLength(5)]
        public String Name { get; set; }
        [Required]
        [MaxLength(50), MinLength(5)]
        public String Owner { get; set; }
        [Required]
        [Phone]
        public String Phone { get; set; }
        [Required]
        [EmailAddress]
        public String Email { get; set; }
        [MaxLength(50)]
        
        public String Website { get; set; }

        public Address Address { get; set; }
        public Location Location { get; set; }

        public ResturauntPage ResturauntPage { get; set; }
    }
}
