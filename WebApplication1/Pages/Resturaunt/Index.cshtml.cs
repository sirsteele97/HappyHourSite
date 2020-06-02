using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1
{
    public class IndexModel : PageModel
    {
        private readonly WebApplication1.Data.WebApplication1Context _context;

        public IndexModel(WebApplication1.Data.WebApplication1Context context)
        {
            _context = context;
        }

        public IList<Resturaunt> Resturaunt { get;set; }

        public async Task OnGetAsync()
        {
            Company Company = await _context.Company.Include(c => c.Resturaunts).FirstOrDefaultAsync(r => r.id == HttpContext.Session.GetInt32("company_id"));
            Resturaunt = Company.Resturaunts;
            HttpContext.Session.Remove("current_resturaunt");
        }
    }
}
