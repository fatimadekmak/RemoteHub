using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RemoteHub.Data;
using RemoteHub.Models;

namespace RemoteHub.Pages.CRUD
{
    public class DeleteModel : PageModel
    {
        private readonly RemoteHub.Data.AppDBContext _context;

        public DeleteModel(RemoteHub.Data.AppDBContext context)
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

            var resume = await _context.Resumes.FirstOrDefaultAsync(m => m.ResumeId == id);

            if (resume == null)
            {
                return NotFound();
            }
            else 
            {
                Resume = resume;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Resumes == null)
            {
                return NotFound();
            }
            var resume = await _context.Resumes.FindAsync(id);

            if (resume != null)
            {
                Resume = resume;
                _context.Resumes.Remove(Resume);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
