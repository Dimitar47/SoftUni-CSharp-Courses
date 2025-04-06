using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using static DeskMarket.Constants.ModelConstants;
namespace DeskMarket.Data.Models
{
    /*
     Category
•	Has Id – a unique integer, Primary Key
•	Has Name – a string with min length 3 and max length 20 (required)
•	Has Products – a collection of type Product


    */
    public class Category
    {
        

        [Key]
        [Comment("The identifier of the category of the product")]
        public int Id { get; set; }

        [Required]
        [MaxLength(CategoryNameMaxLength)]
        [Comment("The name of the category")]
        public string Name { get; set; } = null!;

        public ICollection<Product> Products { get; set; } = new List<Product>();
    }

  
}
