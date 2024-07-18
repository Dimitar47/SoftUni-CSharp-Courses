using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CinemaApp.Data.Models
{
    public class Ticket
    {
        [Key]
        public int Id { get; set; }

        [StringLength(100)]
        public string? CustomerName { get; set; }

        [Required]
        public int SeatId { get; set; }

        [Required]
        public int ScheduleId { get; set; }

        [Required]
        public int TariffId { get; set; }

        [ForeignKey(nameof(SeatId))]
        public Seat Seat { get; set; } = null!;

        [ForeignKey(nameof(ScheduleId))]
        public Schedule Schedule { get; set; } = null!;

        [ForeignKey(nameof(TariffId))]
        public Tariff Tariff { get; set; } = null!;
    }
}
