using CarDealer.Data;
using CarDealer.DTOs.Import;
using CarDealer.Models;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Globalization;

namespace CarDealer
{
    public class StartUp
    {
        public static void Main()
        {
            CarDealerContext context = new CarDealerContext();

            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            ImportData(context);

            string result = GetCarsWithTheirListOfParts(context);
            File.WriteAllText(@"D:\Users\admin\Desktop\C# DB_SoftUni\Entity Framework Core - June 2024\"
           +  @"15. Exercise - JSON Processing\17. Export Cars With Their List Of Parts\Datasets\cars-and-parts.json",
                            result);
        }
        public static void ImportData(CarDealerContext context)
        {
            string inputJSonSuppliers =
             File.ReadAllText(@"D:\Users\admin\Desktop\C# DB_SoftUni\Entity Framework Core - June 2024\" +
                             @"15. Exercise - JSON Processing\09. Import Suppliers\Datasets\suppliers.json");

            string inputJSonParts =
               File.ReadAllText(@"D:\Users\admin\Desktop\C# DB_SoftUni\Entity Framework Core - June 2024\"
                              + @"15. Exercise - JSON Processing\10. Import Parts\Datasets\parts.json");

            string inputJSonCars =
             File.ReadAllText(@"D:\Users\admin\Desktop\C# DB_SoftUni\Entity Framework Core - June 2024\"
                             + @"15. Exercise - JSON Processing\11. Import Cars\Datasets\cars.json");

            string inputJSonCustomers =
            File.ReadAllText(@"D:\Users\admin\Desktop\C# DB_SoftUni\Entity Framework Core - June 2024\"
            + @"15. Exercise - JSON Processing\12. Import Customers\Datasets\customers.json");

            string inputJSonSales =
               File.ReadAllText(@"D:\Users\admin\Desktop\C# DB_SoftUni\Entity Framework Core - June 2024\"
                       + @"15. Exercise - JSON Processing\13. Import Sales\Datasets\sales.json");
            //suppliers
            List<Supplier> suppliers = JsonConvert.DeserializeObject<List<Supplier>>(inputJSonSuppliers);
            context.Suppliers.AddRange(suppliers);

            //parts
            int[] supplierIds = context.Suppliers.Select(x => x.Id).ToArray();
            List<Part> parts = JsonConvert.DeserializeObject<List<Part>>(inputJSonParts)
                .Where(x => supplierIds.Contains(x.SupplierId))
                .ToList();
            context.Parts.AddRange(parts);

            //cars
            var carsDto = JsonConvert.DeserializeObject<List<CarImportDto>>(inputJSonCars);
            var partsIds = context.Parts.Select(p => p.Id).ToHashSet();

            var cars = carsDto.Select(c => new Car
            {
                Make = c.Make,
                Model = c.Model,
                TraveledDistance = c.TraveledDistance,
                PartsCars = c.PartsId.Distinct()
                    .Where(pId => partsIds.Contains(pId))
                    .Select(pId => new PartCar
                    {
                        PartId = pId
                    })
                    .ToList()
            })
            .ToList();

            context.Cars.AddRange(cars);

            //customers
            List<Customer> customers = JsonConvert.DeserializeObject<List<Customer>>(inputJSonCustomers);
            context.Customers.AddRange(customers);

            //sales
            List<Sale> sales = JsonConvert.DeserializeObject<List<Sale>>(inputJSonSales);
            context.Sales.AddRange(sales);

            context.SaveChanges();
        }


        public static string GetCarsWithTheirListOfParts(CarDealerContext context)
        {
            var carsAndParts = context.Cars
                            .Select(x => new
                            {
                               car = new
                               {
                                   x.Make,
                                   x.Model,
                                   x.TraveledDistance
                               },
                               parts = x.PartsCars.Select(x => new
                               {
                                   Name = x.Part.Name,
                                   Price = $"{x.Part.Price:f2}"
                               })
                            })
                            .ToList();

            string sth = JsonConvert.SerializeObject(carsAndParts, Formatting.Indented);

            return sth;
        }
    }
}