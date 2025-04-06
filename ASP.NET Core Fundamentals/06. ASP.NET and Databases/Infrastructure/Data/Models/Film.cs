using Infrastructure.Data.Configurations;
using Infrastructure.Data.Models.Contracts;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Infrastructure.Data.Models
{
    [Comment("A film.")]
    [EntityTypeConfiguration(typeof(FilmConfiguration))]
    public class Film : ISoftDeletable
    {
        [Key]
        [Comment("The unique identifier for the film.")]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        [Comment("The title of the film.")]
        public required string Title { get; set; }

        [Required]
        [Comment("The duration of the film.")]
        public int Duration { get; set; }

        [Required]
        [Comment("The year of the film.")]
        public int Year { get; set; }

        [Required]
        public bool IsActive { get; set; } = true;

        public DateTime? DeletedAt { get; set; }
    }
}
