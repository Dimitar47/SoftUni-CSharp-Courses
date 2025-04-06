using DeskMarket.Data.Models;
using System.ComponentModel.DataAnnotations;
using static DeskMarket.Constants.ModelConstants;
namespace DeskMarket.Models
{
    public class EditViewModel
    {
        [Required]
        [StringLength(ProductProductNameMaxLength, MinimumLength = ProductProductNameMinLength)]
        public string ProductName { get; set; } = string.Empty;

        [Required]
        [Range(typeof(decimal), "1.00", "3000.00")]
        public decimal Price { get; set; }

        [Required]
        [StringLength(ProductDescriptionMaxLength, MinimumLength = ProductDescriptionMinLength)]
        public string Description { get; set; } = string.Empty;

        public string? ImageUrl { get; set; }

        [Required]
        public string AddedOn { get; set; } = DateTime.Today.ToString(ProductAddedOnFormat);


        [Required]
        public int CategoryId { get; set; }

        [Required]
        public string SellerId { get; set; } = string.Empty;

        public List<Category> Categories { get; set; } = new List<Category>();
    }
}
