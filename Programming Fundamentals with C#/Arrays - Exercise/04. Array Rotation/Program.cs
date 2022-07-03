using System;
using System.Linq;
namespace _04._Array_Rotation
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine().Split().Select(int.Parse).ToArray();
            
            int numberOfRot = int.Parse(Console.ReadLine());            // number of rotations to rotate the array
            for (int i = 0; i < numberOfRot; i++)                       // Rotate the given array by n times toward left 
            {
                int temp = arr[0];     //2                                 // Stores the first element of the array  

                for (int j = 0; j < arr.Length-1; j++)
                {
                    arr[j] = arr[j + 1];                                // Shift element of array by one
                }
                arr[arr.Length - 1] = temp;                             // First element of array will be added to the end 
            }
            Console.WriteLine(string.Join(" ",arr));
        }
    }
}
