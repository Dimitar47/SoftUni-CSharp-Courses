namespace _01.Vehicles
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            string[] carTokens = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            double carFuelQuantity = double.Parse(carTokens[1]);
            double carLiters = double.Parse(carTokens[2]);

            Car car = new Car(carFuelQuantity, carLiters);

            string[] truckTokens = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            double truckFuelQuantity = double.Parse(truckTokens[1]);
            double truckLiters = double.Parse(truckTokens[2]);

            Truck truck = new Truck(truckFuelQuantity, truckLiters);

            int n = int.Parse(Console.ReadLine());

            List<Vehicle> vehicles = new List<Vehicle>() { car, truck };

            for (int i = 0; i < n; i++)
            {
                try
                {
                    string[] tokens = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                    string action = tokens[0];
                    string type = tokens[1];
                    double value = double.Parse(tokens[2]);
                    Vehicle vehicle = type == "Car" ? car : truck;

                    if (action == "Drive")
                    {

                        
                        vehicle.Drive(value);
                    }
                    else
                    {

                        vehicle.Refuel(value);
                    }
                }
                catch(ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }

            }


            foreach (var vehicle in vehicles)
            {
                Console.WriteLine(vehicle);
            }


        }
    }
}
