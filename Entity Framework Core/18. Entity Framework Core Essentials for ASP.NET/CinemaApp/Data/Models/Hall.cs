using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CinemaApp.Data.Models
{
    public class Hall
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; } = null!;

        [Required]
        public int CinemaId { get; set; }

        [ForeignKey(nameof(CinemaId))]
        public Cinema Cinema { get; set; } = null!;

        public List<Seat> Seats { get; set; } = new List<Seat>();

        public List<Schedule> Schedules { get; set; } = new List<Schedule>();
    }
}
