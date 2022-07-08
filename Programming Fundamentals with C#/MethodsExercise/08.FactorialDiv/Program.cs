using System;
using System.Runtime.InteropServices;

namespace _08.FactorialDiv
{
    class Program
    {
        static void Main(string[] args)
        {
            double number1 = double.Parse(Console.ReadLine());
            double number2 = double.Parse(Console.ReadLine());

            Console.WriteLine($"{Divide(PrintFactorial1(number1) / PrintFactorial1(number2)):f2}");
        }
        static double PrintFactorial1(double number1)
        {
            if (number1 == 1)
            {
                return 1;
            }

            return number1 * PrintFactorial1(number1 - 1);
        }
        static int PrintFactorial2(int number2)
        {
            if (number2 == 1)
            {
                return 1;
            }
            return number2 * PrintFactorial2(number2 - 1);

        }

        static double Divide(double number1)
        {
            return number1;
        }
    }
}

   //static void Main(string[] args)
   //     {
   //         int firstNum = int.Parse(Console.ReadLine());
   //         int secondNum= int.Parse(Console.ReadLine());

   //         long factorielOne = GetFactorielFirstNumber(firstNum);
   //         long factorielTwo = GetFactorielSecondNumber(secondNum);

   //         double result = (factorielOne * 1.0 / factorielTwo);
   //         Console.WriteLine($"{result:F2}");
   //     }

   //     static long GetFactorielFirstNumber(int firstNum)
   //     {
   //        long factorialOne = 1;

   //         for (int i = 1; i <= firstNum; i++)
   //         {
   //             factorialOne = factorialOne * i;
   //         }
   //         return factorialOne;
   //     }

   //     static long GetFactorielSecondNumber(int secondNum)
   //     {
   //         long factorialTwo = 1;

   //         for (int i = 1; i <= secondNum; i++)
   //         {
   //             factorialTwo = factorialTwo * i;
   //         }
   //         return factorialTwo;
   //     }      