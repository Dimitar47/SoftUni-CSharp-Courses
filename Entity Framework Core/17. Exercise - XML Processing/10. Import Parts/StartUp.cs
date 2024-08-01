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
      

            ImportData(context);

            string inputXmlParts =
             File.ReadAllText(@"D:\Users\admin\Desktop\C# DB_SoftUni\Entity Framework Core - June 2024\"
                         + @"17. Exercise - XML Processing\10. Import Parts\Datasets\parts.xml");

            string result = ImportParts(context, inputXmlParts);
            Console.WriteLine(result);
        }

        public static void ImportData(CarDealerContext context)
        {
            string inputXmlSuppliers =
         File.ReadAllText(@"D:\Users\admin\Desktop\C# DB_SoftUni\Entity Framework Core - June 2024\"
                   + @"17. Exercise - XML Processing\09. Import Suppliers\Datasets\suppliers.xml");

            var supplierDtos = Deserialize<List<ImportSuppliersDto>>(inputXmlSuppliers, "Suppliers");

            var suppliers = supplierDtos.Select(dto => new Supplier
            {
                Name = dto.Name,
                IsImporter = dto.IsImporter
            }).ToList();

            context.Suppliers.AddRange(suppliers);
            context.SaveChanges();
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

        public static string ImportParts(CarDealerContext context, string inputXml)
        {
            var partsDtos = Deserialize<List<ImportPartsDto>>(inputXml, "Parts");
            List<int> supplierIds = context.Suppliers.Select(x=>x.Id).ToList();
            List<Part> parts = new List<Part>();

            foreach(var partDo in partsDtos)
            {
                int curSupplierId = partDo.SupplierId;
                if (!supplierIds.Contains(curSupplierId))
                {
                    continue;
                }
                var part = new Part()
                {
                    Name = partDo.Name,
                    Price = partDo.Price,
                    Quantity = partDo.Quantity,
                    SupplierId = curSupplierId
                };
                parts.Add(part);
            }
            

            context.Parts.AddRange(parts);
            context.SaveChanges();

            return $"Successfully imported {parts.Count}";
        }
    }
}