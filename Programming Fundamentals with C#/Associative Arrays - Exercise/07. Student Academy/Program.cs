using System;
using System.Collections.Generic;
using System.Linq;
namespace _07._Student_Academy
{
    class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            Dictionary<string, List<double>> dictionary = new Dictionary<string, List<double>>();
            for (int i = 0; i < rows; i++)
            {
                string studentName = Console.ReadLine();
                double grade = double.Parse(Console.ReadLine());
                if (!dictionary.ContainsKey(studentName))
                {
                    dictionary.Add(studentName, new List<double>());

                }
                dictionary[studentName].Add(grade);

            }
            foreach (var dictionar in dictionary)
            {
                if (dictionar.Value.Average() >= 4.50)
                {
                    Console.WriteLine($"{dictionar.Key} -> {dictionar.Value.Average():f2}");
                }
            }
        }
    }
}
