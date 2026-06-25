namespace _02.VehiclesExtension
{
    public class Truck : Vehicle
    {
        private const double SummerConsumption = 1.6;

        public Truck(double fuelQuantity, double fuelConsumption, double tankCapacity) : base(fuelQuantity, fuelConsumption + SummerConsumption, tankCapacity)
        {
        }

        public override void Refuel(double amount)
        {
            if (amount <= 0)
            {
                Console.WriteLine($"Fuel must be a positive number");
            }

            else if (FuelQuantity + amount * 0.95 > TankCapacity)
            {
                Console.WriteLine($"Cannot fit {amount} fuel in the tank");
            }
            else
            {
                FuelQuantity += amount * 0.95;
            }
        }
    }

}
