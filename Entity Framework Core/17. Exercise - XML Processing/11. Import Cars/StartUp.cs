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
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();


            ImportData(context);

            string inputXmlCars =
             File.ReadAllText(@"D:\Users\admin\Desktop\C# DB_SoftUni\Entity Framework Core - June 2024\"
                 + @"17. Exercise - XML Processing\11. Import Cars\Datasets\cars.xml");
            string result = ImportCars(context, inputXmlCars);
            Console.WriteLine(result);

        }

        public static void ImportData(CarDealerContext context)
        {
            string inputXmlSuppliers =
         File.ReadAllText(@"D:\Users\admin\Desktop\C# DB_SoftUni\Entity Framework Core - June 2024\"
                   + @"17. Exercise - XML Processing\09. Import Suppliers\Datasets\suppliers.xml");
            string inputXmlParts =
            File.ReadAllText(@"D:\Users\admin\Desktop\C# DB_SoftUni\Entity Framework Core - June 2024\"
                        + @"17. Exercise - XML Processing\10. Import Parts\Datasets\parts.xml");

            //suppliers
            var supplierDtos = Deserialize<List<ImportSuppliersDto>>(inputXmlSuppliers, "Suppliers");

            var suppliers = supplierDtos.Select(dto => new Supplier
            {
                Name = dto.Name,
                IsImporter = dto.IsImporter
            }).ToList();

            context.Suppliers.AddRange(suppliers);
            context.SaveChanges();

            //parts
            var partsDtos = Deserialize<List<ImportPartsDto>>(inputXmlParts, "Parts");
            List<int> supplierIds = context.Suppliers.Select(x => x.Id).ToList();
            List<Part> parts = new List<Part>();

            foreach (var partDo in partsDtos)
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

        public static string ImportCars(CarDealerContext context, string inputXml)
        {
            var carsDtos = Deserialize<List<ImportCarsDto>>(inputXml, "Cars");
            List<Car> cars = new List<Car>();
            List<PartCar> partCars = new List<PartCar>();
            List<int> partIds = context.Parts.Select(x=>x.Id).OrderBy(x=>x).ToList();
            int partCarId = 1;
            foreach (var carsDto in carsDtos)
            {
                var car = new Car()
                {
                    Make = carsDto.Make,
                    Model = carsDto.Model,
                    TraveledDistance = carsDto.TraveledDistance
                };
                cars.Add(car);

                foreach(int partId in carsDto.Parts
                    .Where(x=> partIds.Contains(x.PartId))
                    .Select(x=> x.PartId)
                    .Distinct())
                {
                    partCars.Add(new PartCar()
                    {
                        CarId = partCarId,
                        PartId = partId

                    });
                }
                partCarId++;
              
            }

            context.Cars.AddRange(cars);
            context.PartsCars.AddRange(partCars);
            context.SaveChanges();
            return $"Successfully imported {cars.Count}";
        }

    }
}