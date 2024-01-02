using System;
using System.Text.RegularExpressions;

namespace _01._Extract_Person_Information
{
    class Program
    {
        static void Main(string[] args)
        {
            //int n = int.Parse(Console.ReadLine());
            //for (int i = 0; i < n; i++)
            //{
            //    string command = Console.ReadLine();
            //    int indexOfKliomba = command.IndexOf("@");
            //    int indexOfVerticalBar = command.IndexOf("|");
            //    string name = command.Substring(indexOfKliomba + 1, indexOfVerticalBar-indexOfKliomba-1);
            //    int indexOfHashTag = command.IndexOf("#");
            //    int indexOfArterisk = command.IndexOf("*");
            //    string age = command.Substring(indexOfHashTag + 1, indexOfArterisk - indexOfHashTag - 1);
            //    Console.WriteLine($"{name} is {age} years old.");
            //}

            //With Regex:
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
            string text = Console.ReadLine();
                string namePattern = @"@(?<name>[A-Za-z]+)\|";
                string agePattern = @"#(?<age>[0-9]+)\*";
                Match name = Regex.Match(text, namePattern);
                Match age = Regex.Match(text, agePattern);
                Console.WriteLine($"{name.Groups["name"]} is {age.Groups["age"]} years old.");
            }
        }
    }
}
