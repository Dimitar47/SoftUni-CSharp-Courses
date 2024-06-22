using BookShop.Data;
using BookShop.Initializer;
using BookShop.Models;
using BookShop.Models.Enums;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using System.Net.WebSockets;
using System.Text;


namespace BookShop
{
    public class StartUp
    {

        public static void Main()
        {
            using var db = new BookShopContext();
            // DbInitializer.ResetDatabase(db);

             IncreasePrices(db);

        }
        public static void IncreasePrices(BookShopContext context)
        {
            var increased = context.Books.Where(x => x.ReleaseDate.Value.Year < 2010);
            increased.ForEachAsync(x => { x.Price += 5; });
           context.SaveChangesAsync();
            
        }
    }
}
