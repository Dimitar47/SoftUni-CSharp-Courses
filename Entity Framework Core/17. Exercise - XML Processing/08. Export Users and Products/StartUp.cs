

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

            string result = GetUsersWithProducts(context);

            File.WriteAllText(@"D:\Users\admin\Desktop\C# DB_SoftUni\Entity Framework Core - June 2024\"
         + @"17. Exercise - XML Processing\08. Export Users and Products\Results\users-and-products.xml"
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

        public static string GetUsersWithProducts(ProductShopContext context)
        {
            var usersWithProducts = context.Users
                                .Where(u => u.ProductsSold.Any())
                                .OrderByDescending(u => u.ProductsSold.Count())
                                .Select(u => new UserInfo()
                                {
                                    FirstName = u.FirstName,
                                    LastName = u.LastName,
                                    Age = u.Age,
                                    SoldProducts = new SoldProductCountDto()
                                    {
                                        Count = u.ProductsSold.Count,
                                        Products = u.ProductsSold.Select(x=> new SoldProductDto()
                                        {
                                            Name = x.Name,
                                            Price = x.Price
                                        })
                                        .OrderByDescending(x=> x.Price)
                                        .ToList()
                                    }
                                   
                                })
                                .Take(10)
                                .ToList();

            ExportUserCountDto exportUserCountDto = new ExportUserCountDto()
            {
                Count = context.Users.Count(u=> u.ProductsSold.Any()),
                Users = usersWithProducts
            };
            return Serialize<ExportUserCountDto>(exportUserCountDto, "Users");
        }
    }
}