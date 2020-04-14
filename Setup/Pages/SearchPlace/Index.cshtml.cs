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
        public PaginatedList<Place> Place { get; set; }
        public IList<Photo> Photo { get; set; }
        public string NameSort { get; set; }
        public string CurrentSort { get; set; }
        public string CurrentFilter { get; set; }


        public async Task OnGetAsync(string sortOrder, string currentFilter, string searchString, int? pageIndex)
        {
            CurrentSort = sortOrder;

            NameSort = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            if (searchString != null)
            {
                pageIndex = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            CurrentFilter = searchString;

            IQueryable<Place> PlaceIQ = from s in _context.Place
                                        select s;

            if (!String.IsNullOrEmpty(searchString))
            {
                PlaceIQ = PlaceIQ.Where(s => s.PlaceName.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "name_desc":
                    PlaceIQ = PlaceIQ.OrderByDescending(s => s.PlaceName);
                    break;

                default:
                    PlaceIQ = PlaceIQ.OrderBy(s => s.Address);
                    break;
            }
            int pageSize = 3;
            Place = await PaginatedList<Place>.CreateAsync(
                PlaceIQ.AsNoTracking(), pageIndex ?? 1, pageSize);

        }
    }
}