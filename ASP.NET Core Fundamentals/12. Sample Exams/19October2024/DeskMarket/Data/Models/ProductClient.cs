using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace DeskMarket.Data.Models
{
    /*
     ProductClient
  •	Has ProductId – integer, PrimaryKey, foreign key (required)
  •	Has Product – Product
  •	Has ClientId – string, PrimaryKey, foreign key (required)
  •	Has Client – IdentityUser

      */

    [PrimaryKey(nameof(ProductId), nameof(ClientId))]
    public class ProductClient
    {
        [Comment("Identifier of the Product")]
        public int ProductId { get; set; }

        [ForeignKey(nameof(ProductId))]
        public Product Product { get; set; } = null!;

        [Comment("Identifier of the Client")]
        public string ClientId { get; set; } = null!;

        [ForeignKey(nameof(ClientId))]
        public IdentityUser Client { get; set; } = null!;

    }

}
