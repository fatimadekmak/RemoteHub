using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RemoteHub.Models;

namespace RemoteHub.Pages.Resume
{
    public class ViewModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public ResumeBindingModel bindingModel { get; set; }
        public async void OnGet()
        {
            /*bindingModel.ProfileImagePath = (string)TempData["imagePath"];*/
        }

        public void OnPost() { }
    
    
    }
}
