namespace _07.RawData
{
    public class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Car> cars = new List<Car>();
            for (int i = 0; i < n; i++)
            {
                string[] carInfo = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
               /* "{model} {engineSpeed} {enginePower} {cargoWeight} {cargoType} {tire1Pressure}
                { tire1Age}
                { tire2Pressure}
                { tire2Age}
                { tire3Pressure}
                { tire3Age}
                { tire4Pressure}
                { tire4Age}
                "
*/
                string model = carInfo[0];
                int engineSpeed = int.Parse(carInfo[1]);
                int enginePower = int.Parse(carInfo[2]);
                int cargoWeight = int.Parse(carInfo[3]);
                string cargoType = carInfo[4];

                double tire1Pressure = double.Parse(carInfo[5]);
                int tire1Age = int.Parse(carInfo[6]);
                double tire2Pressure = double.Parse(carInfo[7]);
                int tire2Age = int.Parse(carInfo[8]);

                double tire3Pressure = double.Parse(carInfo[9]);
                int tire3Age = int.Parse(carInfo[10]);
                double tire4Pressure = double.Parse(carInfo[11]);
                int tire4Age = int.Parse(carInfo[12]);


                Car car = new Car(model, engineSpeed, enginePower, cargoWeight, cargoType, tire1Pressure, tire1Age,
                    tire2Pressure, tire2Age, tire3Pressure, tire3Age, tire4Pressure, tire4Age);

               cars.Add(car);
            }
            string command = Console.ReadLine();
            List<Car> fragileCars = cars.Where(x => x.Cargo.Type == "fragile" && x.Tires.Any(x => x.Pressure < 1)).ToList();
            List<Car> flammableCars = cars.Where(x => x.Cargo.Type == "flammable" && x.Engine.Power > 250).ToList();
            if(command == "fragile")
            {
                foreach(var car in fragileCars)
                {
                    Console.WriteLine(car.Model);
                }
            }
            else
            {
                foreach(var car in flammableCars)
                {
                    Console.WriteLine(car.Model);
                }
            }
        }
    }
}