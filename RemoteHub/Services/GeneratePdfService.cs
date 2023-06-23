using iTextSharp.text.pdf;
using iTextSharp.text;
using RemoteHub.Models;
using Microsoft.IdentityModel.Tokens;
using Azure;

namespace RemoteHub.Services
{
    public class GeneratePdfService
    {
        private Resume _resume { get; set; }
        private Document doc { get; set; }
        private string filePath { get; set; }
        public GeneratePdfService() 
        { 
            
        }

        public void GeneratePdf(Resume resume, string path)
        {
            _resume = resume;
            string filePath = path;
            if (File.Exists(filePath))
            {
                // Delete the existing file
                File.Delete(filePath);
            }
            doc = new Document();

            // Set up a PDF writer to write the document to a file
            PdfWriter writer = PdfWriter.GetInstance(doc, new FileStream(filePath, FileMode.Create));

            // Open the PDF document for writing
            doc.Open();

            AddHeading();
            if(_resume.ProfilePicUrl!= null)
            {
                AddImage();
            }
            AddBody();
            AddSkills();

            // Close the PDF document
            doc.Close();
        }
        public void AddHeading()
        {
            // Add a paragraph with a heading
            Paragraph heading = new Paragraph(_resume.FirstName + " " + _resume.LastName, new Font(Font.FontFamily.HELVETICA, 22, Font.BOLD, BaseColor.DARK_GRAY));
            heading.Alignment = Element.ALIGN_CENTER;

            // Add spacing before and after the heading
            heading.SpacingBefore = 20f;
            heading.SpacingAfter = 20f;

            // Add the heading to the document
            doc.Add(heading);
        }

        public void AddBody()
        {
            if(_resume.BirthDate!=null)
            {
                doc.Add(new Paragraph("Birth Date: "+ _resume.BirthDate?.ToString("yyyy-MM-dd"), new Font(Font.FontFamily.HELVETICA, 10)));
            }
            doc.Add(new Paragraph("Gender: "+_resume.Gender, new Font(Font.FontFamily.HELVETICA, 12)));
            doc.Add(new Paragraph("Nationality: "+_resume.Nationality, new Font(Font.FontFamily.HELVETICA, 12)));
            doc.Add(new Paragraph("Email: "+_resume.Email, new Font(Font.FontFamily.HELVETICA, 12)));
            if(_resume.PhoneNumber!=null)
            {
                doc.Add(new Paragraph("Phone Number: "+_resume.PhoneNumber, new Font(Font.FontFamily.HELVETICA, 10)));
            }
            doc.Add(new Paragraph("Grade " + _resume.grade, new Font(Font.FontFamily.HELVETICA, 12, Font.BOLD, BaseColor.GREEN)));
        }

        public void AddImage()
        {
            Image image = Image.GetInstance("wwwroot/"+_resume.ProfilePicUrl);
            image.Alignment = Image.ALIGN_CENTER;
            image.ScaleToFit(150f, 150f); 

            // Add the image to the document
            doc.Add(image);
        }

        public void AddSkills()
        {
            doc.Add(new Paragraph("Skills:", new Font(Font.FontFamily.HELVETICA, 12, Font.BOLD, BaseColor.DARK_GRAY)));
            if (_resume.skills.IsNullOrEmpty())
            {
                Paragraph p = new Paragraph("None.");
                p.IndentationLeft = 20f;
                doc.Add(p) ;
            }
            // Add bullet points for each skill
            List unorderedList = new List(List.UNORDERED);
            unorderedList.SetListSymbol("\u2022"); 
            unorderedList.IndentationLeft = 20f; 
            foreach(var skill in _resume.skills)
            {
                unorderedList.Add(new ListItem(skill.SkillName, new Font(Font.FontFamily.HELVETICA, 10)));
            }

            doc.Add(unorderedList);

        }

    }
}
