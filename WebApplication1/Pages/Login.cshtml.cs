using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace WebApplication1
{
    public class LoginModel : PageModel
    {
        private readonly WebApplication1.Data.WebApplication1Context _context;

        public LoginModel(WebApplication1.Data.WebApplication1Context context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public User User { get; set; }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {

            User u = new User();
            u = await _context.User.FirstOrDefaultAsync(m => m.Password == Request.Form["password"].ToString() && m.Username == Request.Form["username"].ToString());

            if(u != null)
            {
                return RedirectToPage("./User/UserPage", new { id = u.id });
            }
            
            return RedirectToPage("./Index");
        }
    }
}