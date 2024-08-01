using CarDealer.Data;
using CarDealer.DTOs.Import;
using CarDealer.Models;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace CarDealer
{
    public class StartUp
    {
        public static void Main()
        {
            using CarDealerContext context = new CarDealerContext();
  


            string inputXmlSuppliers =
          File.ReadAllText(@"D:\Users\admin\Desktop\C# DB_SoftUni\Entity Framework Core - June 2024\"
                    + @"17. Exercise - XML Processing\09. Import Suppliers\Datasets\suppliers.xml");

            string result = ImportSuppliers(context, inputXmlSuppliers);

            Console.WriteLine(result);
        }

        public static T Deserialize<T>(string inputXml, string rootElementName)
        {
            var xmlRoot = new XmlRootAttribute(rootElementName);
            var serializer = new XmlSerializer(typeof(T), xmlRoot);

            using (var reader = new StringReader(inputXml))
            {
                return (T)serializer.Deserialize(reader);
            }
        }

        public static string ImportSuppliers(CarDealerContext context, string inputXmlSuppliers)
        {
            var supplierDtos = Deserialize<List<ImportSuppliersDto>>(inputXmlSuppliers, "Suppliers");

            var suppliers = supplierDtos.Select(dto => new Supplier
            {
                Name = dto.Name,
                IsImporter = dto.IsImporter
            }).ToList();

            context.Suppliers.AddRange(suppliers);
            context.SaveChanges();

            return $"Successfully imported {suppliers.Count}";
        }
    }
}