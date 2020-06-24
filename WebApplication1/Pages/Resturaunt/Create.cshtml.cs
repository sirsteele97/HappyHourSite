using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Geocoding;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Models;
using WebApplication1.Utils;
using Xamarin.Essentials;

namespace WebApplication1
{
    public class CreateModel : PageModel
    {
        private readonly WebApplication1.Data.WebApplication1Context _context;

        public CreateModel(WebApplication1.Data.WebApplication1Context context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Resturaunt Resturaunt { get; set; }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            Company Company = await _context.Company.Include(o => o.Resturaunts).FirstOrDefaultAsync(r => r.id == HttpContext.Session.GetInt32("company_id"));
            ResturauntPage resturauntPage = new ResturauntPage();

            resturauntPage.Days = new List<Day>();
            resturauntPage.Days.Add(new Day(){ DayName = "Monday" });
            resturauntPage.Days.Add(new Day() { DayName = "Tuesday" });
            resturauntPage.Days.Add(new Day() { DayName = "Wednesday" });
            resturauntPage.Days.Add(new Day() { DayName = "Thursday" });
            resturauntPage.Days.Add(new Day() { DayName = "Friday" });
            resturauntPage.Days.Add(new Day() { DayName = "Saturday" });
            resturauntPage.Days.Add(new Day() { DayName = "Sunday" });
            resturauntPage.Image = new Image();

            Resturaunt.ResturauntPage = resturauntPage;

            String Address = Resturaunt.Address.AddressLine1 + " " + Resturaunt.Address.AddressLine2 + " " + Resturaunt.Address.City + " " + Resturaunt.Address.State + " " + Resturaunt.Address.Country + " " + Resturaunt.Address.Zip;
            IGeocoder geocoder = new Geocoding.Microsoft.BingMapsGeocoder("AqxoCm4UJW5_DXYlq73P9Vso_jGJl60qBQSZnt6VhtCv9wZSK2SbSAKq_ljydb6S");
            IEnumerable<Geocoding.Address> addresses = await geocoder.GeocodeAsync(Address);

            Models.Location location = new Models.Location();
            location.Lang = addresses.First().Coordinates.Latitude;
            location.Long = addresses.First().Coordinates.Longitude;


            Resturaunt.Location = location;
            
            Company.Resturaunts.Add(Resturaunt);
            _context.Resturaunt.Add(Resturaunt);
            location.ResturauntId = Resturaunt.id;
            _context.Location.Add(location);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
