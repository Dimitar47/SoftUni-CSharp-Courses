namespace _02.VehiclesExtension
{
    public class Bus : Vehicle
    {
        private const double SummerConsumption = 1.4;

        public Bus(double fuelQuantity, double fuelConsumption, double tankCapacity)
            : base(fuelQuantity, fuelConsumption, tankCapacity)
        {
        }


        public override void Drive(double distance)
        {
            FuelConsumption += SummerConsumption;

            base.Drive(distance);

            FuelConsumption -= SummerConsumption;
        }


        public void DriveEmpty(double km)
        {
            base.Drive(km);
        }
    }
}

