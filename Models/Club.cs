using System.ComponentModel;

namespace StudentsClubs.Models
{
    public class Club
    {
        public int ClubID { get; set; }
        [DisplayName("Club Name")]
        public string ClubName { get; set; }
        [DisplayName("Club Type")]
        public string ClubType { get; set; }
        public string Description { get; set; }
        public string? LogoURL { get; set; }
        [DisplayName("WhatsApp Group Link")]
        public string? WhatsAppGroupLink { get; set; }
    }
}
