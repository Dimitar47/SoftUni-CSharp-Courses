namespace SeminarHub.Models
{
    public class JoinedViewModel
    {
        public int Id { get; set; }

        public required string Topic { get; set; }

        public required string Lecturer { get; set; }

        public required string DateAndTime { get; set; }

        public required string Organizer { get; set; }
    }
}
