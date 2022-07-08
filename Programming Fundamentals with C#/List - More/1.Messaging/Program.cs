using System;
using System.Collections.Generic;
using System.Linq;

namespace _1.Messaging
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();
            string text = Console.ReadLine();
            
         
            for (int i = 0; i < numbers.Count; i++)
            {
              
                int index = 0;
                while (numbers[i] > 0)
                {
                    int lastDigit = numbers[i] % 10;
                    index += lastDigit;
                    numbers[i] = numbers[i] / 10;
                }
                // index in this case is the sum of the digits
                int countIndex = 0;
                for (int j = 0; j < index; j++)
                {
                    countIndex++;
                    if (countIndex == text.Length)
                    {
                        countIndex = 0;
                    }
                }
                char currentChar = text[countIndex];
                Console.Write(currentChar);
                string newMessage = text.Remove(countIndex, 1);
                text = newMessage;
                
            }
        }
    }
}
