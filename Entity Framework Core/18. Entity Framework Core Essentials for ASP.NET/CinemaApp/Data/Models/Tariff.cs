using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CinemaApp.Data.Models
{
    public class Tariff
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; } = null!;

        [Required]
        public int FilmId { get; set; }

        [Required]
        [Column(TypeName = "money")]
        public decimal Price { get; set; }

        [ForeignKey(nameof(FilmId))]
        public Film Film { get; set; } = null!;

        public List<Ticket> Tickets { get; set; } = new List<Ticket>();
    }
}
