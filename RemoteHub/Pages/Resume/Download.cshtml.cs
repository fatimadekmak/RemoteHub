using Microsoft.AspNetCore.Mvc.RazorPages;
using RemoteHub.Data;

namespace RemoteHub.Pages.Resume
{
    public class DownloadModel : PageModel
    {
        private readonly AppDBContext _context;
        public DownloadModel(AppDBContext context)
        {
            _context = context;
        }
        public Models.Resume resume { get; set; }
        public async Task OnGetAsync(int id)
        {
            
        }
    }
}
