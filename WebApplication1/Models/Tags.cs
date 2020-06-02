using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class Tags
    {
        public int id { get; set;}
        public String TagName { get; set; }
        public int Catagory { get; set; }

        public ICollection<TagsInter> TagsInter { get; } = new List<TagsInter>();
    }
}
 