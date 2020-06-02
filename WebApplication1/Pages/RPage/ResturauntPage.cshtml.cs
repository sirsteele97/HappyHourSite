using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1
{
    public class ResturauntPageModel : PageModel
    {

        public WebApplication1.Data.WebApplication1Context _context;

        public ResturauntPageModel(WebApplication1.Data.WebApplication1Context context)
        {
            _context = context;
        }
        [BindProperty]
        public Day Day { get; set; }

        [BindProperty]
        public ResturauntPage ResturauntPage { get; set; }

        public Resturaunt Resturaunt;
        [BindProperty]
        public Day Monday { get; set; }
        [BindProperty]
        public Day Tuesday { get; set; }
        [BindProperty]
        public Day Wendsday { get; set; }
        [BindProperty]
        public Day Thursday { get; set; }
        [BindProperty]
        public Day Friday { get; set; }
        [BindProperty]
        public Day Saturday { get; set; }
        [BindProperty]
        public Day Sunday { get; set; }

        [BindProperty]
        public Deal Deal { get; set; }
        [BindProperty]
        public List<Deal> Deals { get; set; }

        public List<Tags> Tags { get; set; }
        public String imageDataURL {get;set;}

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Resturaunt = await _context.Resturaunt.Include(m => m.ResturauntPage).ThenInclude(m => m.Days).Include(m => m.ResturauntPage).ThenInclude(m => m.Image).FirstOrDefaultAsync(m => m.id == id);
            ResturauntPage = Resturaunt.ResturauntPage;

            Tags = await _context.Tags.Select(m => m).ToListAsync();

            Day[] days = Resturaunt.ResturauntPage.Days.ToArray<Day>();
            Deals = new List<Deal>();
            
            for(int i = 0; i < days.Length; i++)
            {
                days[i] = await _context.Day.Include(d => d.Deals).FirstOrDefaultAsync(m => m.id == days[i].id);
                Deals.AddRange(days[i].Deals);
            }
            Monday = days[0];
            Tuesday = days[1];
            Wendsday = days[2];
            Thursday = days[3];
            Friday = days[4];
            Saturday = days[5];
            Sunday = days[6];

            if (Resturaunt == null)
            {
                return NotFound();
            }

            if(ResturauntPage.Image.ImageVal != null)
            {
                Image img = ResturauntPage.Image;
                string imageBase64Data = Convert.ToBase64String(img.ImageVal);
                imageDataURL = string.Format("data:image/jpg;base64,{0}", imageBase64Data);

            }

            return Page();
        }

        public async Task<IActionResult> OnPostPageAsync(int id, Image Img)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            
            if(Request.Form.Files.ToArray().Length > 0)
            {
                var file = Request.Form.Files.First();
                Img.ImageName = file.FileName;

                MemoryStream ms = new MemoryStream();
                file.CopyTo(ms);
                Img.ImageVal = ms.ToArray();
                ms.Close();
                ms.Dispose();

                Resturaunt.ResturauntPage.Image = Img;
            }

            _context.Attach(ResturauntPage).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ResturauntPageExists(Day.id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./ResturauntPage", new { id = id });
        }

        public async Task<IActionResult> OnPostAddAsync(int? id, int? did)
        {
            if(did == null || id == null)
            {
                return NotFound();
            }

            Day = await _context.Day.Include(m => m.Deals).FirstOrDefaultAsync(m => m.id == did);
            Day.Deals.Add(Deal);
            
            _context.Deal.Add(Deal);
            _context.Attach(Day).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ResturauntPageExists(Day.id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./ResturauntPage", new { id = id });
        }

        public async Task<IActionResult> OnPostDeleteAsync(int id, int did)
        {
            Deal = await _context.Deal.FirstOrDefaultAsync(m => m.id == did);

            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Deal.Remove(Deal);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DealExists(Deal.id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./ResturauntPage", new { id = id });
        }

        public async Task<IActionResult> OnPostEditAsync(int id, int did)
        {
            Deal d = await _context.Deal.FirstOrDefaultAsync(m => m.id == did);

            if (!ModelState.IsValid)
            {
                return Page();
            }

            d.ItemName = Request.Form["ItemName"];
            d.StartTime = (String)Request.Form["StartTime"];
            d.EndTime = (String)Request.Form["EndTime"];
            d.ValueOff = int.Parse(Request.Form["ValueOff"]);
            d.ItemType = Request.Form["ItemType"];

            _context.Attach(d).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DealExists(Deal.id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./ResturauntPage", new { id = id });
        }

        private bool DealExists(int id)
        {
            return _context.Deal.Any(e => e.id == id);
        }
    

    public async Task<IActionResult> OnPostAsync(int did, int id)
        {
            switch (did)
            {
                case 1:
                    Day = Monday;
                    Day.DayName = "Monday";
                    break;
                case 2:
                    Day = Tuesday;
                    Day.DayName = "Tuesday";
                    break;
                case 3:
                    Day = Wendsday;
                    Day.DayName = "Wendsday";
                    break;
                case 4:
                    Day = Thursday;
                    Day.DayName = "Thursday";
                    break;
                case 5:
                    Day = Friday;
                    Day.DayName = "Friday";
                    break;
                case 6:
                    Day = Saturday;
                    Day.DayName = "Saturday";
                    break;
                case 7:
                    Day = Sunday;
                    Day.DayName = "Sunday";
                    break;
            }


            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Day).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DayExists(Day.id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./ResturauntPage" , new {id = id});
        }

        private bool DayExists(int id)
        {
            return _context.Day.Any(e => e.id == id);
        }

        private bool ResturauntPageExists(int id)
        {
            return _context.ResturauntPage.Any(e => e.id == id);
        }

    }
}