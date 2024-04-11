using System;
using System.ComponentModel.DataAnnotations;

namespace StudentsClubs.Models
{
    public class Events
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Title { get; set; }

        [StringLength(500)]
        public string? Description { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime EventDate { get; set; }
        public bool IsViewed { get; set; } = false;
    }
}
