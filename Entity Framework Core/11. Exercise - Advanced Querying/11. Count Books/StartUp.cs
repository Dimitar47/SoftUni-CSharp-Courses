using BookShop.Data;
using BookShop.Initializer;
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
            DbInitializer.ResetDatabase(db);

            int length  = int.Parse(Console.ReadLine());
            Console.WriteLine(CountBooks(db, length));
        }

        public static int CountBooks(BookShopContext context, int lengthCheck)
        {
            var numBooks = context.Books.Count(x => x.Title.Length > lengthCheck);

            return numBooks;
        }
    }
}
