using System;

namespace _09._Spice_Must_Flow
{
    class Program
    {
        static void Main(string[] args)
        {
            int startingYield = int.Parse(Console.ReadLine());
            int totalAmount = 0;
            int days = 0;
            int leavingSum = 0;
            while (startingYield>=100)
            {
                leavingSum = startingYield - 26;
                totalAmount += leavingSum;
                startingYield -= 10;
                days++;
            }
            Console.WriteLine(days);
            if (totalAmount >= 26)
            {
                Console.WriteLine(totalAmount - 26);
            }
            else
            {
                Console.WriteLine(totalAmount);
            }
        }
    }
}
