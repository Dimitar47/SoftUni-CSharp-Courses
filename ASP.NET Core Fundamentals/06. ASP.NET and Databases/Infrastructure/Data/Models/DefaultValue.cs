using Infrastructure.Data.Configurations;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Infrastructure.Data.Models
{
    [Comment("Default value.")]
    [EntityTypeConfiguration(typeof(DefaultValueConfiguration))]
    public class DefaultValue
    {
        [Key]
        [Comment("The unique identifier for the table.")]
        public int Id { get; set; }

        [Required]
        [Comment("The default value for the integer with custom sentinel")]
        public int CreditsWithSentinel { get; set; }

        [Required]
        [Comment("The default value for the integer.")]
        public int CreditsWithoutSentinel { get; set; }

        [Required]
        [Comment("The default value for the bool true.")]
        public bool IsActiveDefaultTrue { get; set; }

        [Required]
        [Comment("The default value for the bool false.")]
        public bool IsActiveDefaultFalse { get; set; }
    }
}
