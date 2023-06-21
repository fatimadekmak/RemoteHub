using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace RemoteHub.Models
{
    public class ResumeBindingModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? Birthday { get; set; }
        public string Gender { get; set; }
        public String Nationality { get; set; }
        public List<bool> Skills { get; set; }
        public string Email { get; set; }
        public string EmailConfirmation { get; set; }
        public string? PhoneNumber { get; set; }
        public int Number1 { get; set; }
        public int Number2 { get; set; }
        public int Number3 { get; set; }
        public IFormFile? ProfileImage { get; set; }
    }
}
