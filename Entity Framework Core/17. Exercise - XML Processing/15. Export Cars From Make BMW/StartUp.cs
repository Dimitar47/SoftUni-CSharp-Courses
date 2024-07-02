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


            string result = GetCarsFromMakeBmw(context);
            File.WriteAllText(
                @"D:\Users\admin\Desktop\C# DB_SoftUni\Entity Framework Core - June 2024\"
            + @"17. Exercise - XML Processing\15. Export Cars From Make BMW\Results\bmw-cars.xml"
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


        public static string GetCarsFromMakeBmw(CarDealerContext context)
        {
            var bmwCarsDtos = context.Cars
                            .Where(x => x.Make == "BMW")
                            .OrderBy(x => x.Model)
                            .ThenByDescending(x => x.TraveledDistance)
                            .Select(x=> new ExportMakeBMWDto()
                            {
                                Id = x.Id,
                                Model = x.Model,
                                TraveledDistance = x.TraveledDistance
                            })
                            .ToList();

            return Serializer<List<ExportMakeBMWDto>>(bmwCarsDtos, "cars");

            
        }



    }
}