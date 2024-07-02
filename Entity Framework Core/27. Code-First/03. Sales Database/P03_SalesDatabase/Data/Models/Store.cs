using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P03_SalesDatabase.Data.Models
{
    public class Store
    {

        /*
         •	Store
        	StoreId
        	Name (up to 80 characters, unicode)
        	Sales
        */
        public Store()
        {
            Sales = new List<Sale>();
        }
        [Key]
        public int StoreId { get; set; }

        [Unicode]
        [MaxLength(80)]
        public string Name { get; set; }

        public ICollection<Sale> Sales { get; set; }

    }
}
