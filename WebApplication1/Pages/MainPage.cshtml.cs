using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using WebApplication1.Utils;

using WebApplication1.Models;

namespace WebApplication1
{
    public class MainPageModel : PageModel
    {
        private readonly ILogger<MainPageModel> _logger;

        private readonly Data.WebApplication1Context _context;

        public List<Models.Resturaunt> Resturaunts;
        public List<Models.Deal> Deals;
        public List<Models.Location> Locations;
        public List<Models.Tags> Tags;
        public Dictionary<int, int> Ranking;
        public int day;
        public String SearchLine { get; set; }
        public bool my_loc;

        public MainPageModel(ILogger<MainPageModel> logger, Data.WebApplication1Context context)
        {
            _logger = logger;
            _context = context;
        }

        public PageResult OnGet(String? search, String? location, bool my_location, int day)
        {
            this.day = day;
            this.my_loc = my_location;
            string remoteIpAddress = "";

            if ((bool)my_location)
                {

                Resturaunts = _context.Resturaunt
                    .Include(m => m.ResturauntPage)
                        .ThenInclude(n => n.Days)
                    .Include(n => n.Location)
                    .Include(n => n.Address)
                    .ToList();

                remoteIpAddress = HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
                if (Request.Headers.ContainsKey("X-Forwarded-For"))
                    remoteIpAddress = Request.Headers["X-Forwarded-For"];


                //I am forcing my IP Fix before outside testing!!!!!
                Resturaunts = Resturaunts.Where(n => Xamarin.Essentials.Location.CalculateDistance(new Xamarin.Essentials.Location(n.Location.Lang, n.Location.Long), new LocationConverter().Get("2605:a000:ee44:e800::6").Result, DistanceUnits.Miles) <= 20).ToList();
                }
                else
                {
                    if (location != null)
                    {
                        Resturaunts = _context.Resturaunt
                        .Where(n=> n.Address.City == location)
                            .Include(m => m.ResturauntPage)
                                .ThenInclude(n => n.Days)
                            .Include(n => n.Location)
                            .Include(n => n.Address)
                            .ToList();
                }
                    else
                    {
                        
                    }
                }
                
            if(Resturaunts != null)
            {
                foreach (var r in Resturaunts)
                {
                    foreach (var d in r.ResturauntPage.Days)
                    {
                        _context.Entry(d)
                            .Collection(s => s.Deals)
                            .Load();

                        foreach (var t in d.Deals)
                        {
                            _context.Entry(t)
                                .Collection(s => s.TagsInter)
                                .Load();

                            foreach (var j in t.TagsInter)
                            {
                                _context.Entry(j)
                                    .Reference(n => n.Tag)
                                    .Load();
                            }
                        }
                    }

                }

                if (my_location == true || location != null)
                {
                    if (Ranking == null)
                    {
                        Ranking = new Dictionary<int, int>();
                    }

                    foreach (var r in Resturaunts)
                    {

                        if (r.Location != null)
                        {
                            Ranking.Add(r.id, (int)Math.Round(Xamarin.Essentials.Location.CalculateDistance(new Xamarin.Essentials.Location(r.Location.Lang, r.Location.Long), new LocationConverter().Get("2605:a000:ee44:e800::6").Result, DistanceUnits.Miles)));

                        }
                    }
                }


                if (search != null)
                {
                    SearchLine = search.ToLower();
                    if (Ranking == null)
                    {
                        Ranking = new Dictionary<int, int>();
                    }

                    char[] delimiterChars = { ' ', ',', '.', ':', '\t', '\0' };

                    string[] words = SearchLine.Split(delimiterChars);


                    foreach (var r in Resturaunts)
                    {
                        int rank = 0;
                        foreach (var d in r.ResturauntPage.Days[day].Deals)
                        {
                            foreach (var t in d.TagsInter)
                            {
                                if (GetContains(t.Tag.TagName.ToLower(), words)) { rank++; }
                            }

                            if (d.Desription != null)
                            {
                                if (GetContains(d.Desription.ToLower(), words)) { rank++; }
                            }

                            if (d.ItemName != null)
                            {
                                if (GetContains(d.ItemName.ToLower(), words)) { rank++; }
                            }

                        }
                        if (words.Contains(r.Name.ToLower()))
                        {
                            rank++;
                        }


                        if (Ranking.ContainsKey(r.id))
                        {
                            Ranking[r.id] += rank;
                        }
                        else
                        {
                            Ranking.Add(r.id, rank);
                        }

                        

                        
                    }
                }
                
            }
            else
            {
               
            }

            if(Ranking != null)
            {
                Locations = new List<Models.Location>();
                foreach (var i in Ranking.Keys)
                {
                    
                    Locations.Add(_context.Location.FirstOrDefault(n => n.ResturauntId == i));
                }
            }


            return Page();
        }
        public void OnGetSearch(String search)
        {


        }

        public bool GetContains(String s, String[] words)
        {
            char[] delimiterChars = { ' ', ',', '.', ':', '\t', '\0' };
            bool Answer = false;
            foreach (var w in words)
            {
                foreach (var x in s.Split(delimiterChars))
                {
                    if (w.Contains(x))
                    {
                        return true;
                    }
                }

            }
            return Answer;
        }


    }
}