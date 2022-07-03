using System;
using System.Linq;


namespace _4._Fold_and_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int middle = arr.Length / 2;

            int[] leftArr = new int[middle/2];
            
            int count = 0;
            for (int i = 0; i < leftArr.Length; i++)
            {
                count++;
                leftArr[i] = arr[i];
               
            }
            Array.Reverse(leftArr);
         
            int[] middleArr = new int[middle];
        

            int j = 0;
            for (int i = middle-count; i < middle+count; i++, j++)
            {

                middleArr[j] = arr[i];
              
            }

            
           
            int[] rightArr = new int[leftArr.Length];
            int k = 0;
            for (int i = middle + count; i <= arr.Length - 1; i++,k++)
            {
                rightArr[k] = arr[i];
                

            }
            Array.Reverse(rightArr);
    
            int[] totalSumLeft = new int[arr.Length / 2 /2];
           
            int breaker = 1;
            for (int i = 0; i < totalSumLeft .Length; i++, breaker++)
            {
                if (leftArr.Length<=middleArr.Length-breaker)
                {
                    totalSumLeft [i] = leftArr[i] + middleArr[i];
                }

                
            }

            breaker = 1;
            int[] totalSumRight = new int[totalSumLeft.Length];
            for (int i = 0; i < totalSumRight.Length; i++ ,breaker++)
            {
                if (rightArr.Length <= middleArr.Length - breaker)
                {
                    totalSumRight[i] = rightArr[i] + middleArr[i+count];
                }
            }
          
          
            Console.Write(string.Join(" ",totalSumLeft) + " " + string.Join(" ",totalSumRight));
         
        
        }
    }
}
