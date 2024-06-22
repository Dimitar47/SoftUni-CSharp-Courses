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

            Console.WriteLine( RemoveBooks(db));

        }
        public static int RemoveBooks(BookShopContext context)
        {
            var booksToRemove = context.Books.Where(x => x.Copies < 4200).ToList();
            int count = booksToRemove.Count;
            context.Books.RemoveRange(booksToRemove);
            context.SaveChangesAsync();
            return count;

        }
    }
}
