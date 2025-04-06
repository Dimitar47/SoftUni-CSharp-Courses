using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static GameZone.Constants.ModelConstants;
namespace GameZone.Data
{

    /*
     Game
•	Has Id – a unique integer, Primary Key
•	Has Title – a string with min length 2 and max length 50 (required)
•	Has Description – string with min length 10 and max length 500 (required)
•	Has ImageUrl – nullable string
•	Has PublisherId – string (required)
•	Has Publisher – IdentityUser (required)
•	Has ReleasedOn– DateTime with format " yyyy-MM-dd" (required) (the DateTime format is recommended,
    if you are having troubles with this one, you are free to use another one)
•	Has GenreId – integer, foreign key (required)
•	Has Genre – Genre (required)
•	Has GamersGames – a collection of type GamerGame
*   IsDeleted - implementation of soft delete pattern
    */

    public class Game
    {
        [Key]
        [Comment("Unique Identifier")]
        public int Id { get; set; }

        [Required]
        [MaxLength(GameTitleMaxLength)]
        [Comment("Game Title")]
        public string Title { get; set; } = null!;

        [Required]
        [MaxLength(GameDescriptionMaxLength)]
        [Comment("Game Description")]
        public string Description { get; set; } = null!;

        [Comment("The url for the image of the game")]
        public string? ImageUrl { get; set; }

        [Required]
        [Comment("The identifier of the game publisher")]
        public string PublishedId { get; set; } = null!;

        [ForeignKey(nameof(PublishedId))]
        public IdentityUser Publisher { get; set; } = null!;

        [Required]
        [Comment("Release Date")]
        public DateTime ReleasedOn { get; set; }

        [Required]
        [Comment("The identifier of the genre of the game")]
        public int GenreId { get; set; }

        [ForeignKey(nameof(GenreId))]
        public Genre Genre { get; set; } = null!;

        public virtual ICollection<GamerGame> GamersGames { get; set; } = new List<GamerGame>();

        [Comment("Shows whether game is deleted or not")]
        public bool IsDeleted { get; set; } 

    }
}
