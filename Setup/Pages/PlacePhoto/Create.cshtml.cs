using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Setup.Data;
using Setup.Models;

namespace Setup.Pages.PlacePhoto
{
    public class CreateModel : PageModel
    {
        private readonly Setup.Data.SetupContext _context;

        public CreateModel(Setup.Data.SetupContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Photo Photo { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Photo.Add(Photo);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}