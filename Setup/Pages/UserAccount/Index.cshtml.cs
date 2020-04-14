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
    public class IndexModel : PageModel
    {
        private readonly Setup.Data.SetupContext _context;

        public IndexModel(Setup.Data.SetupContext context)
        {
            _context = context;
        }

        public PaginatedList<Account> Account { get;set; }


        public string NameSort { get; set; }
        public string DateSort { get; set; }
        public string CurrentFilter { get; set; }
        public string CurrentSort { get; set; }


        public async Task OnGetAsync(string sortOrder,
             string currentFilter, string searchString, int? pageIndex)
        {
            CurrentSort = sortOrder;

            NameSort = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            DateSort = sortOrder == "Date" ? "date_desc" : "Date";

            if (searchString != null)
            {
                pageIndex = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            IQueryable<Account> AccountIQ = from s in _context.Account select s;
            switch (sortOrder)
            {
                case "name_desc":
                    AccountIQ = AccountIQ.OrderByDescending(s => s.LastName);
                    break;
                case "Date":
                    AccountIQ = AccountIQ.OrderBy(s => s.FirstName);
                    break;
                case "date_desc":
                    AccountIQ = AccountIQ.OrderByDescending(s => s.UserName);
                    break;
                default:
                    AccountIQ = AccountIQ.OrderBy(s => s.UserName);
                    break;
            }

            CurrentFilter = searchString;
            if (!String.IsNullOrEmpty(searchString))
            {
                AccountIQ = AccountIQ.Where(k => k.UserName.Contains(searchString));
            }

            int pageSize = 5;

            Account = await PaginatedList<Account>.CreateAsync(
                AccountIQ.AsNoTracking()
                , pageIndex ?? 1, pageSize);
        }
    }
}
