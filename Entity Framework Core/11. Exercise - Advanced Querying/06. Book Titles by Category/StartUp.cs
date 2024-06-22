using BookShop.Data;
using BookShop.Initializer;
using BookShop.Models.Enums;
using Microsoft.EntityFrameworkCore;
using System.Net.WebSockets;
using System.Text;


namespace BookShop
{
    public class StartUp
    {

        static void Main(string[] args)
        {
            using var db = new BookShopContext();
            DbInitializer.ResetDatabase(db);

            string input = Console.ReadLine();
            string result = GetBooksByCategory(db, input);
            Console.WriteLine(result);

            
        }
       

        public static string GetBooksByCategory(BookShopContext context, string input)
        {
            var categories = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                                 .Select(c => c.ToLower())
                                 .ToList();
            var bookTitles = context.Books
           .Where(b => b.BookCategories.Any(bc => categories.Contains(bc.Category.Name.ToLower())))
           .Select(b => b.Title)
           .OrderBy(t => t)
           .ToList();

           return string.Join(Environment.NewLine,bookTitles);
        }

    }
}
