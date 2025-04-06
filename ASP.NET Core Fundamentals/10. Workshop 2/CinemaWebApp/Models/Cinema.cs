using System.ComponentModel.DataAnnotations;

namespace CinemaWebApp.Models
{
    public class Cinema
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = null!;

        [Required]
        public string Location { get; set; } = null!;

        public ICollection<CinemaMovie> CinemaMovies { get; set; } = new List<CinemaMovie>();
    }
}
