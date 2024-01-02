using System;
using System.Collections.Generic;

namespace _04.RawData
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Car> cars = new List<Car>();
            for (int i = 0; i < n; i++)
            {
                string[] carProperties = Console.ReadLine().Split();
                string model = carProperties[0];
                int engineSpeed = int.Parse(carProperties[1]);
                int enginePower = int.Parse(carProperties[2]);
                int cargoWeight = int.Parse(carProperties[3]);
                string cargoType = carProperties[4];
                Car car = new Car
                {
                    Model = model,
                    engine = new Engine
                    {
                        EngineSpeed = engineSpeed,
                        EnginePower = enginePower,
                    },
                    cargo = new Cargo
                    {
                        CargoWeight = cargoWeight,
                        CargoType = cargoType
                    }
                };
                cars.Add(car);
            }
            string command = Console.ReadLine();
            foreach(Car car in cars)
            {
                
                 if (command == "fragile")
                 {
                        if(car.cargo.CargoWeight < 1000 && car.cargo.CargoType == "fragile")
                        {
                            Console.WriteLine(car.Model);
                        }

                 }
                else
                {
                    if(car.engine.EnginePower>250 && car.cargo.CargoType == "flamable")
                    {
                        Console.WriteLine(car.Model);
                    }
                }
                
            }
        }
    }
    class Car
    {
        public string Model { get; set; }
        public Engine engine { get; set; }
        public Cargo cargo { get; set; }
    }
    class Engine
    {
        public int EngineSpeed { get; set; }
        public int EnginePower { get; set; }
    }
    class Cargo
    {
        public int CargoWeight { get; set; }
        public string CargoType { get; set; }
    }
}
