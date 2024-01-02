namespace _01.Vehicles
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] carInfo = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
            string[] truckInfo = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
            string[] busInfo = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();

            double carFuelQuantity = double.Parse(carInfo[1]);
            double carFuelConsumption = double.Parse(carInfo[2]);
            double carTankCapacity = double.Parse(carInfo[3]);

            double truckFuelQuantity = double.Parse(truckInfo[1]);
            double truckFuelConsumption = double.Parse(truckInfo[2]);
            double truckTankCapacity = double.Parse(truckInfo[3]);


            double busFuelQuantity = double.Parse(busInfo[1]);
            double busFuelConsumption = double.Parse(busInfo[2]);
            double busTankCapacity = double.Parse(busInfo[3]);

            Car car = new Car(carFuelQuantity, carFuelConsumption,carTankCapacity);
            Truck truck = new Truck(truckFuelQuantity, truckFuelConsumption,truckTankCapacity);
            Bus bus = new Bus(busFuelQuantity, busFuelConsumption, busTankCapacity);

            List<Vehicle> vehicles = new List<Vehicle>();
            vehicles.Add(car); 
            vehicles.Add(truck);
            vehicles.Add(bus);

            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] tokens = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string command = tokens[0];
                string typeOfVehicle = tokens[1];
                double value = double.Parse(tokens[2]);
                if(command == "Drive")
                {
                    if(typeOfVehicle == "Car")
                    {
                        car.Drive(value);
                    }
                    else if(typeOfVehicle == "Truck")
                    {
                        truck.Drive(value);
                    }
                    else
                    {
                        bus.Drive(value);
                    }
                }
                else if(command == "Refuel")
                {
                    if (typeOfVehicle == "Car")
                    {
                        car.Refuel(value);

                    }
                    else if(typeOfVehicle == "Truck")
                    {
                        truck.Refuel(value);
                    }
                    else
                    {
                        bus.Refuel(value);
                    }
                }
                else
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