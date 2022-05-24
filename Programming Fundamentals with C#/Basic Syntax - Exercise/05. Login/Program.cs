using System;

namespace _05._Login
{
    class Program
    {
        static void Main(string[] args)
        {
            string username = Console.ReadLine();
           
            string reversed = string.Empty;
            string sum = "";
            for (int i = username.Length-1; i >= 0; i--)
            {
                reversed = username[i].ToString();
                sum += reversed;
            }
           
            string trying;
            int counter = 0;
            while ((trying = Console.ReadLine()) != sum)
            {
                counter++;
                if (counter == 4)
                {
                    Console.WriteLine($"User {username} blocked!");
                    return;
                }
                
                Console.WriteLine("Incorrect password. Try again.");
                

            }
            if (trying == sum)
            {
                Console.WriteLine($"User {username} logged in.");
               
            }

        }
    }
}
