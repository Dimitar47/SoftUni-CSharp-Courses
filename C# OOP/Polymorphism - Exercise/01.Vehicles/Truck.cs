using System.Text;

namespace _01.Vehicles
{
    public class Truck : Vehicle
    {
        private const double SummerConsumption = 1.6;

        public Truck(double fuelQuantity, double fuelConsumption)
            : base(fuelQuantity, fuelConsumption + SummerConsumption)
        {
        }
        public override void Refuel(double amount)
        {
            FuelQuantity += amount * 0.95;
        }
    }

}
