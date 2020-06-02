using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1
{
    public class CompanyCreateModel : PageModel
    {
        private readonly WebApplication1.Data.WebApplication1Context _context;

        private User user;

        public CompanyCreateModel(WebApplication1.Data.WebApplication1Context context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            

            return Page();
        }

        [BindProperty]
        public Company Company { get; set; }
        [BindProperty]
        public Address Address { get; set; }

        

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            user = await _context.User.FirstOrDefaultAsync(o => o.id == HttpContext.Session.GetInt32("user_id"));

            
            _context.Address.Add(Address);
            Company.Address = Address;
            _context.Company.Add(Company);
            user.Company = Company;
            await _context.SaveChangesAsync();

            return RedirectToPage("../User/UserPage", new { id = user.id });
        }
    }
}
