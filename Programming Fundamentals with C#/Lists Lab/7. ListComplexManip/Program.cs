using System;
using System.Collections.Generic;
using System.Linq;

namespace _7._ListComplexManip
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();
            string command = "";
            int count = 0;
            while ((command = Console.ReadLine()) != "end")
            {
                string[] commandArray = command.Split();
                if (commandArray[0] == "Contains")
                {
                    string result = numbers.Contains(int.Parse(commandArray[1])) ? "Yes" : "No such number";
                    Console.WriteLine(result);
                }
                else if (commandArray[0] == "PrintEven")
                {
                    foreach (var t in numbers.Where(t => t % 2 == 0))
                    {
                        Console.Write(t + " ");
                    }

                    Console.WriteLine();
                }
                else if (commandArray[0] == "PrintOdd")
                {
                    foreach (var t in numbers.Where(t => t % 2 != 0))
                    {
                        Console.Write(t + " ");
                    }

                    Console.WriteLine();
                }
                else if (commandArray[0] == "GetSum")
                {
                    Console.WriteLine(numbers.Sum());
                }
                else if (commandArray[0] == "Filter")
                {
                    if (commandArray[1] == "<")
                    {
                        foreach (var t in numbers.Where(t=> t<int.Parse(commandArray[2])))
                        {
                            Console.Write(t + " ");
                        }

                        Console.WriteLine();
                    }
                    else if (commandArray[1] == ">")
                    {
                        foreach (var t in numbers.Where(t => t > int.Parse(commandArray[2])))
                        {
                            Console.Write(t + " ");
                        }

                        Console.WriteLine();
                    }
                    else if (commandArray[1] == ">=")
                    {
                        foreach (var t in numbers.Where(t => t >= int.Parse(commandArray[2])))
                        {
                            Console.Write(t + " ");
                        }

                        Console.WriteLine();
                    }
                    else if (commandArray[1] == "<=")
                    {
                        foreach (var t in numbers.Where(t => t <= int.Parse(commandArray[2])))
                        {
                            Console.Write(t + " ");
                        }

                        Console.WriteLine();
                    }
                }
                else if (commandArray[0] == "Add")
                {
                    count++;
                    numbers.Add(int.Parse(commandArray[1]));
                }
                else if (commandArray[0] == "Remove")
                {
                    count++;
                    numbers.Remove(int.Parse(commandArray[1]));
                }
                else if (commandArray[0] == "RemoveAt")
                {
                    count++;
                    numbers.RemoveAt(int.Parse(commandArray[1]));
                }
                else
                {
                    count++;
                    numbers.Insert(int.Parse(commandArray[2]), int.Parse(commandArray[1]));
                }
            }

            if (count != 0)
            {
                Console.WriteLine(string.Join(" ",numbers));
            }
        }
    }
}
