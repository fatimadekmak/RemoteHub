using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RemoteHub.Models;
using RemoteHub.Services;

namespace RemoteHub.Pages.Resume
{
    public class RedirectionPageModel : PageModel
    {
        [BindProperty(SupportsGet =true)]
        public Models.Resume bindingModel { get; set; }
        [BindProperty(SupportsGet = true)]
        public List<bool> SkillsCheckboxes { get; set; }
        public List<Skill> AllSkills { get; set; }

        public readonly DBRepository _repository;
        public RedirectionPageModel(DBRepository repository)
        {
            _repository = repository;
        }


        public async Task<IActionResult> OnGetAsync()
        {
            AllSkills = _repository.GetAllSkills();
            var increment = 0;
            if (bindingModel.Gender.Equals("Female"))
            {
                increment = 10;
            }
            else
            {
                increment = 5;
            }
            bindingModel.skills = new List<Skill>();
            bindingModel.grade = 0;
            for (int i = 0; i < SkillsCheckboxes.Count; i++)
            {
                if (SkillsCheckboxes[i] == true)
                {
                    //need to save the corresponding AllSkills[i] as a skill in skills list
                    bindingModel.skills.Add(AllSkills[i]);
                    bindingModel.grade += increment;
                }
            }
            await _repository.AddResume(bindingModel);

            @TempData["NewAlertMessage"] = "Your resume was successfully created.";

            return RedirectToPage("view", new { Id = bindingModel.ResumeId }); 
        }
    }
}
