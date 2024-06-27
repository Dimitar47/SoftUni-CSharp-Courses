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

            string inputJSonUsers = File.ReadAllText(@"D:\Users\admin\Desktop\C# DB_SoftUni\Entity Framework Core - June 2024\15. Exercise - JSON Processing\01. Import Users\Datasets\users.json");
            ImportUsers(context, inputJSonUsers);

            string inputJSonProducts = File.ReadAllText(@"D:\Users\admin\Desktop\C# DB_SoftUni\Entity Framework Core - June 2024\15. Exercise - JSON Processing\01. Import Users\Datasets\products.json");
            string result = ImportProducts(context, inputJSonProducts);
            Console.WriteLine(result);

        
        }
        public static string ImportUsers(ProductShopContext context, string inputJson)
        {
            List<User> users = JsonConvert.DeserializeObject<List<User>>(inputJson);
            context.Users.AddRange(users);
            context.SaveChanges();


            return $"Successfully imported {users.Count}";
        }

        public static string ImportProducts(ProductShopContext context, string inputJson)
        {
            List<Product> products = JsonConvert.DeserializeObject<List<Product>>(inputJson);
            context.Products.AddRange(products);
            context.SaveChanges();


            return $"Successfully imported {products.Count}";
        }
    }
}
