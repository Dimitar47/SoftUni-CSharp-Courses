namespace Tuple
{
    internal class StartUp
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string fullName = string.Join(" ", input.Split().Take(2));
            string address = input.Split().Last();
            var tuple1 = new Tuple<string, string>(fullName, address);

            input = Console.ReadLine();
            string name = input.Split().First();
            int litersOfBeer = int.Parse(input.Split().Last());
            var tuple2 = new Tuple<string, int>(name, litersOfBeer);

            input = Console.ReadLine();
            int integerValue = int.Parse(input.Split().First());
            double doubleValue = double.Parse(input.Split().Last());
            var tuple3 = new Tuple<int, double>(integerValue, doubleValue);

            Console.WriteLine(tuple1);
            Console.WriteLine(tuple2);
            Console.WriteLine(tuple3);
        }
    }
}