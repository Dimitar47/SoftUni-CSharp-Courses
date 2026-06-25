namespace _02.VehiclesExtension
{
    public abstract class Vehicle
    {
        protected Vehicle(double fuelQuantity, double fuelConsumption, double tankCapacity)
        {
            FuelConsumption = fuelConsumption;
            TankCapacity = tankCapacity;

            if (fuelQuantity <= TankCapacity) 
            {
                FuelQuantity = fuelQuantity;
            }
        }

        public double FuelQuantity { get; protected set; }
        public double FuelConsumption { get; protected set; }
        public double TankCapacity { get; protected set; }
        public virtual void Drive(double distance)
        {
            double fuelNeeded = FuelConsumption * distance;

            if (fuelNeeded > FuelQuantity)
            {
                Console.WriteLine($"{this.GetType().Name} needs refueling");

            }
            else
            {
                FuelQuantity -= fuelNeeded;

                Console.WriteLine($"{GetType().Name} travelled {distance} km");
            }
        }

      
        public virtual void Refuel(double amount)
        {
            if (amount <= 0)
            {
                Console.WriteLine("Fuel must be a positive number");
            }

            else if (FuelQuantity + amount > TankCapacity)
            {
                Console.WriteLine($"Cannot fit {amount} fuel in the tank");
            }

            else
            {
                FuelQuantity += amount;
            }
        }
        public override string ToString()
        {
            return $"{GetType().Name}: {FuelQuantity:F2}";
        }


    }
}
