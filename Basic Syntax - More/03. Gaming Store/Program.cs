using System;

namespace _03._Gaming_Store
{
    class Program
    {
        static void Main(string[] args)
        {
            double currentBalance = double.Parse(Console.ReadLine());
            double price = 0;
            double sum = 0;
            string command = "";
            while((command=Console.ReadLine())!= "Game Time")
            {
                string game = command;
                if (currentBalance <= 0)
                {
                    Console.WriteLine("Out of money!");
                    break;
                }
                if(command == "OutFall 4")
                {
                    price = 39.99;
                    if (currentBalance < price)
                    {
                        Console.WriteLine("Too Expensive");
                        continue;
                    }
                    else
                    {
                        Console.WriteLine($"Bought {command}");
                        currentBalance -= price;
                    }
                
                }
                else if (command == "CS: OG")
                {
                    price = 15.99;
                    if (currentBalance < price)
                    {
                        Console.WriteLine("Too Expensive");
                        continue;
                    }
                    else
                    {
                        Console.WriteLine($"Bought {command}");
                        currentBalance -= price;
                    }
                }
                else if (command == "Zplinter Zell")
                {
                    price = 19.99;
                    if (currentBalance < price)
                    {
                        Console.WriteLine("Too Expensive");
                        continue;
                    }
                    else
                    {
                        Console.WriteLine($"Bought {command}");
                        currentBalance -= price;
                    }
                }
                else if (command == "Honored 2")
                {
                    price = 59.99;
                    if (currentBalance < price)
                    {
                        Console.WriteLine("Too Expensive");
                        continue;
                    }
                    else
                    {
                        Console.WriteLine($"Bought {command}");
                        currentBalance -= price;
                    }
                }
                else if (command == "RoverWatch")
                {
                    price = 29.99;
                    if (currentBalance < price)
                    {
                        Console.WriteLine("Too Expensive");
                        continue;
                    }
                    else
                    {
                        Console.WriteLine($"Bought {command}");
                        currentBalance -= price;
                    }
                }
                else if (command == "RoverWatch Origins Edition")
                {
                    price = 39.99;
                    if (currentBalance < price)
                    {
                        Console.WriteLine("Too Expensive");
                        continue;
                    }
                    else
                    {
                        Console.WriteLine($"Bought {command}");
                        currentBalance -= price;
                    }
                }
                else
                {
                    Console.WriteLine("Not Found");
                    continue;
                }
                sum += price;
            }
            if (currentBalance <= 0)
            {
                Console.WriteLine("Out of money!");
                return;
            }
            if (command=="Game Time")
            {
                Console.WriteLine($"Total spent: ${sum:F2}. Remaining: ${currentBalance:F2}");
            }
        }
    }
}
