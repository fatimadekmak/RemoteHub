using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RemoteHub.Data;
using RemoteHub.Models;

namespace RemoteHub.Pages.CRUD
{
    public class EditModel : PageModel
    {
        private readonly RemoteHub.Data.AppDBContext _context;

        public EditModel(RemoteHub.Data.AppDBContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Models.Resume Resume { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Resumes == null)
            {
                return NotFound();
            }

            var resume =  await _context.Resumes.FirstOrDefaultAsync(m => m.ResumeId == id);
            if (resume == null)
            {
                return NotFound();
            }
            Resume = resume;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Resume).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ResumeExists(Resume.ResumeId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool ResumeExists(int id)
        {
          return (_context.Resumes?.Any(e => e.ResumeId == id)).GetValueOrDefault();
        }
    }
}
