

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




            string result = GetSoldProducts(context);

            File.WriteAllText(@"D:\Users\admin\Desktop\C# DB_SoftUni\Entity Framework Core - June 2024\"
         + @"17. Exercise - XML Processing\06. Export Sold Products\Results\users-sold-products.xml", result);

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


        public static string GetSoldProducts(ProductShopContext context)
        {
            var soldProducts = context.Users
                                .Where(x => x.ProductsSold.Any())
                                .OrderBy(x => x.LastName)
                                .ThenBy(x => x.FirstName)
                                .Take(5)
                                .Select(x => new ExportSoldProductsDto()
                                {
                                    FirstName = x.FirstName,
                                    LastName = x.LastName,
                                    SoldProducts = x.ProductsSold.Select(x => new ProductDto()
                                    {
                                        Name = x.Name,
                                        Price = x.Price
                                    })
                                    .ToList()

                                })
                                .ToList();

            return Serialize<List<ExportSoldProductsDto>>(soldProducts, "Users");
        }







    }
}