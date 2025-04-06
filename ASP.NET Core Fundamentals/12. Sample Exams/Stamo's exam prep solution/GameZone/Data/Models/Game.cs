using GameZone.Common;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GameZone.Data.Models
{
    public class Game
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(ValidationConstants.GameTitleMaxLength)]
        public string Title { get; set; } = string.Empty;

        [Required]
        [MaxLength(ValidationConstants.GameDescriptionMaxLength)]
        public string Description { get; set; } = string.Empty;

        public string? ImageUrl { get; set; }

        [Required]
        public string PublisherId { get; set; } = string.Empty!;

        [ForeignKey(nameof(PublisherId))]
        public IdentityUser Publisher { get; set; } = null!;

        [Required]
        public DateTime ReleasedOn { get; set; }

        [Required]
        public int GenreId { get; set; }

        [ForeignKey(nameof(GenreId))]
        public Genre Genre { get; set; } = null!;

        public virtual ICollection<GamerGame> GamersGames { get; set; } = new List<GamerGame>();
    }
}
