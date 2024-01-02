using System;
using System.Collections.Generic;
using System.Linq;

namespace _08._List_Of_Predicates
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<int> listOfAllNumber = Enumerable.Range(1, n).ToList();
            List<int> divisibleList = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToList();
            Func<List<int>, List<int>, HashSet<int>> func = (listOfAllNumber, divisibleList) =>
            {
                HashSet<int> dividedList = new HashSet<int>();
                foreach(var num in listOfAllNumber)
                {
                    foreach(var second in divisibleList)
                    {
                        if(num%second == 0)
                        {
                            dividedList.Add(num);
                        }
                        else
                        {
                            dividedList.Remove(num);
                            break;
                        }
                    }
                }
                return dividedList;
            };
            Console.WriteLine(string.Join(" ",func(listOfAllNumber, divisibleList)));
        }
    }
}
