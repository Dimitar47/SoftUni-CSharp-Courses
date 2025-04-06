namespace GameZone.Models
{
    public class GameAllViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; } = string.Empty;

        public string? ImageUrl { get; set; }

        public string Genre { get; set; } = string.Empty;

        public string ReleasedOn { get; set; } = string.Empty;

        public string Publisher { get; set; } = string.Empty;
    }
}
