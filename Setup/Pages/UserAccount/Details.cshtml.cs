using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Setup.Data;
using Setup.Models;

namespace Setup.Pages.UserAccount
{
    public class DetailsModel : PageModel
    {
        private readonly Setup.Data.SetupContext _context;

        public DetailsModel(Setup.Data.SetupContext context)
        {
            _context = context;
        }

        public Account Account { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Account = await _context.Account.FirstOrDefaultAsync(m => m.AccountID == id);

            if (Account == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
