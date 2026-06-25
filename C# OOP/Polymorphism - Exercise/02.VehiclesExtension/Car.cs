namespace _02.VehiclesExtension
{
    public class Car : Vehicle
    {
        private const double SummerConsumption = 0.9;

        public Car(double fuelQuantity, double fuelConsumption, double tankCapacity) : base(fuelQuantity, fuelConsumption + SummerConsumption, tankCapacity)
        {
        }

        
    }
}
