using CarDealer.Data;
using CarDealer.DTOs.Import;
using CarDealer.Models;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

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


            string inputJSonSales =
                File.ReadAllText(@"D:\Users\admin\Desktop\C# DB_SoftUni\Entity Framework Core - June 2024\"
                        +@"15. Exercise - JSON Processing\13. Import Sales\Datasets\sales.json");
            string result = ImportSales(context,inputJSonSales);
            Console.WriteLine(result);

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


            context.SaveChanges();
        }

        public static string ImportSales(CarDealerContext context, string inputJson)
        {
            List<Sale> sales = JsonConvert.DeserializeObject<List<Sale>>(inputJson);

            context.Sales.AddRange(sales);
            context.SaveChanges();
            return $"Successfully imported {sales.Count}.";
        }

    }
}