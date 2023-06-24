using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RemoteHub.Data;
using RemoteHub.Models;

namespace RemoteHub.Services
{
    public class Repository
    {
        private readonly AppDBContext _context;
        public Repository(AppDBContext context)
        {
            _context = context;
        }

        public List<Skill> GetAllSkills()
        {
            return _context.Skills.ToList();
        }

        public List<Resume> GetAllResumes()
        {
            return _context.Resumes.ToList();
        }

        public async Task AddResume(Resume resume)
        {
            _context.Resumes.Add(resume);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateResume(Resume resume)
        {
            await _context.SaveChangesAsync();
        }

        public Resume GetResumeWithSkillsById(int id)
        {
            return _context.Resumes.Include(r => r.skills).FirstOrDefault(m => m.ResumeId == id);
        }

        public Resume GetResumeById(int id)
        {
            return _context.Resumes.FirstOrDefault(m => m.ResumeId == id);
        }

        public async Task DeleteResume(int id)
        {
            var resume = GetResumeById(id);

            if (resume != null)
            {
                _context.Resumes.Remove(resume);
                await _context.SaveChangesAsync();
            }
        }

    }
}
