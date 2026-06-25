using System.Text;

namespace _01.Vehicles
{
    public class Car : Vehicle
    {
        private const double SummerConsumption = 0.9;


        public Car(double fuelQuantity, double fuelConsumption)
            : base(fuelQuantity, fuelConsumption + SummerConsumption)
        {
        }


        public override void Refuel(double amount)
        {
            FuelQuantity += amount;
        }
    }
}
