using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Vehicles
{
    public class Vehicle
    {
        private double fuelQuantity;
        private double fuelConsumption;
        private double tankCapacity;
        public Vehicle(double fuelQuantity, double fuelConsumption,double tankCapacity)
        {

            FuelConsumption = fuelConsumption;
           
            TankCapacity = tankCapacity;

            if (fuelQuantity <= TankCapacity)
            {
                FuelQuantity = fuelQuantity;
            }
         

        }
        public double FuelQuantity
        {
            get; 
            set; 
        
        }
        public double FuelConsumption
        {
            get;
            set;

        }
        public double TankCapacity
        {
            get;
            set;

        }



        public virtual void Drive(double distance)
        {
            double newFuelAmount = this.FuelQuantity - this.FuelConsumption * distance ;
            if (newFuelAmount >= 0)
            {
                FuelQuantity = newFuelAmount;
                Console.WriteLine($"{this.GetType().Name} travelled {distance} km");
            }
            else
            {
                Console.WriteLine($"{this.GetType().Name} needs refueling");
            }
        }
        public virtual void Refuel(double liters)
        {

            if (FuelQuantity + liters > TankCapacity)
            {
                Console.WriteLine($"Cannot fit {liters} fuel in the tank");
            }
            else if (liters <= 0)
            {
                Console.WriteLine("Fuel must be a positive number");

            }
            else
            {
                FuelQuantity += liters;
            }
            
        }
        public override string ToString()
        {
            return $"{this.GetType().Name}: {this.FuelQuantity:F2}";
        }
    }
}
