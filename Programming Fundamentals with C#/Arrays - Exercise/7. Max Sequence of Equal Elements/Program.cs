using System;
using System.Linq;
namespace _7._Max_Sequence_of_Equal_Elements
{
    class Program
    {
        static void Main(string[] args) 
        {
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int count = 1;
            int maxLength = 0;
            int index = -1;
            int maxCount = -1;
            for (int i = 0; i < numbers.Length-1; i++)
            {
            

                if(numbers[i] == numbers[i + 1]) 
                {
                   
                    count++;
                    index = i + 1;
                    if (maxLength < count)
                    {
                        maxLength = count;
                        maxCount = index;
                    }
                }
                else
                {
                    count = 1;

                }
                    
            }
            for (int i = maxCount; i >maxCount - maxLength; i--)
            {
                Console.Write(numbers[i] + " ");
            }
          
        }
    }
}
