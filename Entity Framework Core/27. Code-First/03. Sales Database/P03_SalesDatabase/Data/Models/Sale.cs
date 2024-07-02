using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P03_SalesDatabase.Data.Models
{
    public class Sale
    {
        /*
         •	Sale
        	SaleId
        	Date
        	Product
        	Customer
        	Store
        */
        [Key]
        public int SaleId { get; set; }

        public DateTime Date { get; set; }

        public int ProductId { get;set; }
        [ForeignKey(nameof(ProductId))]
        public Product Product { get; set; }

        public int CustomerId { get; set; }
        [ForeignKey(nameof(CustomerId))]   
        public Customer Customer { get; set; }

        public int StoreId { get; set; }
        [ForeignKey(nameof(StoreId))]
        public Store Store { get; set; }
    }
}
