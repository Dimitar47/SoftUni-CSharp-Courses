using System;

namespace _02._Sum_Digits
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            int sum = 0;
            string text = number.ToString();
            int length = text.Length;
            for (int i = 0; i < length; i++)
            {
                int currentNumber = number % 10;

                sum += currentNumber;
                number = number / 10;
                
            }
          
            
            Console.WriteLine(sum);
        }
    }
}
