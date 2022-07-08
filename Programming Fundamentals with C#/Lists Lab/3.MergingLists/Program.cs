using System;
using System.Collections.Generic;
using System.Linq;

namespace _3.MergingLists
{
    class Program
    {
        static void Main(string[] args)
        {
            // 3 76 5 5 2 34 43 2 12 4 3 12 54 10 23
            List<int> list1 = Console.ReadLine().Split().Select(int.Parse).ToList();
            List<int> list2 = Console.ReadLine().Split().Select(int.Parse).ToList();
            List<int> finalList = new List<int>();
            int lengthFirst = list1.Count;
            int lengthSecond = list2.Count;
            int lengthFinal = list1.Count + list2.Count;
            
                for (int i = 0; i < lengthFinal; i++)
                {
                    if (i < lengthFirst)
                    {
                        finalList.Add(list1[i]);
                    }

                    if (i < lengthSecond)
                    {
                        finalList.Add(list2[i]);
                    }


                }
            
           
            foreach (var item in finalList)
            {
                Console.Write(item + " ");
            }
        }
    }
}
