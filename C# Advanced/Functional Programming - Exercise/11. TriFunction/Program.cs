using System;
using System.Collections.Generic;
using System.Linq;

namespace _11._TriFunction
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int threshold = int.Parse(Console.ReadLine());
            List<string> names = Console.ReadLine().Split().ToList();

            Func<string, int, bool> isValidName =
                (name, limit) => name.ToCharArray().Select(y => (int)y).Sum() >= limit;
            Func<List<string>, Func<string, int, bool>, string> findName =
                (names, isValidName) => names.Find(x => isValidName(x, threshold));

            string result = findName(names, isValidName);
            Console.WriteLine(result);
        }
    }
}
