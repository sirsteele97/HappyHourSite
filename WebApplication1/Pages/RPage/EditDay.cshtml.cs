using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1
{
    public class EditDayModel : PageModel
    {
        private readonly WebApplication1.Data.WebApplication1Context _context;

        public EditDayModel(WebApplication1.Data.WebApplication1Context context)
        {
            _context = context;
        }

        public List<Tags> Tags { get; set; }

        [BindProperty]
        public Day Day { get; set; }

        [BindProperty]
        public List<Deal> Deals { get; set; }

        [BindProperty]
        public int[] SelectedTags { get; set; }
        public async Task OnGetAsync(int id, int day)
        {

            Tags = new List<Tags>();
            
            Byte[] OutVal;
            if (!HttpContext.Session.TryGetValue("current_resturaunt", out OutVal))
            {
                HttpContext.Session.SetInt32("current_resturaunt", id);
            }
            else
            {
                id = (int)HttpContext.Session.GetInt32("current_resturaunt");
            }
            Resturaunt R = await _context.Resturaunt.Include(m => m.ResturauntPage).ThenInclude(m => m.Days).FirstOrDefaultAsync(m => m.id == id);

            Tags = _context.Tags.ToList();
            SelectedTags = new int[Tags.Count];
            switch (day)
            {
                case 1:
                    Day = await _context.Day.Include(m => m.Deals).FirstOrDefaultAsync(m => m.id == R.ResturauntPage.Days.ElementAt(0).id);
                    Deals = Day.Deals;
                    Day.DayName = "Monday";
                    break;
                case 2:
                    Day = await _context.Day.Include(m => m.Deals).FirstOrDefaultAsync(m => m.id == R.ResturauntPage.Days.ElementAt(1).id);
                    Deals = Day.Deals;
                    Day.DayName = "Tuesday";
                    break;
                case 3:
                    Day = await _context.Day.Include(m => m.Deals).FirstOrDefaultAsync(m => m.id == R.ResturauntPage.Days.ElementAt(2).id);
                    Deals = Day.Deals;
                    Day.DayName = "Wednesday";
                    break;
                case 4:
                    Day = await _context.Day.Include(m => m.Deals).FirstOrDefaultAsync(m => m.id == R.ResturauntPage.Days.ElementAt(3).id);
                    Deals = Day.Deals;
                    Day.DayName = "Thursday";
                    break;
                case 5:
                    Day = await _context.Day.Include(m => m.Deals).FirstOrDefaultAsync(m => m.id == R.ResturauntPage.Days.ElementAt(4).id);
                    Deals = Day.Deals;
                    Day.DayName = "Friday";
                    break;
                case 6:
                    Day = await _context.Day.Include(m => m.Deals).FirstOrDefaultAsync(m => m.id == R.ResturauntPage.Days.ElementAt(5).id);
                    Deals = Day.Deals;
                    Day.DayName = "Saturday";
                    break;
                case 7:
                    Day = await _context.Day.Include(m => m.Deals).FirstOrDefaultAsync(m => m.id == R.ResturauntPage.Days.ElementAt(6).id);
                    Deals = Day.Deals;
                    Day.DayName = "Sunday";
                    break;
            }

            //preperation for tags
            foreach (var x in Day.Deals)
            {
                _context.Entry(x)
                    .Collection(s => s.TagsInter)
                    .Load();

            }

        }

        public async Task<IActionResult> OnPostAsync()
        {
            Day.OpenTime = (String)Request.Form["OpenTime"];
          
            Day.CloseTime = (String)Request.Form["CloseTime"];

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
            return RedirectToPage(new { day = GetDayValue(Day) });
        }

        public async Task<IActionResult> OnPostAddAsync(int did)
        {
            Day Day = await _context.Day.Include(m => m.Deals).FirstOrDefaultAsync(m => m.id == did);

            Deal Deal = new Deal();
            
            
            _context.Deal.Add(Deal);
            Day.Deals.Add(Deal);
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
            return RedirectToPage(new { day = GetDayValue(Day)});
        }

        public async Task<IActionResult> OnPostDeleteAsync(int DealId, int DayId)
        {
            Day = await _context.Day.Include(m => m.Deals).FirstOrDefaultAsync(m => m.id == DayId);
            Deal Deal = await _context.Deal.FirstOrDefaultAsync(m => m.id == DealId);
            _context.Deal.Remove(Deal);

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
            return RedirectToPage(new { day = GetDayValue(Day) });
        }

        public async Task<IActionResult> OnPostUpdateAsync(int DealId, int DayId)
        {
            Day = await _context.Day.Include(m => m.Deals).FirstOrDefaultAsync(m => m.id == DayId);

            Deal d = await _context.Deal.Include(m => m.TagsInter).FirstOrDefaultAsync(m => m.id == DealId);

            Tags = _context.Tags.ToList();

            var SelectedTags = Request.Form["Tags"].ToArray();

            if (!ModelState.IsValid)
            {
                return Page();
            }

            d.ItemName = Request.Form["ItemName"];
            d.StartTime = (String)Request.Form["StartTime"];
            d.EndTime = (String)Request.Form["EndTime"];
            d.Desription = Request.Form["Description"];

            d.TagsInter.Clear();

            foreach(var t in SelectedTags)
            {
                d.TagsInter.Add(new TagsInter() { TagID = int.Parse(t), DealID = d.id, Deal = d, Tag = Tags.Where(n => n.id == int.Parse(t)).FirstOrDefault() }) ;
            }

            _context.Attach(d).State = EntityState.Modified;

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
            return RedirectToPage(new { day = GetDayValue(Day) });
        }

        public int GetDayValue(Day Day)
        {
            int DayId = 0;

            switch (Day.DayName)
            {
                case "Monday":
                    DayId = 1;
                    break;
                case "Tuesday":
                    DayId = 2;
                    break;
                case "Wednesday":
                    DayId = 3;
                    break;
                case "Thursday":
                    DayId = 4;
                    break;
                case "Friday":
                    DayId = 5;
                    break;
                case "Saturday":
                    DayId = 6;
                    break;
                case "Sunday":
                    DayId = 7;
                    break;
            }
            return DayId;
        }
            private bool DayExists(int id)
        {
            return _context.Day.Any(e => e.id == id);
        }
    }
}