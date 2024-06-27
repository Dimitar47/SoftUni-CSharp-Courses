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

            string result = GetCarsFromMakeToyota(context);
            File.WriteAllText(@"D:\Users\admin\Desktop\C# DB_SoftUni\Entity Framework Core - June 2024\"
                 + @"15. Exercise - JSON Processing\15. Export Cars From Make Toyota\Datasets\toyota-cars.json",
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


        public static string GetCarsFromMakeToyota(CarDealerContext context)
        {
            var cars = context.Cars
                            .OrderBy(x => x.Model)
                            .ThenByDescending(x => x.TraveledDistance)
                            .Where(x=>x.Make == "Toyota")
                            .Select(x => new
                            {
                                Id = x.Id,
                                Make = x.Make,
                                Model = x.Model,
                                TraveledDistance = x.TraveledDistance
                            })
                            .ToList();

            string sth = JsonConvert.SerializeObject(cars, Formatting.Indented);

            return sth;
        }
    }
}