namespace DeskMarket.Models
{
    public class CartViewModel
    {
        public int Id { get; set; }

        public required string ProductName { get; set; }

        public string? ImageUrl { get; set; }

        public required decimal Price { get; set; }
    }
}
