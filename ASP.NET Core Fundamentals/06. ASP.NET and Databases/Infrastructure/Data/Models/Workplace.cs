using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infrastructure.Data.Models
{
    [Owned]
    [Comment("A workplace.")]
    public class Workplace
    {
        [Required]
        [Comment("The name of the workplace.")]
        [MaxLength(100)]
        public required string Office { get; set; }

        [Comment("The address of the workplace.")]
        [MaxLength(100)]
        public string? Address { get; set; }

        [Comment("The city of the workplace.")]
        [MaxLength(100)]
        public string? City { get; set; }

        [Comment("The floor of the workplace.")]
        public int? Floor { get; set; }

        [Required]
        [Comment("The room number of the workplace.")]
        public int RoomNumber { get; set; }

        [Required]
        [Comment("The phone numbers of the workplace.")]
        public required string[] Phones { get; set; }
    }
}
