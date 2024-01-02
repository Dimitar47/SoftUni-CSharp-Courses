namespace _03.GenericSwapMethodString
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> items = new List<int>();
            int numberOfItems = int.Parse(Console.ReadLine());
            for (int i = 0; i < numberOfItems; i++)
            {
                items.Add(int.Parse(Console.ReadLine()));
            }
            string input = Console.ReadLine();
            int firstIndex = input.Split().Select(x => int.Parse(x)).First();
            int secondIndex = input.Split().Select(x => int.Parse(x)).Last();
            List<int> swappedList = Swap(items, firstIndex, secondIndex);
            foreach (var item in swappedList)
            {
                Console.WriteLine($"{item.GetType()}: {item}");
            }
        }

        public static List<T> Swap<T>(List<T> items, int firstIndex, int secondIndex)
        {
            T temp = items[firstIndex];
            items[firstIndex] = items[secondIndex];
            items[secondIndex] = temp;
            return items;
        }
    }
}