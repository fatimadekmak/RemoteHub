using Microsoft.AspNetCore.Mvc.RazorPages;
using RemoteHub.Data;
using Microsoft.EntityFrameworkCore;
using RemoteHub.Services;

namespace RemoteHub.Pages.Resume
{
    public class DownloadModel : PageModel
    {
        private readonly AppDBContext _context; 
        private readonly GeneratePdfService _generatepdf;
        public DownloadModel(AppDBContext context, GeneratePdfService generatePdfService)
        {
            _context = context;
            _generatepdf = generatePdfService;
        }
        public Models.Resume resume { get; set; }
        public async Task OnGetAsync(int id)
        {
            resume = await _context.Resumes.Include(r => r.skills).SingleOrDefaultAsync(r => r.ResumeId == id);
            _generatepdf.GeneratePdf(resume);
        }
    }
}