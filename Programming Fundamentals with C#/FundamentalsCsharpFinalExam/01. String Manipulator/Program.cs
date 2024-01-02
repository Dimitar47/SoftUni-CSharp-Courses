using System;

namespace _01._String_Manipulator
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            string command = "";
            while ((command = Console.ReadLine()) != "End")
            {
                string[] commandArray = command.Split();
                string action = commandArray[0];
                if (action == "Translate")
                {
                    string character = commandArray[1];
                    string replacement = commandArray[2];
                    while (text.Contains(character))
                    {
                        text = text.Replace(character, replacement);
                    }
                    Console.WriteLine(text);
                }
                else if (action == "Includes")
                {
                    string substring = commandArray[1];
                    if (text.Contains(substring))
                    {
                        Console.WriteLine($"True");
                    }
                    else
                    {
                        Console.WriteLine($"False");
                    }
                }
                else if(action == "Start")
                {
                    string substring = commandArray[1];
                    if (text.StartsWith(substring))
                    {
                        Console.WriteLine("True");
                    }
                    else
                    {
                        Console.WriteLine("False");
                    }
                }
                else if(action == "Lowercase")
                {
                    text = text.ToLower();
                    Console.WriteLine(text);
                }
                else if(action == "FindIndex")
                {
                    string character = commandArray[1];
                    int index = text.LastIndexOf(character);
                    Console.WriteLine(index);
                }
                else
                {
                    int startIndex = int.Parse(commandArray[1]);
                    int count = int.Parse(commandArray[2]);
                    text = text.Remove(startIndex, count);
                    Console.WriteLine(text);
                }
            }
        }
    }
}
