using System;

namespace _05.DateModifier
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string startDate = Console.ReadLine();
            string endDate = Console.ReadLine();    
            
            DateModifier dateModifier = new DateModifier();
            int difference = dateModifier.CalculateDifference(startDate, endDate);
            Console.WriteLine(Math.Abs(difference));
        }
    }
}