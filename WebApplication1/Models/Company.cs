using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class Company
    {
        public int id { get; set; }
        [Required]
        [MaxLength(100)]
        public String Name { get; set; }
        [Required]
        [MaxLength(30)]
        public String Owner { get; set; }
        [Required]
        [EmailAddress]
        public String Email { get; set; }
        [Required]
        [Phone]
        public String Phone { get; set; }
        public Address Address { get; set; }
        public List<Resturaunt> Resturaunts { get; set; }
    }
}
