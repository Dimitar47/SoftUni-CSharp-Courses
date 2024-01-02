using System;
using System.Collections.Generic;
using System.Linq;
using System.Globalization;
namespace _06.VehicleCatalogue
{
    class Program
    {

        static void Main(string[] args)
        {
            string command = "";
            List<Vehicle> vehicles = new List<Vehicle>();
            double sumCars = 0;
      
            double sumTrucks = 0;
           
            while((command = Console.ReadLine()) != "End")
            {
                string[] commandArray = command.Split();
                string type = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(commandArray[0].ToLower()); 
                string model = commandArray[1];
                string color = commandArray[2];
                int horsePower = int.Parse(commandArray[3]);
               
               Vehicle vehicle = new Vehicle(type, model, color, horsePower);
                if(vehicle.Type == "Car")
                {
                    sumCars += horsePower;
                 
                }
                else 
                {
                    sumTrucks += horsePower;
                  
                }
               
                vehicles.Add(vehicle);
                
              
            }
            List<Vehicle> containedVehicle = new List<Vehicle>();
            var onlyCars = vehicles.Where(x => x.Type == "Car").ToList();

        
            var onlyTrucks = vehicles.Where(x => x.Type == "Truck").ToList();
         
            while ((command = Console.ReadLine())!= "Close the Catalogue")
            {
                
              containedVehicle = vehicles.Where(x => x.Model == command ).ToList();
                
              Console.WriteLine(string.Join(Environment.NewLine,containedVehicle));
            }

            if (onlyCars.Count > 0)
            {
                Console.WriteLine($"Cars have average horsepower of: {sumCars/onlyCars.Count:f2}.");

            }
            else
            {
                Console.WriteLine($"Cars have average horsepower of: {0:f2}.");
            }

            if (onlyTrucks.Count > 0)
            {
                Console.WriteLine($"Trucks have average horsepower of: {sumTrucks/onlyTrucks.Count:f2}.");
            }
            else
            {
                Console.WriteLine($"Trucks have average horsepower of: {0:f2}.");
            }
        }
        class Vehicle
        {
            public Vehicle(string type,string model,string color,int horsePower)
            {
                Type = type;
                Model = model;
                Color = color;
                HorsePower = horsePower;
            }
            public string Type { get; set; }
            public string Model { get; set; }
            public string Color{ get; set; }
            public int HorsePower { get; set; }
            public override string ToString()
            {
                string Format = string.Format($"Type: {Type}\nModel: {Model}\nColor: {Color}\nHorsepower: {HorsePower}");
                return Format;
            }
        }
    }
}
