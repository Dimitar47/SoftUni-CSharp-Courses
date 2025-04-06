namespace CinemaApp.Data.Models
{
    public class Movie
    {
        public Movie()
        {
            this.Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }

        public string Title { get; set; } = null!;

        public string Genre { get; set; } = null!;

        public DateTime ReleaseDate { get; set; }

        public string Director { get; set; } = null!;

        public int Duration { get; set; }

        public string Description { get; set; } = null!;


    }
}
