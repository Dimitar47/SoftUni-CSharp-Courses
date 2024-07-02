using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P03_SalesDatabase.Data.Models
{
    public class Product
    {
        /*
          •	Product
            	ProductId
            	Name (up to 50 characters, unicode)
            	Quantity (real number)
            	Price
            	Sales

         */
        public Product()
        {
            Sales = new List<Sale>();
        }
        [Key]
        public int ProductId { get; set; }

        [Unicode]
        [MaxLength(50)]
        public string Name { get; set; }

        public double Quantity { get; set; }

        public decimal Price { get; set; }  

        public ICollection<Sale> Sales { get; set; }
    }
}
