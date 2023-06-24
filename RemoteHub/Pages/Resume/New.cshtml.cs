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
        private readonly DBRepository _repository;
        public List<Skill> Skills { get; set; }
        public NewModel(DBRepository repository)
        {
            _repository = repository;
            Skills = _repository.GetAllSkills();
        }
        [BindProperty(Name = "viewModel")]
        public ResumeBindingModel bindingModel { get; set; }
        public ResumeViewModel viewModel { get; set; }


        public IEnumerable<SelectListItem> Items { get; set; } = new List<SelectListItem>()
        {
            new SelectListItem { Value = "Lebanese", Text = "Lebanese" },
            new SelectListItem { Value = "Palestinian", Text = "Palestinian" },
            new SelectListItem { Value = "Syrian", Text = "Syrian" },
            new SelectListItem { Value = "Egyptian", Text = "Egyptian" },
            new SelectListItem { Value = "Jordanian", Text = "Jordanian" },
            new SelectListItem { Value = "American", Text = "American" },
            new SelectListItem { Value = "Canadian", Text = "Canadian" },
            new SelectListItem { Value = "British", Text = "British" },
            new SelectListItem { Value = "German", Text = "German" },
            new SelectListItem { Value = "French", Text = "French" },
            new SelectListItem { Value = "Australian", Text = "Australian" },
            new SelectListItem { Value = "Chinese", Text = "Chinese" },
            new SelectListItem { Value = "Indian", Text = "Indian" },
            new SelectListItem { Value = "Brazilian", Text = "Brazilian" },
            new SelectListItem { Value = "Russian", Text = "Russian" }
        };

        public string[] Genders = new[] { "Male", "Female" };
        
        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost()
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
                skills = new List<Skill>(),
                grade = 0
            };
            var increment = 0;
            if(bindingModel.Gender.Equals("Female"))
            {
                increment = 10;
            }
            else
            {
                increment = 5;
            }
            for (int i =0; i< bindingModel.Skills.Count;i++)
            {
                if (bindingModel.Skills[i]==true)
                {
                    //need to save the corresponding skill[i] as a skill
                    resume.skills.Add(Skills[i]);
                    resume.grade += increment;
                }
            }

            await _repository.AddResume(resume);

            @TempData["NewAlertMessage"] = "Your resume was successfully created.";

            return RedirectToPage("view", new { Id = resume.ResumeId } );
        }
    }
    
}
