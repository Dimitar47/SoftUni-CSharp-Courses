namespace _02.EnterNumbers
{
    public class Program
    {
        public static void Main(string[] args)
        {
            ReadNumber(1, 100);
          
        }
        private static void ReadNumber( int start, int end)
        {
          

            List<int> numbers = new List<int>();

            while (numbers.Count < 10)
            {
                try
                {
                    int number = int.Parse(Console.ReadLine());


                    if(number>start && number < end)
                    {
                        
                        numbers.Add(number);
                        start = number;
                    }
                    else
                    {
                      
                        throw new ArgumentOutOfRangeException($"Your number is not in range {start} - {end}!");
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid Number!");
                }
                catch(ArgumentOutOfRangeException ex)
                {
                    Console.WriteLine(ex.ParamName);
                }
            }
            Console.WriteLine(string.Join(", ",numbers));
        }
    }
}
