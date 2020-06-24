using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class Deal
    {
        public int id { get; set; }
        public String StartTime { get; set; }
        public String EndTime { get; set; }

        [MaxLength(50)]
        public String ItemName { get; set; }
        [MaxLength(150)]
        public String Desription { get; set; }

        public ICollection<TagsInter> TagsInter { get; set; } = new List<TagsInter>();
    }
}
