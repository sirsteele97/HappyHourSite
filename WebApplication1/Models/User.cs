using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1
{
    public class User
    {
        public int id { get; set; }
        [Required]
        [MaxLength(20), MinLength(5)]
        public String Username { get; set; }
        [Required]
        [MaxLength(20), MinLength(5)]
        public String Password { get; set; }
        [Required]
        [EmailAddress]
        public String Email { get; set; }

        public Company Company { get; set; }

    }
}
