using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RemoteHub.Services;

namespace RemoteHub.Pages.Skill
{
    public class NewModel : PageModel
    {
        private readonly DBRepository _repository;
        private static string referer { get; set; }
        public NewModel(DBRepository repository)
        {
            _repository = repository;
        }
        [BindProperty]
        public Models.Skill Skill { get; set; }
        public void OnGet()
        {
            referer = Request.Headers["Referer"].ToString();
        }

        public async Task<IActionResult> OnPost()
        {
            List<Models.Skill> skills = _repository.GetAllSkills();
            foreach (var skill in skills)
            {
                if (Skill.SkillName == skill.SkillName)
                {
                    ModelState.AddModelError("Skill.SkillName", "This skill already exists!");
                    break;
                }
            }
            if (!ModelState.IsValid)
            {
                return Page();
            }
            await _repository.AddSkill(Skill);
            TempData["NewAlertMessage"] = "New Skill was Added!";
            return Redirect(referer);
        }
    }
}
