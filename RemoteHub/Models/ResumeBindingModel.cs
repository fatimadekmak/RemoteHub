using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace RemoteHub.Models
{
    public class ResumeBindingModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Birthday { get; set; }
        public string Gender { get; set; }
        public IEnumerable<String> Nationality { get; set; }
        public List<bool> Skills { get; set; }
        /*public bool ASPNET { get; set; }
        public bool Java { get; set; }
        public bool Python { get; set; }
        public bool CPP { get; set; }
        public bool Springboot { get; set; }*/
        public string Email { get; set; }
        public string EmailConfirmation { get; set; }
        public string PhoneNumber { get; set; }
        public int Number1 { get; set; }
        public int Number2 { get; set; }
        public int Number3 { get; set; }
        public IFormFile ProfileImage { get; set; }
    }
}
