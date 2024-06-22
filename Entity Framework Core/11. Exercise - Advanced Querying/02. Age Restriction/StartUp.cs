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
            string command = Console.ReadLine();
            Console.WriteLine(GetBooksByAgeRestriction(db,command));
        }
        public static string GetBooksByAgeRestriction(BookShopContext context, string command)
        {

            AgeRestriction ageRestriction;
            if (!Enum.TryParse(command, true, out ageRestriction))
            {
                return string.Empty;
            }

            var books = context.Books
                .Where(b => b.AgeRestriction == ageRestriction)
                .Select(b => b.Title)
                .OrderBy(title => title)
                .ToList();

            return string.Join(Environment.NewLine, books);
        }
       
    }
}
