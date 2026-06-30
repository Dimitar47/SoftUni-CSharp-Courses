using System.Xml.Linq;

namespace _04.SumIntegers
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string[] elements = Console.ReadLine().Split();
            int sum = 0;
            for (int i = 0; i < elements.Length; i++)
            {
                try
                {


                    int n = int.Parse(elements[i]);
                    sum += n;

                }
                catch (FormatException ex)
                {
                    Console.WriteLine($"The element '{elements[i]}' is in wrong format!");
                }
                catch (OverflowException ex)
                {
                    Console.WriteLine($"The element '{elements[i]}' is out of range!");

                }
                finally
                {
                    Console.WriteLine($"Element '{elements[i]}' processed - current sum: {sum}");

                }
            }
            Console.WriteLine($"The total sum of all integers is: {sum}");
        }
    }
}
