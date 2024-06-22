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

            int year = int.Parse(Console.ReadLine());
            Console.WriteLine(GetBooksNotReleasedIn(db,year));
        }
        public static string GetBooksNotReleasedIn(BookShopContext context, int year)
        {

            var books = context.Books
                .AsEnumerable()
                .Select(x => new
                {
                    BookId = x.BookId,
                    BookTitle = x.Title,
                   BookYear = x.ReleaseDate.GetValueOrDefault().Year
                })
                .Where(x=>x.BookYear!=year)
                .OrderBy(x=>x.BookId)
                .ToList();
            StringBuilder sb = new StringBuilder();

          return string.Join(Environment.NewLine,books.Select(x=>x.BookTitle).ToArray());
        }

    }
}
