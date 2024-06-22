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
      
            Console.WriteLine(GetGoldenBooks(db));
        }
        public static string GetGoldenBooks(BookShopContext context)
        {

        
            EditionType editionType = EditionType.Gold;

            var goldenEditionBooks = context.Books
                .Where(x => x.EditionType == editionType && x.Copies < 5000)
                .OrderBy(x => x.BookId).ToList()
                .Select(x => x.Title);

            return string.Join(Environment.NewLine,goldenEditionBooks);
        }

    }
}
