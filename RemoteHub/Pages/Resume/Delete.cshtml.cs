using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol.Core.Types;
using RemoteHub.Services;

namespace RemoteHub.Pages.Resume
{
    public class DeleteModel : PageModel
    {
        private readonly DBRepository _repository;
        public DeleteModel(DBRepository repository)
        {
            _repository = repository;
        }
        [BindProperty]
        public Models.Resume Resume { get; set; }
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if(id==null)
            {
                return NotFound();
            }
            Resume = _repository.GetResumeById(id);
            if(Resume == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (Resume.ResumeId != null)
            {
                await _repository.DeleteResume(Resume.ResumeId);
                TempData["DeleteAlertMessage"] = "Resume was deleted successfully!";
                return RedirectToPage("ViewAll");
            }
            return NotFound();
        }
    }
}
