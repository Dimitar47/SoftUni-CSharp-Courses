namespace _01.Vehicles
{
    public abstract class Vehicle
    {
        protected Vehicle(double fuelQuantity, double fuelConsumption)
        {
            FuelQuantity = fuelQuantity;
            FuelConsumption = fuelConsumption;
        }

        public double FuelQuantity { get; protected set; }
        public double FuelConsumption { get;  protected set; }
        public virtual void Drive(double distance)
        {
            double fuelNeeded = FuelConsumption * distance;

            if (fuelNeeded > FuelQuantity)
            {
                throw new ArgumentException($"{GetType().Name} needs refueling");
                
            }

            FuelQuantity -= fuelNeeded;

            Console.WriteLine($"{GetType().Name} travelled {distance} km");
        }
        public abstract void Refuel(double amount);
        public override string ToString()
        {
            return $"{GetType().Name}: {FuelQuantity:F2}";
        }


    }
}
