using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Infrastructure.Data.Models
{
    [Comment("Books table")]
    public class Book
    {
        [Key]
        [Comment("Book ID")]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        [Comment("Book title")]
        public required string Title { get; set; }

        [Required]
        [MaxLength(100)]
        [Comment("Book author")]
        public required string Author { get; set; }

        [Comment("Book year of publishing")]
        public int? YearPublished { get; set; }
    }
}
