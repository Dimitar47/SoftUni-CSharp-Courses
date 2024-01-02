using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Vehicles
{
    public class Truck : Vehicle
    {
        private const double REFUEL_MODIFIER = 0.95;
        private const double truckConsumption = 1.6;
        public Truck(double fuelQuantity, double fuelConsumption,double tankCapacity) 
            : base(fuelQuantity, fuelConsumption+truckConsumption,tankCapacity)
        {
        }
        public override void Refuel(double liters)
        {
            if (liters <= 0)
                Console.WriteLine("Fuel must be a positive number");
            else if (FuelQuantity + liters * REFUEL_MODIFIER > TankCapacity)
                Console.WriteLine($"Cannot fit {liters} fuel in the tank");
            else
                base.Refuel(liters * REFUEL_MODIFIER);
        }
    }
}
