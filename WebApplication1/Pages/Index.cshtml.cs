using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace WebApplication1.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        private readonly Data.WebApplication1Context _context;

        public List<Models.Resturaunt> Resturaunts;
        public List<Models.Deal> Deals;
        public List<Models.Location> Locations;

        public IndexModel(ILogger<IndexModel> logger, Data.WebApplication1Context context)
        {
            _logger = logger;
            _context = context;
        }

        public void OnGet()
        {

            Resturaunts = _context.Resturaunt.Include(m => m.ResturauntPage).ThenInclude(n => n.Days).ToList();
            Locations = _context.Location.ToList();
            foreach (var r in Resturaunts)
            {
                foreach(var d in r.ResturauntPage.Days)
                {
                    _context.Entry(d)
                        .Collection(s => s.Deals)
                        .Load();
                }

            }
            
        }
    }
}
