namespace _05.PlayCatch
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int exceptionsCount =0;
            
            while (exceptionsCount < 3)
            {
                string[] commands = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries);
                string action = commands[0];
                try
                {
                    if (action == "Replace")
                    {
                        int index = int.Parse(commands[1]);
                        int element = int.Parse(commands[2]);
                        numbers[index] = element;
                    }
                    else if (action == "Print")
                    {
                        int startIndex = int.Parse(commands[1]);
                        int endIndex = int.Parse(commands[2]);
                        int[] newArr = new int[Math.Abs(endIndex)-Math.Abs(startIndex)+1];
                        for (int i = startIndex,j=0; i <= endIndex; i++,j++)
                        {
                            newArr[j] = numbers[i];
                        }
                        Console.WriteLine(string.Join(", ",newArr));
                    }
                    else if (action == "Show")
                    {
                        int index = int.Parse(commands[1]);
                        Console.WriteLine(numbers[index]);

                    }
                }
                catch (IndexOutOfRangeException)
                {
                    Console.WriteLine("The index does not exist!");
                    exceptionsCount++;
                }
                catch (FormatException)
                {
                    Console.WriteLine("The variable is not in the correct format!");
                    exceptionsCount++;
                }

            }
            Console.WriteLine(string.Join(", ",numbers));
        }
    }
}