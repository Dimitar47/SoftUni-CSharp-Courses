using System;
using System.Linq;

namespace _03._Treasure_Finder
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] key = Console.ReadLine().Split().Select(int.Parse).ToArray();
            string command = "";
          
            while((command = Console.ReadLine()) != "find")
            {
                string decrypted = "";
                for (int i = 0; i < command.Length; i++)
                {
                    for (int j = 0; j < key.Length; j++)
                    {
                        if (i < command.Length)
                        {
                            char currentChar = command[i];
                            currentChar -= (char)key[j];
                            decrypted += currentChar;
                            i++;
                        }
                        else
                        {
                            break;
                        }
                    }
                    i--;
                }
              
                int firstIndexOfAnd = decrypted.IndexOf("&");
                int lastIndexOfAnd = decrypted.LastIndexOf("&");
                string type = decrypted.Substring(firstIndexOfAnd + 1, lastIndexOfAnd - firstIndexOfAnd - 1);
                int indexOfLess = decrypted.IndexOf("<");
                int indexOfBig = decrypted.IndexOf(">");
                string coordinates = decrypted.Substring(indexOfLess + 1, indexOfBig - indexOfLess - 1);
                Console.WriteLine($"Found {type} at {coordinates}");
            }
        }
    }
}
