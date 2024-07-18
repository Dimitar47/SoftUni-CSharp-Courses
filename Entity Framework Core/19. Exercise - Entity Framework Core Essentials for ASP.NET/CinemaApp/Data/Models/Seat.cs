using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CinemaApp.Data.Models
{
    public class Seat
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int HallId { get; set; }

        [Required]
        public int Row { get; set; }

        [Required]
        public int Number { get; set; }

        [ForeignKey(nameof(HallId))]
        public Hall Hall { get; set; } = null!;

        public List<Ticket> Tickets { get; set; } = new List<Ticket>();
    }
}
