namespace CinemaWebApp.Models
{
    public class CinemaMovie
    {
        public int CinemaId { get; set; }
        public Cinema Cinema { get; set; } = null!;

        public int MovieId { get; set; }
        public Movie Movie { get; set; } = null!;
    }
}
