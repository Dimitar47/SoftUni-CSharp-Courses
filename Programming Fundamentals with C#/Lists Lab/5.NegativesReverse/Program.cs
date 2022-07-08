using System;
using System.Collections.Generic;

using System.Linq;

namespace _5.NegativesReverse
{
    class Program
    {
      
        static void Main(string[] args)
        {
            int totalTime = int.Parse(Console.ReadLine());
            if (totalTime < 60)
            {
                byte seconds = (byte)(totalTime % 60);
                Console.WriteLine($"0:00:00:{seconds:d02}");
            }
            else if (totalTime < 3600)
            {
                byte seconds = (byte)(totalTime % 60);
                byte minutes = (byte)(totalTime / 60 );

                Console.WriteLine($"0:00:{minutes:d02}:{seconds:d02}");
            }
            else if (totalTime < 86400)
            {
                byte seconds = (byte)(totalTime % 60);
                byte minutes = (byte)(totalTime / 60 );
                byte hours = (byte)(totalTime / 3600);
               
                Console.WriteLine($"0:{hours:d02}:{minutes:d02}:{seconds:d02}");
            }
            else
            {
                byte seconds = (byte)(totalTime % 60);
                byte minutes = (byte)(totalTime / 60 );
                byte hours = (byte)(totalTime / 3600 );
                long days = totalTime / 86400;
                if (hours > 23)
                {
                    hours = 0;
                    days++;
                }
                Console.WriteLine($"{days:d01}:{hours:d02}:{minutes:d02}:{seconds:d02}");
            }
            //List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();
            //numbers.RemoveAll(x => x < 0);
            //numbers.Reverse();
            //if (numbers.Count == 0)
            //{
            //    Console.WriteLine("empty");
            //    return;
            //}
            //Console.Write(string.Join(" ",numbers));
        }
    }
}
