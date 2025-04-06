using Humanizer.Localisation;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static DeskMarket.Constants.ModelConstants;
namespace DeskMarket.Data.Models
{

    /*
 Product
•	Has Id – a unique integer, Primary Key
•	Has ProductName – a string with min length 2 and max length 60 (required)
•	Has Description – string with min length 10 and max length 250 (required)
•	Has Price – decimal in range[1.00m;3000.00m], (required)
•	Has ImageUrl – nullable string (not required)
•	Has SellerId – string (required)
•	Has Seller – IdentityUser (required)
•	Has AddedOn – DateTime with format "dd-MM-yyyy" (required)
o	The DateTime format is recommended, if you are having troubles with this one
o	You are free to use another one)
•	Has CategoryId – integer, foreign key (required)
•	Has Category – Category (required)
•	Has IsDeleted – bool (default value == false)
•	Has ProductsClients – a collection of type ProductClient

*/
    public class Product
    {
        [Key]
        [Comment("Unique Identifier")]
        public int Id { get; set; }

        [Required]
        [MaxLength(ProductProductNameMaxLength)]
        [Comment("Name of Product")]
        public string ProductName { get; set; } = null!;

        [Required]
        [MaxLength(ProductDescriptionMaxLength)]
        [Comment("Description of Product")]
        public string Description { get; set; } = null!;

        [Required]
        [Comment("Price for the product")]
        [Column(TypeName ="decimal(18,2)")]
        public decimal Price { get; set; }

        [Comment("The url for the image of the product")]
        public string? ImageUrl { get; set; }

        [Required]
        [Comment("The identifier of the product seller")]
        public string SellerId { get; set; } = null!;

        [ForeignKey(nameof(SellerId))]
        public IdentityUser Seller { get; set; } = null!;

        [Required]
        [Comment("The date the product has been added on")]
        public DateTime AddedOn { get; set; }

        [Required]
        [Comment("The identifier of the category of the product")]
        public int CategoryId { get; set; }

        [ForeignKey(nameof(CategoryId))]
        public Category Category { get; set; } = null!;

        [Comment("Shows whether product is deleted or not")]
        public bool IsDeleted { get; set; }

        public virtual ICollection<ProductClient> ProductsClients { get; set; } = new List<ProductClient>();
    }

}
