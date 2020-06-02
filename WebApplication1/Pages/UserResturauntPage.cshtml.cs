using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1
{
    public class UserResturauntPageModel : PageModel
    {
        private readonly WebApplication1.Data.WebApplication1Context _context;

        public UserResturauntPageModel(WebApplication1.Data.WebApplication1Context context)
        {
            _context = context;
        }

        [BindProperty]
        public Resturaunt Resturaunt { get; set; }
        public ResturauntPage ResturauntPage { get; set; }

        public String imageDataURL { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Resturaunt = await _context.Resturaunt.Include(m => m.ResturauntPage).ThenInclude(m => m.Days).Include(m => m.ResturauntPage).ThenInclude(m => m.Image).FirstOrDefaultAsync(m => m.id == id);
            ResturauntPage = Resturaunt.ResturauntPage;
            Day[] days = Resturaunt.ResturauntPage.Days.ToArray<Day>();
            for (int i = 0; i < days.Length; i++)
            {
                days[i] = await _context.Day.Include(d => d.Deals).FirstOrDefaultAsync(m => m.id == days[i].id);

            }

            if (Resturaunt == null)
            {
                return NotFound();
            }

            if (ResturauntPage.Image.ImageVal != null)
            {
                Image img = ResturauntPage.Image;
                string imageBase64Data = Convert.ToBase64String(img.ImageVal);
                imageDataURL = string.Format("data:image/jpg;base64,{0}", imageBase64Data);

            }

            return Page();
        }
    }
}