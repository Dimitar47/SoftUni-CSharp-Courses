using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DeskMarket.Models
{
    public class ProductDetailsViewModel
    {
        public int Id { get; set; }  
  
        public required string ProductName { get; set; } 

        public required string Description { get; set; } 

        public decimal Price { get; set; }

        public string? ImageUrl { get; set; }

        public required string Seller { get; set; } 

        public required string SellerId { get; set; }  

        public required string AddedOn { get; set; } 

        public required string CategoryName { get; set; } 

        public bool IsDeleted { get; set; }  

        public bool HasBought { get; set; }  
    }

}
