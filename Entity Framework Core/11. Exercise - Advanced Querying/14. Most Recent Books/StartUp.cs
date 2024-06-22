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

            string result = GetMostRecentBooks(db);

            Console.WriteLine(result);

        }
        public static string GetMostRecentBooks(BookShopContext context)
        {

            var categoriesWithBooks = context.Categories
   
                .Select(category => new
                {
                   CategoryName = category.Name,
                    Books = category.CategoryBooks
                    .Select(cb=>cb.Book)
                    .OrderByDescending(book=>book.ReleaseDate)
                    .Take(3)
                    .Select(book=> new
                    {
                        BookTitle = book.Title,
                        BookReleaseDate = book.ReleaseDate.Value.Year
                    })
                    .ToList()

                })
                .OrderBy(x=>x.CategoryName)
                .ToList();

               

            var sb = new StringBuilder();
            foreach (var category in categoriesWithBooks)
            {
                sb.AppendLine($"--{category.CategoryName}");
                foreach (var book in category.Books)
                {
                    sb.AppendLine($"{book.BookTitle} ({book.BookReleaseDate})");
                }
            }

            return sb.ToString().TrimEnd();
        }
    }
}
