using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RemoteHub.Data;
using RemoteHub.Models;

namespace RemoteHub.Pages.Resume
{
    public class ViewModel : PageModel
    {
        private readonly AppDBContext _context;

        public ViewModel(AppDBContext context)
        {
            _context = context;
        }

        [BindProperty(SupportsGet =true)]
        public int ResumeId { get; set; }

        public Models.Resume resume { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            resume = await _context.Resumes.FindAsync(ResumeId);
            if(resume == null)
            {
                return NotFound();
            }
            return Page();
        }

        public void OnPost() { }
    
    
    }
}
