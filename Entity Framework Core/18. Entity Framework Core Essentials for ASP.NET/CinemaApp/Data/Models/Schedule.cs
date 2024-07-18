using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CinemaApp.Data.Models
{
    public class Schedule
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int FilmId { get; set; }

        [Required]
        public int HallId { get; set; }

        [Required]
        public DateTime Start { get; set; }

        [Required]
        public DateTime End { get; set; }

        [ForeignKey(nameof(FilmId))]
        public Film Film { get; set; } = null!;

        [ForeignKey(nameof(HallId))]
        public Hall Hall { get; set; } = null!;

        public List<Ticket> Tickets { get; set; } = new List<Ticket>();
    }
}
