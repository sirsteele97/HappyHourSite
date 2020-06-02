using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApplication1.Models;

namespace WebApplication1
{
    public class _EditDealModel : PageModel
    {


        private readonly WebApplication1.Data.WebApplication1Context _context;

        public _EditDealModel(Deal Deal)
        {
            this.Deal = Deal;
        }

        public Resturaunt Resturaunt;

        [BindProperty]
        public Deal Deal { get; set; }

        public void OnGet()
        {

        }
    }
}