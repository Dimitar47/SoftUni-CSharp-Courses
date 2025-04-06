namespace SeminarHub.Models
{
    public class SeminarDetailsViewModel
    {
        public int Id { get; set; }

        public string Topic { get; set; } = null!;

        public string OrganizerId { get; set; } = null!;

        public string Organizer { get; set; } = null!;

        public string Lecturer { get; set; } = null!;

        public string Details { get; set; } = null!;

        public string Category { get; set; } = null!;

        public string DateAndTime { get; set; } = null!;

        public int Duration { get; set; }
    }
}
