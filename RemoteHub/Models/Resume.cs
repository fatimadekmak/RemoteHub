﻿namespace RemoteHub.Models
{
    public class Resume
    {
        public int ResumeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? BirthDate { get; set; }
        public string Gender { get; set; }
        public string Nationality { get; set; }
        public string? ProfilePicUrl { get; set; }
        public string Email { get; set;}
        public string? PhoneNumber { get; set; }
    }
}
