using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Average_Student_Grades
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int students = int.Parse(Console.ReadLine());

            Dictionary<string, List<decimal>> keyValuePairs = 
                new Dictionary<string, List<decimal>>();

            for (int i = 0; i < students; i++)
            {
                string[] arr = Console.ReadLine().Split(" ",
                    StringSplitOptions.RemoveEmptyEntries)
                   .ToArray();
                string name = arr[0];
                decimal grade = decimal.Parse(arr[1]);
                if (!keyValuePairs.ContainsKey(name))
                {
                    keyValuePairs.Add(name, new List<decimal>());


               }
                
                    keyValuePairs[name].Add(grade);
                
            }
            foreach(var student in keyValuePairs)
            {
                Console.Write($"{student.Key} -> ");
                foreach(var grade in student.Value)
                {
                    Console.Write($"{grade:F2} ");

                }
                Console.WriteLine($"(avg: {keyValuePairs[student.Key].Average():F2})");
                
            }
        }
    }
}
