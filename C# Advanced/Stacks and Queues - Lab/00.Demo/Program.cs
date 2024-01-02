using System;
using System.Collections.Generic;
using System.Linq;

namespace _00.Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfCars = int.Parse(Console.ReadLine());
            Queue<string> queue = new Queue<string>();
            string carName = "";
            int passedCars = 0;
            int numberOfAllowedCars = numberOfCars;
            while ((carName = Console.ReadLine()) != "end")
            {
                if (carName != "green")
                {
                    queue.Enqueue(carName);
                    
                }
                else
                {
                    
                        
                            while (numberOfAllowedCars>0)
                            {
                                if (queue.Count > 0)
                                {
                                Console.WriteLine($"{queue.Dequeue()} passed!");
                                passedCars++;
                                
                                }
                                numberOfAllowedCars--;
                                
                            }
                    
                       
                       
                      
                    
                }
                numberOfAllowedCars = numberOfCars;
            }
            Console.WriteLine($"{passedCars} cars passed the crossroads.");

                //Stack<int> stack = new Stack<int>();

                //int count = stack.Count;
                //bool exists = stack.Contains(2);
                //int[] array = stack.ToArray();
                //stack.Clear();
                //stack.TrimExcess();
              
        }
    }
}
