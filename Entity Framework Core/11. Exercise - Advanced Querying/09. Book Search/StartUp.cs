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

        static void Main(string[] args)
        {
            using var db = new BookShopContext();
            DbInitializer.ResetDatabase(db);

            string input = Console.ReadLine();
            string result = GetBookTitlesContaining(db, input);
            Console.WriteLine(result);


        }


        public static string GetBookTitlesContaining(BookShopContext context, string input)
        {


            var booksContaining = context.Books
                .AsEnumerable()
           .Select(bc => new
           {
               BookContainTitle = bc.Title
           })
           .Where(x=>x.BookContainTitle.ToLower().Contains(input.ToLower()))
           .OrderBy(x => x.BookContainTitle)
           .ToList();


            StringBuilder sb = new StringBuilder();
            foreach (var bookContaining in booksContaining)
            {
                sb.AppendLine($"{bookContaining.BookContainTitle}");
            }
            return sb.ToString().TrimEnd();
        }

    }
}
