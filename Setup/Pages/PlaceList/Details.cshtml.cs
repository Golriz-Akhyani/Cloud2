using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Setup.Data;
using Setup.Models;

namespace Setup.Pages.PlaceList
{
    public class DetailsModel : PageModel
    {
        private readonly Setup.Data.SetupContext _context;

        public DetailsModel(Setup.Data.SetupContext context)
        {
            _context = context;
        }

        public Place Place { get; set; }

        public IList<Photo> Photo { get; set;}

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Place = await _context.Place.FirstOrDefaultAsync(m => m.PlaceID == id);

            if (Place == null)
            {
                return NotFound();
            }

            Photo = await _context.Photo.Where(p => p.PlaceID == id).AsNoTracking().ToListAsync();

            return Page();
        }
    }
}
