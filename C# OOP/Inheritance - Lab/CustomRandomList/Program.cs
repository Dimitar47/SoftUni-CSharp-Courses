using System;
using System.Collections.Generic;

namespace CustomRandomList
{
    class Program
    {
        static void Main(string[] args)
        {


            RandomList list = new RandomList() { "1", "2", "3", "4" };

            Console.WriteLine(list.RandomString());
            Console.WriteLine(list.Count);
            
        
        }
     
    }
}
