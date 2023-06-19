using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using RemoteHub.Data;
using RemoteHub.Models;
using RemoteHub.Services;
using System.ComponentModel.DataAnnotations;

namespace RemoteHub.Pages.Resume
{
    public class NewModel : PageModel
    {
        [BindProperty(Name = "viewModel")]
        public ResumeBindingModel bindingModel { get; set; }
        public ResumeViewModel viewModel { get; set; }

        public AppDBContext _context { get; set; }
        public List<Skill> Skills { get; set; }

        public NewModel(AppDBContext context)
        {
            _context = context;
            Skills = _context.Skills.ToList();
        }
        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if (bindingModel.ProfileImage!=null && ImageUploadService.CheckExtensionValidity(bindingModel.ProfileImage) == false)
            {
                ModelState.AddModelError("viewModel.ProfileImage", "Please choose a valid image file.");
            }
            if(DateService.checkIfPastDate(bindingModel.Birthday))
            {
                ModelState.AddModelError("viewModel.Birthday", "Choose a date in the past");
            }
            if(DateService.checkMinimumAge(bindingModel.Birthday))
            {
                ModelState.AddModelError("viewModel.Birthday", "You should be at least 14 years old");
            }
            if (bindingModel.Number1 + bindingModel.Number2 != bindingModel.Number3)
            {
                ModelState.AddModelError("viewModel.Number3",
                             "Incorrect Calculation");
            }
            if (!ModelState.IsValid)
            {
                return Page();
            }
            var resume = new Models.Resume
            {
                FirstName = bindingModel.FirstName,
                LastName = bindingModel.LastName,
                Email = bindingModel.Email,
                BirthDate = bindingModel.Birthday,
                Gender = bindingModel.Gender,
                Nationality = bindingModel.Nationality,
                PhoneNumber = bindingModel.PhoneNumber,
                ProfilePicUrl = bindingModel.ProfileImage != null ? ImageUploadService.UploadFile(bindingModel.ProfileImage) : null,
                skills = new List<Skill>()
            };
            for (int i =0; i< bindingModel.Skills.Count;i++)
            {
                if (bindingModel.Skills[i]==true)
                {
                    //need to save the corresponding skill[i] as a skill
                    resume.skills.Add(Skills[i]);
                }
            }
            _context.Resumes.Add(resume);
            _context.SaveChanges();
            return RedirectToPage("view", new { Id = resume.ResumeId } );
        }
    }
    
}
