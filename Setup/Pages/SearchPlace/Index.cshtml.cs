using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Setup.Data;
using Setup.Models;

namespace Setup.Pages.SearchPlace
{
    public class IndexModel : PageModel
    {
        private readonly Setup.Data.SetupContext _context;

        public IndexModel(Setup.Data.SetupContext context)
        {
            _context = context;
        }
        public IList<Place> Place { get; set; }
        public string CurrentFilter { get; set; }
        public async Task OnGetAsync(string searchstring)
        {
            IQueryable<Place> placeIQ = from s in _context.Place select s;
            CurrentFilter = searchstring;
            if (!String.IsNullOrEmpty(searchstring))
            {
                placeIQ = placeIQ.Where(s => s.Address.Contains(searchstring));
            }


            Place = await placeIQ
                .AsNoTracking().ToListAsync();
        }
    }
}
