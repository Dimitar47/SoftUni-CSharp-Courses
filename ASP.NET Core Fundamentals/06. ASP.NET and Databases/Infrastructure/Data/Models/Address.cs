using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infrastructure.Data.Models
{
    [ComplexType]
    public class Address
    {
        [Required]
        [MaxLength(100)]
        [Comment("The first line of the address.")]
        public required string Line1 { get; init; }

        [MaxLength(100)]
        [Comment("The second line of the address.")]
        public string? Line2 { get; init; }

        [Required]
        [MaxLength(50)]
        [Comment("The city of the address.")]
        public required string City { get; init; }

        [Required]
        [MaxLength(50)]
        [Comment("The country of the address.")]
        public required string Country { get; init;  }

        [Required]
        [MaxLength(10)]
        [Comment("The post code of the address.")]
        public required string PostCode { get; init; } 
    }
}
