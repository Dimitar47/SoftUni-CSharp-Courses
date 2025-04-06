namespace SeminarHub.Models
{
    public class DetailsViewModel
    {
        public int Id { get; set; }

        public required string Topic { get; set; }

        public required string DateAndTime { get; set; }

        public int Duration { get; set; }

        public required string Lecturer { get; set; }

        public required string Category { get; set; }

        public required string Details { get; set; }

        public required string Organizer { get; set; }
    }
}
