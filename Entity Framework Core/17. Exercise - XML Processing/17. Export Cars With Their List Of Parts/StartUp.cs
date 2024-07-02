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


            string result = GetCarsWithTheirListOfParts(context);
            File.WriteAllText(
                @"D:\Users\admin\Desktop\C# DB_SoftUni\Entity Framework Core - June 2024\"
+ @"17. Exercise - XML Processing\17. Export Cars With Their List Of Parts\Results\cars-and-parts.xml"
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


        public static string GetCarsWithTheirListOfParts(CarDealerContext context)
        {
            var carsAndParts = context.Cars
                            .Select(x => new ExportCarsAndListPartsDto()
                            {
                                Make = x.Make,
                                Model = x.Model,
                                TraveledDistance = x.TraveledDistance,
                                Parts = x.PartsCars.Select(x => new PartsOfCarDto()
                                {
                                    Name = x.Part.Name,
                                    Price = x.Part.Price
                                })
                                .OrderByDescending(x => x.Price)
                                .ToList()
                            })
                            .OrderByDescending(x => x.TraveledDistance)
                            .ThenBy(x => x.Model)
                            .Take(5)
                            .ToList();

            return Serializer<List<ExportCarsAndListPartsDto>>(carsAndParts, "cars");
        }



    }
}