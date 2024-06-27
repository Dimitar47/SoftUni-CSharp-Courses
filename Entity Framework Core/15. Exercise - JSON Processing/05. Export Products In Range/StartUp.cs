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
            ImportCategoryProducts(context, inputJSonCategoriesAndProducts);


            string result = GetProductsInRange(context);
            File.WriteAllText(@"D:\Users\admin\Desktop\C# DB_SoftUni\Entity Framework Core - June 2024\15. Exercise - JSON Processing\05. Export Products In Range\Datasets\products-in-range.json",
                result);


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

        public static string GetProductsInRange(ProductShopContext context)
        {
         
            var productsInRange = context.Products
                .Where(x=>x.Price>=500 && x.Price<=1000)
                .OrderBy(x=>x.Price)
                .Select(x=> new
                {
                     name = x.Name,
                     price = x.Price,
                     seller = string.Join(" ",x.Seller.FirstName,x.Seller.LastName)
                })
               .ToList();

            string jsonSerializedText = JsonConvert.SerializeObject(productsInRange,Formatting.Indented);

            return jsonSerializedText;
        
        }

        
    }
}
