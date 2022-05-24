using System;

namespace _09._Padawan_Equipment
{
    class Program
    {
        static void Main(string[] args)
        {
            double money = double.Parse(Console.ReadLine());
            int students = int.Parse(Console.ReadLine());
            double priceOfLightSabers = double.Parse(Console.ReadLine());
            double priceOfRobes = double.Parse(Console.ReadLine());
            double priceOfBelts = double.Parse(Console.ReadLine());
            
            double lightSabers = priceOfLightSabers * Math.Ceiling(students + 0.10 * students);
            double robes = priceOfRobes * students;
            double belts = 0;
            if (students >= 6)
            {
                 belts = priceOfBelts * students - (students / 6 * priceOfBelts);
            }
            else
            {
                belts = priceOfBelts * students;
            }
            
            double sumAll = lightSabers + belts + robes;
            if (sumAll <= money)
            {
                Console.WriteLine($"The money is enough - it would cost {sumAll:F2}lv.");
            }
            else
            {
                Console.WriteLine($"John will need {Math.Abs(sumAll-money):F2}lv more.");
            }
        }
    }
}
