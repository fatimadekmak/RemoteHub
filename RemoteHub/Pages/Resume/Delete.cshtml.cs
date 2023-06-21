using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RemoteHub.Data;
using RemoteHub.Models;

namespace RemoteHub.Pages.Resume
{
    public class DeleteModel : PageModel
    {
        private readonly AppDBContext _context;
        public DeleteModel(AppDBContext context)
        {
            _context = context;
        }
        [BindProperty]
        public Models.Resume Resume { get; set; }
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if(id==null || _context.Resumes == null)
            {
                return NotFound();
            }
            Resume = await _context.Resumes.SingleOrDefaultAsync(r => r.ResumeId == id);
            if(Resume == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (Resume.ResumeId == null || _context.Resumes == null)
            {
                return NotFound();
            }
            Resume = await _context.Resumes.FindAsync(Resume.ResumeId);

            if(Resume!=null)
            {
                _context.Resumes.Remove(Resume);
                await _context.SaveChangesAsync();
                TempData["DeleteAlertMessage"] = "Resume was successfully deleted.";
            }
            return RedirectToPage("/Index");
        }
    }
}
