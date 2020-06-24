using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class ResturauntPage
    {
        public int id { get; set; }
        [MaxLength(500)]
        public String Description { get; set; }
        public List<Day> Days { get; set; }

        [MaxLength(50)]
        public String Facebook { get; set; }
        [MaxLength(50)]
        public String Twitter { get; set; }
        [MaxLength(50)]
        public String Instagram { get; set; }
        [MaxLength(50)]

        public String Youtube { get; set; }
        [MaxLength(50)]

        public String LinkedIn { get; set; }
        [MaxLength(50)]
        public String Yelp { get; set; }

        public Image Image { get; set; }
    }
}
