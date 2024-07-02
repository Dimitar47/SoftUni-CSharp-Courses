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


            string result = GetCarsWithDistance(context);
            File.WriteAllText(
                @"D:\Users\admin\Desktop\C# DB_SoftUni\Entity Framework Core - June 2024\"
            + @"17. Exercise - XML Processing\14. Export Cars With Distance\Results\cars.xml"
                , result);


           
        }
        private static string Serializer<T>(T objects, string rootName)
        {
            XmlRootAttribute root = new XmlRootAttribute(rootName);
            XmlSerializer serializer = new XmlSerializer(typeof(T), root);

            StringBuilder sb = new StringBuilder();
            using StringWriter writer = new StringWriter(sb);

           XmlSerializerNamespaces xmlns = new XmlSerializerNamespaces();
            xmlns.Add(string.Empty,string.Empty);
           
            serializer.Serialize(writer, objects,xmlns);

            return sb.ToString();


        }


        public static string GetCarsWithDistance(CarDealerContext context)
        {
            List<ExportCarsWithDistanceDto> carsDtos = context.Cars
                .Where(x => x.TraveledDistance > 2_000_000)
                .OrderBy(x => x.Make)
                .ThenBy(x => x.Model)
                .Take(10)
                .Select(x=> new ExportCarsWithDistanceDto()
                {
                    Make = x.Make,
                    Model = x.Model,
                    TravelledDistance = x.TraveledDistance
                })
                .ToList();
           

            return Serializer<List<ExportCarsWithDistanceDto>>(carsDtos, "cars");
        }
        

        
    }
}