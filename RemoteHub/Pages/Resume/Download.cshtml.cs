using Microsoft.AspNetCore.Mvc.RazorPages;
using RemoteHub.Data;
using Spire.Pdf.Graphics;
using Spire.Pdf;
using System.Drawing;
using Microsoft.EntityFrameworkCore;

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