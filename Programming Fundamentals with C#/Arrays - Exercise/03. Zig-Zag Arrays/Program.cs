using System;
using System.Linq;
namespace _03._Zig_Zag_Arrays
{
    class Program
    {
        static void Main(string[] args)
        {
            bool shouldTakeSecond = false;
            int n = int.Parse(Console.ReadLine());
            int[] firstArray = new int[n];
            int[] secondArray = new int[n];
            for (int i = 0; i < n; i++)
            {
                int[] values = Console.ReadLine().Split().Select(int.Parse).ToArray();

                if (shouldTakeSecond)
                {
                    secondArray[i] = values[1];
                    firstArray[i] = values[0];
                }
                else
                {
                    secondArray[i] = values[0];
                    firstArray[i] = values[1];
                }

                shouldTakeSecond = !shouldTakeSecond;
            }
            Console.WriteLine(string.Join(" ", secondArray));
            Console.WriteLine(string.Join(" ", firstArray));
           
        }
         

        }
    }

