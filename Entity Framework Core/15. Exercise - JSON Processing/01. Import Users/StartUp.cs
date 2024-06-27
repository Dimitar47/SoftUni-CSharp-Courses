using ProductShop.Data;
using Newtonsoft.Json;
using ProductShop.Models;
namespace ProductShop
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            using ProductShopContext context = new ProductShopContext();
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
            string inputJSon = File.ReadAllText(@"D:\Users\admin\Desktop\C# DB_SoftUni\Entity Framework Core - June 2024\15. Exercise - JSON Processing\01. Import Users\Datasets\users.json");

            string result = ImportUsers(context, inputJSon);
            Console.WriteLine(result);
        }
        public static string ImportUsers(ProductShopContext context, string inputJson)
        {
            List<User> users = JsonConvert.DeserializeObject<List<User>>(inputJson);
            context.Users.AddRange(users);
            context.SaveChanges();


            return $"Successfully imported {users.Count}";
        }
    }
}
