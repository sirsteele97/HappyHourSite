using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class Image
    {
        [Key]
        public int id { get; set; }
        public String ImageName { get; set; }
        public String ImageType { get; set; }
        public Byte[] ImageVal { get; set; }
    }
}
