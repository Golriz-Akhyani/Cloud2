using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Setup.Data;
using Setup.Models;

namespace Setup.Pages.PlacePhoto
{
    public class IndexModel : PageModel
    {
        private readonly Setup.Data.SetupContext _context;

        public IndexModel(Setup.Data.SetupContext context)
        {
            _context = context;
        }

        public IList<Photo> Photo { get;set; }

        public async Task OnGetAsync()
        {
            Photo = await _context.Photo.ToListAsync();
        }

    }
}
