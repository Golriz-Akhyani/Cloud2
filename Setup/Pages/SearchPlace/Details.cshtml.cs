﻿using System;
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
    public class DetailsModel : PageModel
    {
        private readonly Setup.Data.SetupContext _context;

        public DetailsModel(Setup.Data.SetupContext context)
        {
            _context = context;
        }


        public IList<Photo> Photo { get; set; }
        public Place Place { get; set; }

     
        /*need help*/
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            this.Photo = await _context.Photo.ToListAsync();
            if (Photo == null)
            {
                return NotFound();
            }
            return Page();
        }    



    }

}

