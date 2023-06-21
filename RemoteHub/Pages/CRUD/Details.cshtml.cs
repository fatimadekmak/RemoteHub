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
    public class DetailsModel : PageModel
    {
        private readonly RemoteHub.Data.AppDBContext _context;

        public DetailsModel(RemoteHub.Data.AppDBContext context)
        {
            _context = context;
        }

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
    }
}
