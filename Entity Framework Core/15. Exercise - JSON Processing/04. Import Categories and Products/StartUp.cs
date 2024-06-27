using ProductShop.Data;
using Newtonsoft.Json;
using ProductShop.Models;
using Newtonsoft.Json.Linq;
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
            ImportProducts(context, inputJSonProducts);

            string inputJSonCategories = File.ReadAllText(@"D:\Users\admin\Desktop\C# DB_SoftUni\Entity Framework Core - June 2024\15. Exercise - JSON Processing\01. Import Users\Datasets\categories.json");
            ImportCategories(context, inputJSonCategories);


            string inputJSonCategoriesAndProducts = File.ReadAllText(@"D:\Users\admin\Desktop\C# DB_SoftUni\Entity Framework Core - June 2024\15. Exercise - JSON Processing\01. Import Users\Datasets\categories-products.json");
            string result = ImportCategoryProducts(context, inputJSonCategoriesAndProducts);
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

        public static string ImportCategories(ProductShopContext context, string inputJson)
        {
            List<Category> categories = JsonConvert.DeserializeObject<List<Category>>(inputJson)
                .Where(c => c.Name != null)
                .ToList();

            context.Categories.AddRange(categories);
            context.SaveChanges();


            return $"Successfully imported {categories.Count}";
        }

        public static string ImportCategoryProducts(ProductShopContext context, string inputJson)
        {
            List<CategoryProduct> categoryProducts = JsonConvert.DeserializeObject<List<CategoryProduct>>(inputJson);      

             context.CategoriesProducts.AddRange(categoryProducts);
             context.SaveChanges();


            return $"Successfully imported {categoryProducts.Count}";
        }
    }
}
