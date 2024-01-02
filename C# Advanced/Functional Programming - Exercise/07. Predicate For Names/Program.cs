using System;
using System.Linq;

namespace _07._Predicate_For_Names
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int length = int.Parse(Console.ReadLine());
            string[] names = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
            Func<string[],int ,Predicate<string>,string[]> func = FilterNames;
            Predicate<string> predicate = x => x.Length <= length;
            Console.WriteLine(string.Join(Environment.NewLine,func(names,length,predicate)));


            
        }
        static string[] FilterNames(string[] names, int length,Predicate<string> predicate)
        {
          
            return names.Where(x => predicate(x)).ToArray();
        }
    }
}
