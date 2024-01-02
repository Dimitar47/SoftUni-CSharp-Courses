namespace _04.Froggy
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split(", ",StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            Lake lake = new(numbers);
            Console.WriteLine(string.Join(", ",lake));

        }
    }
}