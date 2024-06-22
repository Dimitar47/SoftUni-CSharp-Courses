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

            string date = Console.ReadLine();
            string result = GetBooksReleasedBefore(db, date);
            Console.WriteLine(result);


        }


        public static string GetBooksReleasedBefore(BookShopContext context, string date)
        {

            DateTime parsedDate = DateTime.ParseExact(date, "dd-MM-yyyy", CultureInfo.InvariantCulture);
            var bookTitles = context.Books
                .AsEnumerable()
           .Select(b => new
           {
               BookTitle = b.Title,
               BookEditionType = b.EditionType,
               BookPrice = b.Price,
               BookReleaseDate = b.ReleaseDate
           })
            .Where(x=>x.BookReleaseDate<parsedDate)
           .OrderByDescending(t => t.BookReleaseDate)
           .ToList();


            StringBuilder sb = new StringBuilder();
            foreach(var bookTitle in bookTitles)
            {
                sb.AppendLine($"{bookTitle.BookTitle} - {bookTitle.BookEditionType} - ${bookTitle.BookPrice:f2}");
            }
            return sb.ToString().TrimEnd();
        }

    }
}
