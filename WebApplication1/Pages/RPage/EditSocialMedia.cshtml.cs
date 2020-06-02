using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1
{
    public class EditSocialMediaModel : PageModel
    {
        private readonly WebApplication1.Data.WebApplication1Context _context;

        public EditSocialMediaModel(WebApplication1.Data.WebApplication1Context context)
        {
            _context = context;
        }

        [BindProperty]
        public Resturaunt Resturaunt { get; set; }

        public async Task OnGetAsync(int id)
        {
            Byte[] OutVal;
            if (!HttpContext.Session.TryGetValue("current_resturaunt", out OutVal))
            {
                HttpContext.Session.SetInt32("current_resturaunt", id);
            }
            else
            {
                id = (int)HttpContext.Session.GetInt32("current_resturaunt");
            }

            Resturaunt = await _context.Resturaunt.Include(m => m.Address).Include(m => m.ResturauntPage).FirstOrDefaultAsync(m => m.id == id);


        }

        public async Task<IActionResult> OnPostAsync()
        {
            _context.Attach(Resturaunt).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ResturauntExists((int)HttpContext.Session.GetInt32("current_resturaunt")))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage();
        }

        private bool ResturauntExists(int id)
        {
            return _context.Resturaunt.Any(e => e.id == id);
        }
    
    }
}