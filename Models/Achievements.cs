using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace StudentsClubs.Models
{
    public class Achievements
    {
        [Key]
        public int AchievementId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        [DisplayName("Club Name")]
        public string ClubName { get; set; }
        public string? Images { get; set; }
        public string? Videos { get; set; }
    }
}
