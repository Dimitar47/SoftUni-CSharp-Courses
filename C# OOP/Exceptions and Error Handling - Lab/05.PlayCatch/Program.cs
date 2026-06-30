namespace _05.PlayCatch
{
    public class Program
    {
        public static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();


            int exceptionsCount = 0;

            while (exceptionsCount < 3)
            {
                string[] tokens = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string action = tokens[0];
                try
                {
                    if (action == "Replace")
                    {
                        int index = int.Parse(tokens[1]);
                        int element = int.Parse(tokens[2]);

                        numbers[index] = element;


                    }
                    else if (action == "Print")
                    {
                        int startIndex = int.Parse(tokens[1]);
                        int endIndex = int.Parse(tokens[2]);

                        List<int> filtered = new List<int>();
                        for (int i = startIndex; i <= endIndex; i++)
                        {
                            filtered.Add(numbers[i]);
                        }
                        Console.WriteLine(string.Join(", ",filtered));
                    }
                    else if (action == "Show")
                    {
                        int index = int.Parse(tokens[1]);
                        Console.WriteLine($"{numbers[index]}");
                    }
                }
                catch(ArgumentOutOfRangeException ex)
                {
                    exceptionsCount++;
                    Console.WriteLine($"The index does not exist!");
                }
                catch(FormatException ex)
                {
                    exceptionsCount++;
                    Console.WriteLine("The variable is not in the correct format!");
                }

            }

            Console.WriteLine(string.Join(", ",numbers));






        }
    }
}
