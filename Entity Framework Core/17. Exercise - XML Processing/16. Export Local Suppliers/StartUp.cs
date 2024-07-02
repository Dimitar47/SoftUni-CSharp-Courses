using CarDealer.Data;
using CarDealer.DTOs.Export;

using CarDealer.Models;
using System.Text;
using System.Xml.Serialization;

namespace CarDealer
{
    public class StartUp
    {
        public static void Main()
        {
            var context = new CarDealerContext();


            string result = GetLocalSuppliers(context);
            File.WriteAllText(
                @"D:\Users\admin\Desktop\C# DB_SoftUni\Entity Framework Core - June 2024\"
            + @"17. Exercise - XML Processing\16. Export Local Suppliers\Results\local-suppliers.xml"
                , result);



        }
        private static string Serializer<T>(T objects, string rootName)
        {
            XmlRootAttribute root = new XmlRootAttribute(rootName);
            XmlSerializer serializer = new XmlSerializer(typeof(T), root);

            StringBuilder sb = new StringBuilder();
            using StringWriter writer = new StringWriter(sb);

            XmlSerializerNamespaces xmlns = new XmlSerializerNamespaces();
            xmlns.Add(string.Empty, string.Empty);

            serializer.Serialize(writer, objects, xmlns);

            return sb.ToString();


        }


        public static string GetLocalSuppliers(CarDealerContext context)
        {
            var localSuppliersDtos = context.Suppliers
                                .Where(x => x.IsImporter == false)
                                .Select(x => new ExportLocalSuppliersDto()
                                {
                                    Id = x.Id,
                                    Name = x.Name,
                                    PartsCount = x.Parts.Count
                                }).ToList();

            return Serializer<List<ExportLocalSuppliersDto>>(localSuppliersDtos, "suppliers");

        }



    }
}