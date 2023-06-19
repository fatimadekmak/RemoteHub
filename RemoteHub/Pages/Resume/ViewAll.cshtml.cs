using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RemoteHub.Data;

namespace RemoteHub.Pages.Resume
{
    public class ViewAllModel : PageModel
    {
        private readonly AppDBContext _context;

        public ViewAllModel(AppDBContext context)
        {
            _context = context;
        }
        public IList<Models.Resume> Resumes { get; set; } = default!;
        public async Task OnGet()
        {
            if (_context.Resumes != null)
            {
                Resumes = await _context.Resumes.ToListAsync();
            }
        }
    }
}
