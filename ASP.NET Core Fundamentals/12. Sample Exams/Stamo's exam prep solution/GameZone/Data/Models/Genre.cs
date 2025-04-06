using GameZone.Common;
using System.ComponentModel.DataAnnotations;

namespace GameZone.Data.Models
{
    public class Genre
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(ValidationConstants.GenreNameMaxLength)]
        public string Name { get; set; } = null!;

        public virtual ICollection<Game> Games { get; set; } = new HashSet<Game>();
    }
}
