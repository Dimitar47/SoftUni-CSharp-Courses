

using ProductShop.Data;
using ProductShop.DTOs.Export;
using ProductShop.DTOs.Import;
using ProductShop.Models;
using System.Text;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace ProductShop
{
    public class StartUp
    {
        public static void Main()
        {
            using ProductShopContext context = new ProductShopContext();

            string result = GetCategoriesByProductsCount(context);

            File.WriteAllText(@"D:\Users\admin\Desktop\C# DB_SoftUni\Entity Framework Core - June 2024\"
         + @"17. Exercise - XML Processing\07. Export Categories By Products Count\Results\categories-by-products.xml"
            , result);

        }
        private static string Serialize<T>(T soldProducts, string rootName)
        {
            XmlRootAttribute root = new XmlRootAttribute(rootName);
            XmlSerializer serializer = new XmlSerializer(typeof(T), root);

            StringBuilder sb = new StringBuilder();
            using StringWriter writer = new StringWriter(sb);

            XmlSerializerNamespaces xmlns = new XmlSerializerNamespaces();
            xmlns.Add(string.Empty, string.Empty);


            serializer.Serialize(writer, soldProducts, xmlns);

            return sb.ToString();

        }

        public static string GetCategoriesByProductsCount(ProductShopContext context)
        {
            var categories = context.Categories
                            .Select(x => new ExportCategoriesProductsCountDto()
                            {
                                Name = x.Name,
                                Count = x.CategoryProducts.Count(),
                                AveragePrice = x.CategoryProducts.Average(x => x.Product.Price),
                                TotalRevenue = x.CategoryProducts.Sum(x => x.Product.Price)
                            })
                            .OrderByDescending(x => x.Count)
                            .ThenBy(x => x.TotalRevenue)
                            .ToList();

            return Serialize<List<ExportCategoriesProductsCountDto>>(categories, "Categories");
                            
        }
    }
}