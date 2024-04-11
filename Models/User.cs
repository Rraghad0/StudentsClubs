using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace StudentsClubs.Models
{
    public class User : IdentityUser
    {
        public int UserID { get; set; }
        [Required]
        public string? UserFirstName { get; set; }
        public string? UserLastName { get; set; }
        public string? StudentID { get; set; }
        public string? PhoneNumber { get; set; }
        public bool WantsToVolunteer { get; set; }
        public List<string>? HobbiesAndInterests { get; set; }
        public List<Membership> ClubMemberships { get; set; }
    }
}
