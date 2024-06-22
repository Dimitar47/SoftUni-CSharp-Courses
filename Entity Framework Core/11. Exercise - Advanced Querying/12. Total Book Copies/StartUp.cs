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

          
            Console.WriteLine(CountCopiesByAuthor(db));
        }

        public static string CountCopiesByAuthor(BookShopContext context)
        {
            var totalCopiesForAuthor = context.Books
                
                .Select(x => new
                {
                    AuthorId = x.AuthorId,
                    AuthorFirstName = x.Author.FirstName,
                    AuthorLastName = x.Author.LastName,
                    BookCopies = x.Author.Books
                    .Sum(x=>x.Copies)
                })  
                .OrderByDescending(x => x.BookCopies)
                
                .ToList();

            StringBuilder sb = new StringBuilder();
            foreach(var copy in totalCopiesForAuthor.Distinct())
            {
                sb.AppendLine($"{copy.AuthorFirstName} {copy.AuthorLastName} - {copy.BookCopies}");
            }
            return sb.ToString().TrimEnd();
        }
    }
}
