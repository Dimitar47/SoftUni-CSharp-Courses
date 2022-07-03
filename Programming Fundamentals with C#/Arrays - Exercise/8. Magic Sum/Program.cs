using System;
using System.Linq;
namespace _8._Magic_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int magicalSum = int.Parse(Console.ReadLine());
            //int[] isContained = new int[arr.Length];
            for (int i = 0; i < arr.Length; i++)
            {
              
                for (int j = i+1; j < arr.Length; j++)
                {
                    if(arr[i]+arr[j] == magicalSum)
                    {
                        Console.WriteLine(arr[i] + " " + arr[j]);
                        
                    }
                }

            }
        }
    }
}
