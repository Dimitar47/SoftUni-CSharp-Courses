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


            string result = GetTotalSalesByCustomer(context);
            File.WriteAllText(
                @"D:\Users\admin\Desktop\C# DB_SoftUni\Entity Framework Core - June 2024\"
+ @"17. Exercise - XML Processing\18. Export Total Sales By Customer\Results\customers-total-sales.xml"
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


        public static string GetTotalSalesByCustomer(CarDealerContext context)
        {
            var tempDto = context.Customers
                .Where(c => c.Sales.Any())
                .Select(c => new
                {
                    FullName = c.Name,
                    BoughtCars = c.Sales.Count(),
                    SalesInfo = c.Sales.Select(s => new
                    {
                        Prices = c.IsYoungDriver
                            ? s.Car.PartsCars.Sum(p => Math.Round((double)p.Part.Price * 0.95, 2))
                            : s.Car.PartsCars.Sum(p => (double)p.Part.Price)
                    }).ToArray(),
                })
                .ToArray();

            ExportTotalSalesCustomerDto[] totalSalesDtos = tempDto
                .OrderByDescending(t => t.SalesInfo.Sum(s => s.Prices))
                .Select(t => new ExportTotalSalesCustomerDto()
                {
                    Name = t.FullName,
                    BoughtCars = t.BoughtCars,
                    SpentMoney = t.SalesInfo.Sum(s => s.Prices).ToString("f2")
                })
                .ToArray();

            return Serializer<ExportTotalSalesCustomerDto[]>(totalSalesDtos, "customers");
        }



    }
}