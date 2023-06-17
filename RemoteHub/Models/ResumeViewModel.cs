using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace RemoteHub.Models
{
    public class ResumeViewModel
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }

        [BindProperty, DataType(DataType.Date)]
        public DateTime Birthday { get; set; }
        [Required]
        public string Gender { get; set; }
        [Required]
        public IEnumerable<String> Nationality { get; set; }
        public bool ASPNET { get; set; }
        public bool Java { get; set; }
        public bool Python { get; set; }
        public bool CPP { get; set; }
        public bool Springboot { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [Compare("Email")]
        public string EmailConfirmation { get; set; }
        [RegularExpression(@"^\+\d{1,3}\s?\d{8,12}$", ErrorMessage = "Please enter valid phone no.")]
        public string PhoneNumber { get; set; }
        [Required]
        [Range(1,20)]
        [Display(Name = "Enter First Number between 1 and 20")]
        public int Number1 { get; set; }
        [Required]
        [Range(20,50)]
        [Display(Name ="Enter Second Number between 20 and 50")]
        public int Number2 { get; set; }
        [Required]
        public int Number3 { get; set; }
        [Required(ErrorMessage = "Please choose profile image")]
        [Display(Name = "Profile Picture")]
        public IFormFile ProfileImage { get; set; }
    }
}
