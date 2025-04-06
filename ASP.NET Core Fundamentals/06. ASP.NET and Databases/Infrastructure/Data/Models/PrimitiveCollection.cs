using Infrastructure.Data.Configurations;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Infrastructure.Data.Models
{
    [EntityTypeConfiguration(typeof(PrimitiveCollectionConfiguration))]
    [Comment("Collections of primitive types.")]
    public class PrimitiveCollection
    {
        [Key]
        [Comment("The unique identifier for the table.")]
        public int Id { get; set; }

        [Required]
        [Comment("Collection of integers.")]
        public required IList<int> Ints { get; set; }

        [Required]
        [Comment("Collection of strings.")]
        public required IList<string> Strings { get; set; }

        [Required]
        [Comment("Collection of timestamps.")]
        public required IList<DateTime> DateTimes { get; set; }

        [Required]
        [Comment("Collection of dates.")]
        public required IList<DateOnly> Dates { get; set; }
    }
}
