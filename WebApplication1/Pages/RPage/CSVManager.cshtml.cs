using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using CsvHelper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApplication1.CSV;
using WebApplication1.Models;

namespace WebApplication1
{
    public class CSVManagerModel : PageModel
    {
        private readonly WebApplication1.Data.WebApplication1Context _context;

        public CSVManagerModel(WebApplication1.Data.WebApplication1Context context)
        {
            _context = context;
        }

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


        }

        public async Task<IActionResult> OnPostAsync()
        {
            int id = (int)HttpContext.Session.GetInt32("current_resturaunt");
            Resturaunt R = await _context.Resturaunt.Include(m => m.ResturauntPage).ThenInclude(m => m.Days).FirstOrDefaultAsync(m => m.id == id);
            foreach(var i in R.ResturauntPage.Days)
            {
                _context.Entry(i)
                    .Collection(s => s.Deals)
                    .Load();
            }

            var file = Request.Form.Files.First();
            using (var reader = file.OpenReadStream())
            {
                TextReader tr = new StreamReader(reader);
                using (var csv = new CsvReader(tr, CultureInfo.InvariantCulture))
                {
                    csv.Configuration.HasHeaderRecord = false;
                    var deals = csv.GetRecords<CSVDeal>();

                    foreach (var d in deals)
                    {
                        
                        Deal deal = new Deal() { ItemName = d.DealName, Desription = d.DealDescription, StartTime = d.StartTime, EndTime = d.EndTime };
                        _context.Deal.Add(deal);
                        if(deal != null )
                        {
                            R.ResturauntPage.Days.Where(n => n.DayName.ToLower() == d.DayOfWeek.ToLower()).FirstOrDefault().Deals.Add(deal);
                        }
                       
                    }

                    _context.Attach(R).State = EntityState.Modified;

                    try
                    {
                        await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {

                    }
                }
            }
            


            
            
           
            return Page();
        }
    }
}