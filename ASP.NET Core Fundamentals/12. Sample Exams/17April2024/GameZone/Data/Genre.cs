using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using static GameZone.Constants.ModelConstants;
namespace GameZone.Data
{
    /*
    Genre
•	Has Id – a unique integer, Primary Key
•	Has Name – a string with min length 3 and max length 25 (required)
•	Has Games – a collection of type Game
   */
    public class Genre
    {
        [Key]
        [Comment("The identifier of the genre of the game")]
        public int Id { get; set; }

        [Required]
        [MaxLength(GenreNameMaxLength)]
        [Comment("The name of the genre")]
        public string Name { get; set; } = null!;

        public ICollection<Game> Games { get; set; } = new List<Game>();
    }
   
}
