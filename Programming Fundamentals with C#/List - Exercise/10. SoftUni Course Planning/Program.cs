using System;
using System.Collections.Generic;
using System.Linq;

namespace _10._SoftUni_Course_Planning
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> lessons = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).ToList();
            string command = "";
            
            while ((command = Console.ReadLine()) != "course start")
            {

                string[] commandArray = command.Split(":");
                if (commandArray[0] == "Add" && !lessons.Contains(commandArray[1]))
                {
                    lessons.Add(commandArray[1]);
                }
                else if (commandArray[0] == "Insert" && !lessons.Contains(commandArray[1]))
                {
                    lessons.Insert(int.Parse(commandArray[2]), commandArray[1]);
                }
                else if (commandArray[0] == "Remove" && lessons.Contains(commandArray[1]))
                {
                    lessons.Remove(commandArray[1]);
                    if (lessons.Contains($"{commandArray[1]}-Exercise"))
                    {
                        lessons.Remove($"{commandArray[1]}-Exercise");
                    }
                }
                else if (commandArray[0] == "Swap" && lessons.Contains(commandArray[1]) && lessons.Contains(commandArray[2]))
                {
                    int firstIndex = lessons.IndexOf(commandArray[1]);
                    int secondIndex = lessons.IndexOf(commandArray[2]);
                    lessons[firstIndex] = commandArray[2];
                    lessons[secondIndex] = commandArray[1];

                    if (lessons.Contains($"{commandArray[1]}-Exercise"))
                    {
                        lessons.Insert(secondIndex + 1, $"{commandArray[1]}-Exercise");
                        lessons.RemoveAt(firstIndex + 2);
                    }
                    if (lessons.Contains($"{commandArray[2]}-Exercise"))
                    {
                        lessons.Insert(firstIndex + 1, $"{commandArray[2]}-Exercise");
                        lessons.RemoveAt(secondIndex + 2);
                    }

                }

                else if (commandArray[0] == "Exercise" && !lessons.Contains($"{commandArray[1]}-Exercise"))
                {
                    if (!lessons.Contains(commandArray[1]))
                    {
                        lessons.Add(commandArray[1]);
                        lessons.Add($"{commandArray[1]}-Exercise");
                    }
                    else
                    {
                        int indexOfLesson = lessons.IndexOf(commandArray[1]);
                        lessons.Insert(indexOfLesson + 1, $"{commandArray[1]}-Exercise");
                    }
                }


            }
            int i = 0;
            foreach (var item in lessons)
            {

                i++;
                Console.WriteLine($"{i}.{item}");
            }
        }
    }
}
