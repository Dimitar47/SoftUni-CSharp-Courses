using System;

namespace _4.Tribonacci
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine()); 
            PrintTribonacci(number);
        }

        static void PrintTribonacci(int number)
        {
            int[] numbers = new int[number];
          
            for (int i = 1; i <= number; i++)
            {
                while (i < 3)
                {
                    numbers[i-1] = 1;
                 
                    break;
                }

                if (i == 3)
                {
                    numbers[i-1] = numbers[i - 2] + numbers[i - 3];
                }

                if (i > 3 && i <= number)
                {
                    numbers[i - 1] = numbers[i - 2] + numbers[i - 3] + numbers[i - 4];
                }
                
            }
            Console.WriteLine(string.Join(" ", numbers));


        }
    }
}
