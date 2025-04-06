using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using static SeminarHub.Constants.ModelConstants;
namespace SeminarHub.Data
{
    public class Category
    {
        [Key]
        [Comment("Unique identifier")]
        public int Id { get; set; }

        [Required]
        [Comment("The name for the category")]
        [MaxLength(CategoryNameMaxLength)]
        public string Name { get; set; } = null!;

        public ICollection<Seminar> Seminars { get; set; } = new List<Seminar>();

    }
    /*
     Category
•	Has Id – a unique integer, Primary Key
•	Has Name – string with min length 3 and max length 50 (required)
•	Has Seminars – a collection of type Seminar


    */
}
