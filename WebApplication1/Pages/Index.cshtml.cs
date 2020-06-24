using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using static Microsoft.Azure.Amqp.Serialization.SerializableType;

namespace WebApplication1.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        private readonly Data.WebApplication1Context _context;

        public List<Models.Resturaunt> Resturaunts;
        public List<Models.Deal> Deals;
        public List<Models.Location> Locations;
        public List<Models.Tags> Tags;
        public Dictionary<int, int> Ranking;
        public String SearchLine { get; set; }

        public IndexModel(ILogger<IndexModel> logger, Data.WebApplication1Context context)
        {
            _logger = logger;
            _context = context;
        }

        public PageResult OnGet(String ?search)
        {

            Resturaunts = _context.Resturaunt.Include(m => m.ResturauntPage).ThenInclude(n => n.Days).ToList();
            Locations = _context.Location.ToList();
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

            if(search != null)
            {
                SearchLine = search.ToLower();
                Ranking = new Dictionary<int, int>();

                char[] delimiterChars = { ' ', ',', '.', ':', '\t', '\0' };

                string[] words = SearchLine.Split(delimiterChars);


                foreach (var r in Resturaunts)
                {
                    int rank = 0;
                    foreach (var d in r.ResturauntPage.Days[TimeManagement.GetDay()].Deals)
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

                    Ranking.Add(r.id, rank);

                }

                Ranking.OrderByDescending(n => n.Value);
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
            foreach(var w in words)
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
