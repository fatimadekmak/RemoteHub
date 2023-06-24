using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RemoteHub.Data;
using RemoteHub.Models;
using RemoteHub.Services;

namespace RemoteHub.Pages.Resume
{
    public class ViewModel : PageModel
    {
        private readonly DBRepository _repository;
        public ViewModel(DBRepository repository)
        {
            _repository = repository;
        }

        [BindProperty(SupportsGet =true)]
        public int Id { get; set; }

        public Models.Resume resume { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            resume = _repository.GetResumeWithSkillsById(Id);
            if (resume == null)
            {
                return NotFound();
            }
            return Page();
        }

        public void OnPost() { }
    
    
    }
}
