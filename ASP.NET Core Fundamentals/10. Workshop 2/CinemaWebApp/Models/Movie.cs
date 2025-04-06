namespace CinemaWebApp.Models
{
    public class Movie
    {
        public int Id { get; set; }

        public string Title { get; set; } = null!;

        public string Genre { get; set; } = null!;

        public DateTime ReleaseDate { get; set; }

        public string Director { get; set; } = null!;

        public int Duration { get; set; }

        public string Description { get; set; } = null!;

        public string ImageUrl { get; set; } = null!;

        public ICollection<CinemaMovie> CinemaMovies { get; set; } = new List<CinemaMovie>();
    }
}
