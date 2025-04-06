using SeminarHub.Common;
using System.ComponentModel.DataAnnotations;

namespace SeminarHub.Data.Models
{
    public class Category
    {
        public Category()
        {
            Seminars = new HashSet<Seminar>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(ValidationConstants.CategoryNameMaxLength)]
        public string Name { get; set; } = null!;

        public virtual ICollection<Seminar> Seminars { get; set; }
    }
}
