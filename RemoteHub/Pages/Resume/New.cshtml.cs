using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using RemoteHub.Models;

namespace RemoteHub.Pages.Resume
{
    public class NewModel : PageModel
    {
        [BindProperty(Name = "viewModel")]
        public ResumeBindingModel bindingModel { get; set; }
        public ResumeViewModel viewModel { get; set; }
        public IEnumerable<SelectListItem> Items { get; set; } = new List<SelectListItem>()
        {
            new SelectListItem { Value = "Lebanon", Text = "Lebanon" },
            new SelectListItem { Value = "Palestine", Text = "Palestine" },
            new SelectListItem { Value = "Syria", Text = "Syria" },
            new SelectListItem { Value = "Egypt", Text = "Egypt" },
            new SelectListItem { Value = "Jordan", Text = "Jordan" },
            new SelectListItem { Value = "United States", Text = "United States" },
            new SelectListItem { Value = "Canada", Text = "Canada" },
            new SelectListItem { Value = "United Kingdom", Text = "United Kingdom" },
            new SelectListItem { Value = "Germany", Text = "Germany" },
            new SelectListItem { Value = "France", Text = "France" },
            new SelectListItem { Value = "Australia", Text = "Australia" },
            new SelectListItem { Value = "China", Text = "China" },
            new SelectListItem { Value = "India", Text = "India" },
            new SelectListItem { Value = "Brazil", Text = "Brazil" },
            new SelectListItem { Value = "Russia", Text = "Russia" }
        };

        public string[] Genders = new[] { "Male", "Female" };
        public void OnGet()
        {
        }
    }
}
