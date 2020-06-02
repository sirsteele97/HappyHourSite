using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApplication1
{
    public class LogoutModel : PageModel
    {

        private readonly WebApplication1.Data.WebApplication1Context _context;

        public LogoutModel(WebApplication1.Data.WebApplication1Context context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        public IActionResult OnPost()
        {
            HttpContext.Session.Clear();

            return RedirectToPage("./Index");
        }
    }
}