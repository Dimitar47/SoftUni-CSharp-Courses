using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Count_Uppercase_Words
{
    internal class Program
    {

        static void Main(string[] args)

        {
            Func<string, bool> func = isFunc;
            List<string> words = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Where(isFunc).ToList();
            Console.WriteLine(string.Join(Environment.NewLine,words));
            bool isFunc(string str)
            {
                return char.IsUpper(str[0]);
            }
        }
    }
}
