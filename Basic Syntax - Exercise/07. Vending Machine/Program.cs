using System;

namespace _07._Vending_Machine
{
    class Program
    {
        static void Main(string[] args)
        {
            string command = string.Empty;
            double sumCoins = 0;
            double coins = 0;
            while((command = Console.ReadLine())!= "Start")
            {
               
                 coins = double.Parse(command);
                if (coins == 0.1 || coins == 0.2 || coins == 0.5 || coins == 1 || coins == 2)
                {
                    sumCoins += coins;
                }
                else
                {
                    Console.WriteLine($"Cannot accept {coins}");
                }

               
                
            }
            while((command = Console.ReadLine()) != "End")
            {
                string bought = command;
                if(bought == "Nuts")
                {
                    coins = 2.0;
                }
                else if(bought == "Water")
                {
                    coins = 0.7;
                }
                else if (bought == "Crisps")
                {
                    coins = 1.5;
                }
                else if (bought == "Soda")
                {
                    coins = 0.8;
                }
                else if (bought == "Coke")
                {
                    coins = 1.0;
                }
                else
                {
                    Console.WriteLine("Invalid product");
                    continue;
                }
                if (sumCoins >= coins)
                {
                    sumCoins -= coins;
                    Console.WriteLine($"Purchased {bought.ToLower()}");
                }
                else
                {
                    Console.WriteLine("Sorry, not enough money");
                }
               
            }
            Console.WriteLine($"Change: {sumCoins:F2}");
        }
    }
}
