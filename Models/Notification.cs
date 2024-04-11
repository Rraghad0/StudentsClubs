namespace StudentsClubs.Models
{
    public class Notification
    {
        public int NotificationId { get; set; }
        public string Message { get; set; }
        public DateTime NotificationDate { get; set; }
        public bool IsRead { get; set; } = false;
        public string? Description { get; set; }
        public int EventId { get; set; }
    }
}
