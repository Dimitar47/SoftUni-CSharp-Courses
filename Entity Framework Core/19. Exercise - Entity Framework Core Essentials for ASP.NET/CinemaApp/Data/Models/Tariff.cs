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
        //Determines the discount for different groups
        public decimal Factor { get; set; }

        public List<Ticket> Tickets { get; set; } = new List<Ticket>();
    }
}
