using System;
using System.Numerics;

namespace _02._From_Left_to_The_Right
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
           
            for (int i = 0; i < n; i++)
            {
                BigInteger sum = 0;
                string[] text = Console.ReadLine().Split();
                BigInteger number1 = BigInteger.Parse(text[0]);
                BigInteger number2 = BigInteger.Parse(text[1]);
                if (number1 >= number2)
                {
                    for (int j = 0; j < text[0].Length; j++)
                    {
                        BigInteger currentNumber = number1 % 10;
                        sum += currentNumber;
                        number1 = number1 / 10;
                    }
                   
                    

                }
                else if(number2> number1)
                {
                    for (int j = 0; j < text[1].Length; j++)
                    {
                        BigInteger currentNumber = number2 % 10;
                        sum += currentNumber;
                        number2 = number2 / 10;
                    }
                }
                Console.WriteLine(BigInteger.Abs(sum));
            }
        }
    }
}
