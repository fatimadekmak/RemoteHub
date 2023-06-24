using Microsoft.AspNetCore.Mvc.RazorPages;
using RemoteHub.Data;
using Microsoft.EntityFrameworkCore;
using RemoteHub.Services;
using Azure;
using Microsoft.AspNetCore.Mvc;
using RemoteHub.Models;
using NuGet.Protocol.Core.Types;


namespace RemoteHub.Pages.Resume
{
    public class DownloadModel : PageModel
    {
        private readonly DBRepository _repository;
        private readonly GeneratePdfService _generatepdf;
        public DownloadModel(DBRepository repository, GeneratePdfService generatePdfService)
        {
            _repository = repository;
            _generatepdf = generatePdfService;
        }
        public Models.Resume resume { get; set; }
        public async Task<IActionResult> OnGetAsync(int id)
        {
            resume = _repository.GetResumeWithSkillsById(id);
            string fileName = "" + resume.FirstName + resume.LastName + resume.ResumeId + "_Resume.pdf";
            string filePath = "wwwroot/resumes/" + fileName;

            // generate pdf
            _generatepdf.GeneratePdf(resume,filePath);

            // download file
            byte[] fileBytes = System.IO.File.ReadAllBytes(filePath);
            return File(fileBytes, "application/pdf", fileName);
        }
    }
}

