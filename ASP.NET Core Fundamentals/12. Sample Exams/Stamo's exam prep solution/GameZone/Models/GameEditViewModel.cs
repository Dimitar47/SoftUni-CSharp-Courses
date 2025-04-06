using GameZone.Common;
using System.ComponentModel.DataAnnotations;
using System.Configuration;

namespace GameZone.Models
{
    public class GameEditViewModel
    {
        [Required]
        [StringLength(ValidationConstants.GameTitleMaxLength, MinimumLength = ValidationConstants.GameTitleMinLength)]
        public string Title { get; set; } = string.Empty;

        [Required]
        [StringLength(ValidationConstants.GameDescriptionMaxLength, MinimumLength = ValidationConstants.GameDescriptionMinLength)]
        public string Description { get; set; } = string.Empty;

        public string? ImageUrl { get; set; } = string.Empty;

        [Required]
        [RegexStringValidator(@"^\d{4}-\d{2}-\d{2}$")]
        public string ReleasedOn { get; set; } = string.Empty;

        [Required]
        public string PublisherId { get; set; } = string.Empty;

        [Range(1, int.MaxValue)]
        public int GenreId { get; set; }

        public virtual IEnumerable<GenreViewModel>? Genres { get; set; }
    }
}
