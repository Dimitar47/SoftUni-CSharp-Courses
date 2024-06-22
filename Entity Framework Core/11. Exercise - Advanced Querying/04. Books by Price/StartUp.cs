using BookShop.Data;
using BookShop.Initializer;
using BookShop.Models.Enums;

using System.Text;


namespace BookShop
{
    public class StartUp
    {

        static void Main(string[] args)
        {
            using var db = new BookShopContext();
            DbInitializer.ResetDatabase(db);

            Console.WriteLine(GetBooksByPrice(db));
        }
        public static string GetBooksByPrice(BookShopContext context)
        {

            var books = context.Books
                .AsEnumerable()
                .Select(x => new
                {
                    BookTitle = x.Title,
                    BookPrice = $"{x.Price:f2}"
                })
                .Where(x => decimal.Parse(x.BookPrice) > 40)
                .OrderByDescending(x => x.BookPrice)
                .ToList();
            StringBuilder sb = new StringBuilder();
            foreach (var book in books)
            {
                sb.AppendLine($"{book.BookTitle} - ${book.BookPrice}");
            }
            return sb.ToString().TrimEnd();
        }

    }
}
