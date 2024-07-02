

using ProductShop.Data;
using ProductShop.DTOs.Import;
using ProductShop.Models;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace ProductShop
{
    public class StartUp
    {
        public static void Main()
        {
            using ProductShopContext context = new ProductShopContext();
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            ImportData(context);

            string inputXmlCategoryProducts =
                File.ReadAllText(@"D:\Users\admin\Desktop\C# DB_SoftUni\Entity Framework Core - June 2024\"
               + @"17. Exercise - XML Processing\04. Import Categories and Products\Datasets\categories-products.xml");
            string result = ImportCategoryProducts(context, inputXmlCategoryProducts);
            Console.WriteLine(result);
        }
        private static T Deserialize<T>(string inputXml, string rootName)
        {
            XmlRootAttribute root = new XmlRootAttribute(rootName);
            XmlSerializer serializer = new XmlSerializer(typeof(T), root);

            using StringReader reader = new StringReader(inputXml);

            T dtos = (T)serializer.Deserialize(reader);
            return dtos;
        }

        public static void ImportData(ProductShopContext context)
        {
            string inputXmlUsers =
              File.ReadAllText(@"D:\Users\admin\Desktop\C# DB_SoftUni\Entity Framework Core - June 2024\" +
             @"17. Exercise - XML Processing\01. Import Users\Datasets\users.xml");

            string inputXmlProducts =
                File.ReadAllText(@"D:\Users\admin\Desktop\C# DB_SoftUni\Entity Framework Core - June 2024\" +
                @"17. Exercise - XML Processing\02. Import Products\Datasets\products.xml");

            string inputXmlCategories =
            File.ReadAllText(@"D:\Users\admin\Desktop\C# DB_SoftUni\Entity Framework Core - June 2024\"
                + @"17. Exercise - XML Processing\03. Import Categories\Datasets\categories.xml");

            //users
            var userDtos = Deserialize<List<ImportUserDto>>(inputXmlUsers, "Users");

            List<User> users = userDtos
                .Select(s => new User()
                {
                    FirstName = s.FirstName,
                    LastName = s.LastName,
                    Age = s.Age
                })
                .ToList();
            context.Users.AddRange(users);
            context.SaveChanges();

            //products
            var productsDtos = Deserialize<List<ImportProductDto>>(inputXmlProducts, "Products");

            List<Product> products = productsDtos
               .Select(p => new Product()
               {
                   Name = p.Name,
                   Price = p.Price,
                   SellerId = p.SellerId,
                   BuyerId = p.BuyerId == 0 ? null : p.BuyerId,
               })
               .ToList();

            context.Products.AddRange(products);
            context.SaveChanges();

            //categories 
            var categoriesDtos = Deserialize<ImportCategoryDto[]>(inputXmlCategories, "Categories");

            List<Category> categories = categoriesDtos.Select(c => new Category()
            {
                Name = c.Name
            })
                .ToList();

            context.Categories.AddRange(categories);
            context.SaveChanges();

        }


        public static string ImportCategoryProducts(ProductShopContext context, string inputXml)
        {
            var categoryProductDtos = Deserialize<ImportCategoryProductDto[]>(inputXml, "CategoryProducts");

            List<CategoryProduct> categoryProducts = categoryProductDtos.Select(cp => new CategoryProduct()
            {
                CategoryId = cp.CategoryId,
                ProductId = cp.ProductId
            }).ToList();

            context.CategoryProducts.AddRange(categoryProducts);
            context.SaveChanges();

            return $"Successfully imported {categoryProducts.Count}";
        }


    }
}