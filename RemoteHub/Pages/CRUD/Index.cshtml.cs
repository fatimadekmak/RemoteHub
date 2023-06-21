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
    public class IndexModel : PageModel
    {
        private readonly RemoteHub.Data.AppDBContext _context;

        public IndexModel(RemoteHub.Data.AppDBContext context)
        {
            _context = context;
        }

        public IList<Models.Resume> Resume { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Resumes != null)
            {
                Resume = await _context.Resumes.ToListAsync();
            }
        }
    }
}
