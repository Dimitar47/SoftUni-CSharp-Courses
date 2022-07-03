using System;
using System.Linq;
namespace _6._Equal_Sums
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int leftSum = 0;
            int rightSum = 0;
            for (int i = 0; i < numbers.Length; i++)
            {
                 leftSum = 0;
                rightSum = 0;

                for (int j = 0; j <i; j++)
                {
                    leftSum += numbers[j];
                   
                }
                for (int k = numbers.Length-1; k >i; k--)
                {
                    rightSum += numbers[k];
                  
                }
                if(leftSum == rightSum)
                {
                    Console.WriteLine(i);
                    break;
                }
                
              

            }
            if (leftSum != rightSum)
            {
                Console.WriteLine("no");
            }
        }
    }
}
