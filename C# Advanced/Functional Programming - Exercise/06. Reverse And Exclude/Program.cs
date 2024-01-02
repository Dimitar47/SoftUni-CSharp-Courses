using System;
using System.Collections.Generic;
using System.Linq;

namespace _06._Reverse_And_Exclude
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> list = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
            int number = int.Parse(Console.ReadLine());
           
            Func<List<int>, List<int>> func = reverseList;
            List<int> reversedList = func(list);
            Predicate<int> predicate = x=>x%number!=0 ;
            Console.WriteLine(string.Join(" ",reversedList.Where(x=>predicate(x)).ToList()));

        }
       static List<int> reverseList(List<int> list)
        {
            List<int> result = new List<int>();
            for (int i = list.Count-1; i>=0; i--)
            {
                result.Add(list[i]);
                
            } 
            return result;
        }
    }
}
