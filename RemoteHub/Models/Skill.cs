namespace RemoteHub.Models
{
    public class Skill
    {
        public int SkillId { get; set; }
        public string SkillName { get; set; }
        public ICollection<Resume>? resumes { get; set; }
    }
}
