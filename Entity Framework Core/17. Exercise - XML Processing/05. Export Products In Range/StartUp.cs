

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
        


      
            string result = GetProductsInRange(context);

            File.WriteAllText(@"D:\Users\admin\Desktop\C# DB_SoftUni\Entity Framework Core - June 2024\"
         + @"17. Exercise - XML Processing\05. Export Products In Range\Results\products-in-range.xml",result);
           
        }
        private static string Serialize<T>(T products, string rootName)
        {
            XmlRootAttribute root = new XmlRootAttribute(rootName);
            XmlSerializer serializer = new XmlSerializer(typeof(T), root);

            StringBuilder sb = new StringBuilder();
            using StringWriter writer = new StringWriter(sb);

            XmlSerializerNamespaces xmlns = new XmlSerializerNamespaces();
            xmlns.Add(string.Empty, string.Empty);

       
            serializer.Serialize(writer, products,xmlns);

            return sb.ToString();
           
        }
     
        public static string GetProductsInRange(ProductShopContext context)
        {
            var products = context.Products
                            .Where(x => x.Price >= 500 && x.Price <= 1000)
                            .OrderBy(x => x.Price)
                            .Select(x => new ExportProductsInRangeDto()
                            {
                                Name = x.Name,
                                Price = x.Price,
                                Buyer = x.Buyer.FirstName + " " + x.Buyer.LastName
                            })
                            .Take(10)
                            .ToList();

            var productsDtos = Serialize<List<ExportProductsInRangeDto>>(products,"Products");
            return productsDtos;
        }







    }
}