namespace CinemaWebApp.ViewModels
{
    public class WatchlistViewModel
    {
        public int MovieId { get; set; }
        public string Title { get; set; } = null!;
        public string Genre { get; set; } = null!;
        public string ReleaseDate { get; set; } = null!;  // Display as "MMMM yyyy"

        public string ImageUrl { get; set; } = null!;
    }
}
