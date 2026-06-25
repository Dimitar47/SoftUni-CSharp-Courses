namespace _02.VehiclesExtension
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            string[] carTokens = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            double carFuelQuantity = double.Parse(carTokens[1]);
            double carLiters = double.Parse(carTokens[2]);
            double carTankCapacity = double.Parse(carTokens[3]);

            Car car = new Car(carFuelQuantity, carLiters, carTankCapacity);

            string[] truckTokens = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            double truckFuelQuantity = double.Parse(truckTokens[1]);
            double truckLiters = double.Parse(truckTokens[2]);
            double truckTankCapacity = double.Parse(truckTokens[3]);

            Truck truck = new Truck(truckFuelQuantity, truckLiters, truckTankCapacity);



            string[] busTokens = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            double busFuelQuantity = double.Parse(busTokens[1]);
            double busLiters = double.Parse(busTokens[2]);
            double busTankCapacity = double.Parse(busTokens[3]);

            Bus bus = new Bus(busFuelQuantity, busLiters, busTankCapacity);

            int n = int.Parse(Console.ReadLine());

            List<Vehicle> vehicles = new List<Vehicle>() { car, truck, bus };

            for (int i = 0; i < n; i++)
            {
               
                    string[] tokens = Console.ReadLine().Split();
                    string command = tokens[0];
                    string type = tokens[1];
                    double value = double.Parse(tokens[2]);

                    if (command == "Drive")
                    {
                        switch (type)
                        {
                            case "Car": car.Drive(value); break;
                            case "Truck": truck.Drive(value); break;
                            case "Bus": bus.Drive(value); break;
                        }
                    }
                    else if (command == "Refuel")
                    {
                        switch (type)
                        {
                            case "Car": car.Refuel(value); break;
                            case "Truck": truck.Refuel(value); break;
                            case "Bus": bus.Refuel(value); break;
                        }
                    }
                    else if (command == "DriveEmpty")
                    {
                        bus.DriveEmpty(value);
                    }

                

              
            }
            Console.WriteLine(car);
            Console.WriteLine(truck);
            Console.WriteLine(bus);



        }
    }
}
