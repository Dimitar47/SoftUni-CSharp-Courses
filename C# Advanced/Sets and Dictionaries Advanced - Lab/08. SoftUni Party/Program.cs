using System;
using System.Collections.Generic;

namespace _08._SoftUni_Party
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string command = "";
            HashSet<string> vip = new HashSet<string>();
            HashSet<string> regular = new HashSet<string>();
           
            while ((command = Console.ReadLine()) != "PARTY")
            { 
                if (Char.IsDigit(command[0]))
                {
                    vip.Add(command);
                }
                else
                {
                    regular.Add(command);
                }

            }
            while((command = Console.ReadLine()) != "END")
            {
                if (vip.Contains(command))
                {
                    vip.Remove(command);
                }
                if(regular.Contains(command))
                {
                    regular.Remove(command);
                }
            }
            int notComing = regular.Count + vip.Count;
            Console.WriteLine(notComing);
            if (vip.Count > 0)
            {
                foreach (var vi in vip)
                {

                    Console.WriteLine(vi);
                } 
            }
            if (regular.Count > 0)
            {
                foreach (var reg in regular)
                {
                    Console.WriteLine(reg);
                }
            }

        }
    }
}
