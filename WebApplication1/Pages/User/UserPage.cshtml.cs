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
    public class UserPageModel : PageModel
    {

        private readonly WebApplication1.Data.WebApplication1Context _context;

        public User user;

        public UserPageModel(WebApplication1.Data.WebApplication1Context context)
        {
            _context = context;
        }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if(id == null)
            {
                id = HttpContext.Session.GetInt32("user_id");
            }

            user = await _context.User.Include(m => m.Company).FirstOrDefaultAsync(m => m.id == id );    

            if(user == null)
            {
                return NotFound();
            }
            else
            {
                SetSession();
            }

            return Page();
        }

        public void SetSession()
        {
            HttpContext.Session.SetInt32("user_id", user.id);
            if(user.Company != null)
            {
                HttpContext.Session.SetInt32("company_id", user.Company.id);
            }
            
        }
    }
}