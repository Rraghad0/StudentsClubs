namespace StudentsClubs.Models
{
    public class Request
    {
        public int RequestID { get; set; }
        public int ClubID { get; set; }
        public int UserID { get; set; }
        public string Status { get; set; }
    }
}
