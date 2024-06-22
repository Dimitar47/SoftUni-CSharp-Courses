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
            string result = GetAuthorNamesEndingIn(db, input);
            Console.WriteLine(result);


        }


        public static string GetAuthorNamesEndingIn(BookShopContext context, string input)
        {

          
            var authors = context.Authors
                .AsEnumerable()
           .Select(a => new
           {
               AuthorFirstName = a.FirstName,
               AuthorLastName = a.LastName,
               AuthorFullName = a.FirstName + " " + a.LastName
           })
            .Where(x=>x.AuthorFirstName.EndsWith(input))
            .OrderBy(x=>x.AuthorFullName)
           .ToList();


            StringBuilder sb = new StringBuilder();
            foreach (var author in authors)
            {
                sb.AppendLine($"{author.AuthorFullName}");
            }
            return sb.ToString().TrimEnd();
        }

    }
}
