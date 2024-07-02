using CarDealer.Data;
using CarDealer.DTOs.Export;

using CarDealer.Models;
using Microsoft.EntityFrameworkCore;
using System.Text;
using System.Xml.Serialization;

namespace CarDealer
{
    public class StartUp
    {
        public static void Main()
        {
            var context = new CarDealerContext();


            string result = GetSalesWithAppliedDiscount(context);
            File.WriteAllText(
                @"D:\Users\admin\Desktop\C# DB_SoftUni\Entity Framework Core - June 2024\"
+ @"17. Exercise - XML Processing\19. Export Sales With Applied Discount\Results\sales-discounts.xml"
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

        public static string GetSalesWithAppliedDiscount(CarDealerContext context)
        {
            ExportSalesAppliedDiscount[] salesDtos = context
                .Sales
                .Select(s => new ExportSalesAppliedDiscount()
                {
                    CarInfoDto = new CarInfoDto()
                    {
                        Make = s.Car.Make,
                        Model = s.Car.Model,
                        TraveledDistance = s.Car.TraveledDistance
                    },
                    Discount = (int)s.Discount,
                    CustomerName = s.Customer.Name,
                    Price = s.Car.PartsCars.Sum(p => p.Part.Price),
                    PriceWithDiscount = Math.Round((double)(s.Car.PartsCars.Sum(p => p.Part.Price) * (1 - (s.Discount / 100))), 4)
                })
                .ToArray();

            return Serializer<ExportSalesAppliedDiscount[]>(salesDtos, "sales");
        }
           



            
        



    }
}