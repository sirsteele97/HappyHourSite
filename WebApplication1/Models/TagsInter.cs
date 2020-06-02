using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class TagsInter
    {
        public int DealID { get; set; }
        public Deal Deal{get;set;}
        public int TagID { get; set; }
        public Tags Tag { get; set; }

    }
}
