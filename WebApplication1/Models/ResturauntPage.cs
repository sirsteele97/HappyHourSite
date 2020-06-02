using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class ResturauntPage
    {
        public int id { get; set; }
        public String Description { get; set; }
        public List<Day> Days { get; set; }

        public String Facebook { get; set; }
        public String Twitter { get; set; }
        public String Instagram { get; set; }

        public String Youtube { get; set; }

        public String LinkedIn { get; set; }

        public String Yelp { get; set; }

        public Image Image { get; set; }
    }
}
