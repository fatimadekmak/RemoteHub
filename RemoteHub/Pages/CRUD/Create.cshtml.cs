﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using RemoteHub.Data;
using RemoteHub.Models;

namespace RemoteHub.Pages.CRUD
{
    public class CreateModel : PageModel
    {
        private readonly RemoteHub.Data.AppDBContext _context;

        public CreateModel(RemoteHub.Data.AppDBContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Models.Resume Resume { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Resumes == null || Resume == null)
            {
                return Page();
            }

            _context.Resumes.Add(Resume);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
