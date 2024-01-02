using System;
using System.Collections.Generic;

namespace _06._Courses
{
    class Program
    {
        static void Main(string[] args)
        {
            string command = "";
            Dictionary<string, List<string>> dictionary = new Dictionary<string, List<string>>();

            while((command = Console.ReadLine()) != "end")
            {
                string[] commandArray = command.Split(" : ");
                string courseName = commandArray[0];
                string studentName = commandArray[1];
                if (!dictionary.ContainsKey(courseName))
                {
                    dictionary.Add(courseName, new List<string>());
                    dictionary[courseName].Add(studentName);

                }
                else
                {
                    dictionary[courseName].Add(studentName);
                }
            }
            foreach(var dictionar in dictionary)
            {
                Console.WriteLine($"{dictionar.Key}: {dictionar.Value.Count}");
                for (int i = 0; i < dictionar.Value.Count; i++)
                {
                    Console.WriteLine($"-- {dictionar.Value[i]}");
                }
            }
        }
    }
}
