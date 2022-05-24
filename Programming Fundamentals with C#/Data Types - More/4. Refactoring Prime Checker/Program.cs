using System;

namespace _4._Refactoring_Prime_Checker
{
    class Program
    {
        static void Main(string[] args)
        {
            int lastNumber = int.Parse(Console.ReadLine());
            for (int startNumber = 2; startNumber <= lastNumber; startNumber++)
            {
                bool isPrime = true;
                for (int divider = 2; divider < startNumber; divider++)
                {
                    if (startNumber % divider == 0)
                    {
                        isPrime = false;
                        break;
                    }
                }
                Console.WriteLine("{0} -> {1}", startNumber, isPrime.ToString().ToLower());
            }

        }
    }
}
