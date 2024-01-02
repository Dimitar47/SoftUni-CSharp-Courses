using System;
using System.Collections.Generic;

namespace _03.SpeedRacing
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfCars = int.Parse(Console.ReadLine());
            List<Car> cars = new List<Car>();
            for (int i = 0; i < numberOfCars; i++)
            {
                string[] carsProperties = Console.ReadLine().Split();
                string model = carsProperties[0];
                double fuelAmount = double.Parse(carsProperties[1]);
                double fuelConsumptionFor1Km = double.Parse(carsProperties[2]);
                double traveledDistance = 0;
                Car car = new Car(model, fuelAmount, fuelConsumptionFor1Km, traveledDistance);
                cars.Add(car);
            }



            while (true)
            {
                string command = Console.ReadLine();
                if (command == "End")
                {
                    break;
                }
                string[] commandArray = command.Split();
                string drive = commandArray[0];
                string carModel = commandArray[1];
                double amountOfKm = double.Parse(commandArray[2]);


                foreach (Car car in cars)
                {
                    if (car.Model ==  carModel && car.CanMoveOrNot(amountOfKm))
                    {
                        car.FuelAmount -= amountOfKm * car.FuelConsumptionPerKm;
                        car.TraveledDistance += amountOfKm;
                    }
                    else if(car.Model == carModel && car.CanMoveOrNot(amountOfKm)== false)
                    {
                        Console.WriteLine("Insufficient fuel for the drive");
                    }

                }
              
            }
            foreach (Car car in cars)
            {
                Console.WriteLine($"{car.Model} {car.FuelAmount:f2} {car.TraveledDistance}");
            }

        }
    }
    class Car
    {
        public Car(string model, double fuelAmount, double fuelConsumptionFor1Km, double traveledDistance)
        {
            this.Model = model;
            this.FuelAmount = fuelAmount;
            this.FuelConsumptionPerKm = fuelConsumptionFor1Km;
            this.TraveledDistance = traveledDistance;
        }
        public string Model { get; set; }
        public double FuelAmount { get; set; }
        public double FuelConsumptionPerKm { get; set; }
        public double TraveledDistance { get; set; }
        public bool CanMoveOrNot(double amountOfKm)
        {
            if (FuelAmount - (amountOfKm * FuelConsumptionPerKm) >= 0)
            {
                return true;
            }
            return false;

        }
    }
}

