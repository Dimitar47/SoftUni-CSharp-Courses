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

            string result = GetTotalProfitByCategory(db);

            Console.WriteLine(result);
            
        }

        public static string GetTotalProfitByCategory(BookShopContext context)
        {

            var categoryProfits = context.Categories
            .Select(category => new
            {
                CategoryName = category.Name,
                TotalProfit = category.CategoryBooks
                    .Sum(bookCategory => bookCategory.Book.Price * bookCategory.Book.Copies)
            })
            .OrderByDescending(x => x.TotalProfit)
            .ThenBy(x => x.CategoryName)
            .ToList();

            var sb = new StringBuilder();
            foreach (var item in categoryProfits)
            {
                sb.AppendLine($"{item.CategoryName} ${item.TotalProfit:F2}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
