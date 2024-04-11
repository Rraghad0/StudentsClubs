using System.ComponentModel.DataAnnotations;

namespace StudentsClubs.Models
{
    public class Volunteers
    {
        [Key]
        public int VolunteerId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

    }
}
