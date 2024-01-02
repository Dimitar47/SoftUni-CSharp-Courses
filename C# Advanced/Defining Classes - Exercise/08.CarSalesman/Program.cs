using System.Threading.Channels;

namespace _08.CarSalesman
{
    public class Program
    {
        static void Main(string[] args)
        {
            int engines = int.Parse(Console.ReadLine());
            List<Engine> listOfEngines = new List<Engine>();
            for (int i = 0; i < engines; i++)
            {
                string[] engineInfo = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string model = engineInfo[0];
                int power = int.Parse(engineInfo[1]);
                Engine engine = new Engine();

                engine.Model = model;
                engine.Power = power;


                if (engineInfo.Length > 2)
                {
                    int displacement = 0;
                    bool success = int.TryParse(engineInfo[2],out displacement);
                    if (success)
                    {
                        engine.Displacement = displacement;
                    }
                    else
                    {
                        string efficiency = engineInfo[2];

                        engine.Efficiency = efficiency;
                    }
                    if (engineInfo.Length > 3)
                    {
                        string efficiency = engineInfo[3];
                        engine.Efficiency = efficiency;
                    }

                }
                   
                   
                
                listOfEngines.Add(engine);

            }
            int cars = int.Parse(Console.ReadLine());
            List<Car> listOfCars = new List<Car>(); 
            for (int i = 0; i < cars; i++)
            {
                string[] carInfo = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string model = carInfo[0];
                string engineModel = carInfo[1];
                Car car = new Car();
                car.Model = model;

                foreach (var engine in listOfEngines)
                {
                    if (engine.Model == engineModel)
                    {
                        car.Engine = engine;
                        break;
                    }
                }

           
                if (carInfo.Length > 2)
                {
                    int weight = 0;
                    bool success = int.TryParse(carInfo[2],out weight);
                    if (success)
                    {
                        car.Weight = weight;
                    }
                    else
                    {
                        string color = carInfo[2];
                        car.Color = color;
                    }

                    if (carInfo.Length > 3)
                    {
                        string color = carInfo[3];
                        car.Color = color;
                    }
                }
                
                listOfCars.Add(car);
                
            }
            foreach(var car in listOfCars)
            {
                Console.WriteLine($"{car.Model}:");
                Console.WriteLine($" {car.Engine.Model}:");
                Console.WriteLine($"  Power: {car.Engine.Power}");
                string displacement = car.Engine.Displacement == 0 ? "n/a" : car.Engine.Displacement.ToString();
                Console.WriteLine($"  Displacement: {displacement}");
                string efficiency = car.Engine.Efficiency == null ? "n/a" : car.Engine.Efficiency;
                Console.WriteLine($"  Efficiency: {efficiency}");
                string weight = car.Weight == 0 ? "n/a" : car.Weight.ToString();
                Console.WriteLine($" Weight: {weight}");
                string color = car.Color == null ? "n/a" : car.Color;
                Console.WriteLine($" Color: {color}");
      
            }
        }
    }
}