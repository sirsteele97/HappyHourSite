using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class Deal
    {
        public int id { get; set; }
        public String StartTime { get; set; }
        public String EndTime { get; set; }

        public String ItemName { get; set; }
        public String ItemType { get; set; }
        public int ValueOff { get; set; }

        public ICollection<TagsInter> TagsInter { get; set; } = new List<TagsInter>();
    }
}
