using System;
using System.Linq;

namespace _04.WordFilter
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] words = Console.ReadLine().Split();
            Console.WriteLine(string.Join(Environment.NewLine,words.Where(x=>x.Length%2==0).ToList()));
        }
    }
}
