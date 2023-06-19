using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RemoteHub.Data;
using RemoteHub.Models;
using RemoteHub.Services;
using System.ComponentModel.DataAnnotations;

namespace RemoteHub.Pages.Resume
{
    public class EditModel : PageModel
    {
        private readonly AppDBContext _context;
        public List<Models.Skill> AllSkills { get; set; }

        public EditModel(AppDBContext context)
        {
            _context = context;
            AllSkills = _context.Skills.ToList();
        }

        
        [BindProperty]
        public EditViewModel viewModel { get; set; }
        public Models.Resume Resume { get; set; } = default!;
        public ICollection<Models.Skill> SelectedSkills { get; set; }
        public static string oldImage { get; set; }

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

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Resumes == null)
            {
                return NotFound();
            }

            var resume = await _context.Resumes.Include(r => r.skills).FirstOrDefaultAsync(m => m.ResumeId == id);
            if (resume == null)
            {
                return NotFound();
            }
            Resume = resume;
            oldImage = Resume.ProfilePicUrl;
            SelectedSkills = Resume.skills;
            viewModel = new EditViewModel
            {
                /*ResumeId = Resume.ResumeId,*/
                FirstName = Resume.FirstName,
                LastName = Resume.LastName,
                BirthDate = Resume.BirthDate,
                Gender = Resume.Gender,
                Nationality = Resume.Nationality,
                Email = Resume.Email,
                PhoneNumber = Resume.PhoneNumber
            };
            viewModel.Skills = new List<bool>();
            foreach(var skill in AllSkills)
            {
                if(SelectedSkills.Contains(skill))
                {
                    viewModel.Skills.Add(true);
                }
                else
                {
                    viewModel.Skills.Add(false);
                }
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (viewModel.ProfileImage != null && ImageUploadService.CheckExtensionValidity(viewModel.ProfileImage) == false)
            {
                ModelState.AddModelError("viewModel.ProfileImage", "Please choose a valid image file.");
            }
            if (DateService.checkIfPastDate(viewModel.BirthDate))
            {
                ModelState.AddModelError("viewModel.BirthDate", "Choose a date in the past");
            }
            if (DateService.checkMinimumAge(viewModel.BirthDate))
            {
                ModelState.AddModelError("viewModel.BirthDate", "You should be at least 14 years old");
            }
            if (!ModelState.IsValid)
            {
                /*foreach (var modelStateEntry in ModelState)
                {
                    string key = modelStateEntry.Key; // Field/property name
                    var errors = modelStateEntry.Value.Errors; // Collection of errors for the field/property

                    foreach (var error in errors)
                    {
                        string errorMessage = error.ErrorMessage; // Error message
                        Console.WriteLine($"Error in {key}: {errorMessage}");
                    }
                }*/
                return Page();
            }
            Resume = new Models.Resume
            {
                /*ResumeId = viewModel.ResumeId,*/
                FirstName = viewModel.FirstName,
                LastName = viewModel.LastName,
                BirthDate = viewModel.BirthDate,
                Gender = viewModel.Gender,
                Nationality = viewModel.Nationality,
                Email = viewModel.Email,
                PhoneNumber = viewModel.PhoneNumber,
                skills = new List<Skill>()
        };
            if(viewModel.ProfileImage!=null)
            {
                Resume.ProfilePicUrl = ImageUploadService.UploadFile(viewModel.ProfileImage);
            }
            else
            {
                Resume.ProfilePicUrl = oldImage;
            }
            for (int i = 0; i < viewModel.Skills.Count; i++)
            {
                if (viewModel.Skills[i] == true)
                {
                    //need to save the corresponding skill[i] as a skill
                    Resume.skills.Add(AllSkills[i]);
                }
            }
            _context.Resumes.Add(Resume);
            await _context.SaveChangesAsync();
            
            return RedirectToPage("view", new { Id = Resume.ResumeId });
        }
    }
    public class EditViewModel
    {
        public int ResumeId { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [DataType(DataType.Date)]
        public DateTime? BirthDate { get; set; }
        public string Gender { get; set; }
        public string Nationality { get; set; }
        public IFormFile? ProfileImage { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        public string? PhoneNumber { get; set; }
        public List<bool> Skills { get; set; }
    }
}
