using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._List_Operations
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();
            string command = "";
            while ((command = Console.ReadLine()) != "End")
            {
                string[] commandArray = command.Split();
                if (commandArray[0] == "Add")
                {
                    numbers.Add(int.Parse(commandArray[1]));
                }
                else if (commandArray[0] == "Insert")
                {
                    int index = int.Parse(commandArray[2]);

                    if (index >= 0 && index < numbers.Count)
                    {
                        numbers.Insert(index, int.Parse(commandArray[1]));
                    }
                    else
                    {
                        Console.WriteLine("Invalid index");
                    }
                }
                else if (commandArray[0] == "Remove")
                {
                    int index = int.Parse(commandArray[1]);
                    if (index >= 0 && index < numbers.Count)
                    {
                        numbers.RemoveAt(index);
                    }
                    else
                    {
                        Console.WriteLine("Invalid index");
                    }
                }
                else if (commandArray[0] == "Shift" && commandArray[1] == "left")
                {
                    int count = int.Parse(commandArray[2]);
                    for (int i = 0; i < count; i++)
                    {
                        int temp = numbers[0];

                        numbers.Add(numbers[0]);
                        numbers.RemoveAt(0);
                    }
                }
                else if (commandArray[0] == "Shift" && commandArray[1] == "right")
                {
                    int count = int.Parse(commandArray[2]);
                    for (int i = 0; i < count; i++)
                    {
                        int lastIndex = numbers[numbers.Count - 1];
                        numbers.Insert(0, lastIndex);
                        numbers.RemoveAt(numbers.Count - 1);
                    }
                }
            }

            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}
