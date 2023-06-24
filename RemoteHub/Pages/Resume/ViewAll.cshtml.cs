using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RemoteHub.Data;
using RemoteHub.Services;

namespace RemoteHub.Pages.Resume
{
    public class ViewAllModel : PageModel
    {
        private readonly DBRepository _repository;
        public ViewAllModel(DBRepository repository)
        {
            _repository = repository;
        }
        
        public IList<Models.Resume> Resumes { get; set; } = default!;
        public async Task OnGet()
        { 
            Resumes = _repository.GetAllResumes();
        }
    }
}
