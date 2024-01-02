using System;
using System.Collections.Generic;
using System.Linq;
namespace _07.VehicleCatalogue
{
    class Program
    {
       static void Main(string[] args)
        {
            string command = "";
            Catalog catalog = new Catalog();
            while ((command = Console.ReadLine()) != "end")
            {
                string[] commandArray = command.Split("/");
                string brand = commandArray[1];
                string model = commandArray[2];
              
                if (commandArray[0] == "Car")
                {

                    int horsePower = int.Parse(commandArray[3]);
                    catalog.Cars.Add(new Car
                    {
                        BrandCar = brand,
                        ModelCar = model,
                        HorsePower = horsePower
                    });
                 
                }
                else if (commandArray[0] == "Truck")
                {
                    double weight = double.Parse(commandArray[3]);

                    catalog.Trucks.Add(new Truck
                    {
                        BrandTruck = brand,
                        ModelTruck = model,
                        Weight = weight
                    });


                }
            }

          
           
            Console.WriteLine("Cars:");
            foreach (Car car in catalog.Cars.OrderBy(truck => truck.BrandCar))
            {
                
                Console.WriteLine($"{car.BrandCar}: {car.ModelCar} - {car.HorsePower}hp");
            }

            Console.WriteLine("Trucks:");
            foreach (Truck truck in catalog.Trucks.OrderBy(truck=>truck.BrandTruck))
            {
                Console.WriteLine($"{truck.BrandTruck}: {truck.ModelTruck} - {truck.Weight}kg");
            }

        }
    }

    class Truck
    {
        public string BrandTruck
        {
            get;set;
        }

        public string ModelTruck
        {
            get;set;
        }

        public double Weight
        {
            get;set;
        }
    }

    class Car
    {
        public string BrandCar
        {
            get; set;
        }

        public string ModelCar
        {
            get; set;
        }

        public int HorsePower
        {
            get;set;
        }
    }
   class Catalog
    {
        public Catalog()
        {
           Cars = new List<Car>();
            Trucks = new List<Truck>();
        }
       
        public List<Car> Cars
        {
            get; set;
        }

        public List<Truck> Trucks
        {
            get; set;
        }

    }

}
