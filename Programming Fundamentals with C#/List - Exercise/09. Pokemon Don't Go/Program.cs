using System;
using System.Collections.Generic;
using System.Linq;

namespace _09._Pokemon_Don_t_Go
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();
            int sum = 0;
           

            while (numbers.Count > 0)
            {
                int index = int.Parse(Console.ReadLine());

                if (index == 0 && numbers.Count == 1)
                {
                    sum += numbers[0];
                    numbers.RemoveAt(0);
                    break;
                }
                if (index < 0)
                {
                    int firstNumber = numbers[0];
                    sum += firstNumber;
                    numbers.RemoveAt(0);


                    numbers.Insert(0, numbers[numbers.Count - 1]);
                    for (int i = 0; i < numbers.Count; i++)
                    {
                        if (numbers[i] <= firstNumber)
                        {
                            numbers[i] = numbers[i] + firstNumber;
                        }
                        else
                        {
                            numbers[i] -= firstNumber;
                        }
                    }

                }
                if (index >= numbers.Count)
                {
                    int removeLastNumber = numbers[numbers.Count - 1];
                    sum += removeLastNumber;
                    numbers.RemoveAt(numbers.Count - 1);
                    numbers.Add(numbers[0]);

                    for (int i = 0; i < numbers.Count; i++)
                    {

                        if (numbers[i] <= removeLastNumber)
                        {
                            numbers[i] = numbers[i] + removeLastNumber;
                        }
                        else
                        {
                            numbers[i] -= removeLastNumber;
                        }
                    }

                }

                if (index >= 0 && index < numbers.Count)
                {
                    int number = numbers[index];
                    sum += number;


                    for (int i = 0; i < numbers.Count; i++)
                    {
                        if (numbers[i] <= number)
                        {
                            numbers[i] = numbers[i] + number;
                        }
                        else
                        {
                            numbers[i] -= number;
                        }
                    }
                    numbers.RemoveAt(index);

                }

            }
            Console.WriteLine(sum);
        }
    }
}
