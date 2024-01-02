using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Meal_Plan
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> table = new Dictionary<string, int>() {
                { "salad", 350 },
                { "soup", 490},
                { "pasta", 680},
                { "steak", 790 }
        };

            Queue<string> queueMeals = new Queue<string>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries));
            Stack<int> stackDailyCalories = new Stack<int>
                (Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));

            int mealsCount = 0;
            int leftover = 0;
            bool next = true;
            while (queueMeals.Count > 0 && stackDailyCalories.Count > 0)
            {
                string meal = queueMeals.Peek();
                int currDailyCalorie = stackDailyCalories.Peek();
                int currMealCal = 0;

                if (next)
                {
                    currMealCal = table[meal];
                }
                else
                {
                    currMealCal = leftover;
                }


                if (currDailyCalorie > currMealCal)
                {
                    queueMeals.Dequeue();
                    stackDailyCalories.Pop();
                    currDailyCalorie -= currMealCal;
                    stackDailyCalories.Push(currDailyCalorie);
                    mealsCount++;
                    next = true;
                }
                else
                {
                    stackDailyCalories.Pop();
                    currMealCal -= currDailyCalorie;
                    leftover = currMealCal;
                    next = false;

                    if (stackDailyCalories.Count == 0)
                    {
                        queueMeals.Dequeue();
                        mealsCount++;
                    }

                }

            }

            if (queueMeals.Count <= 0)
            {
                Console.WriteLine($"John had {mealsCount} meals.");
                Console.WriteLine($"For the next few days, he can eat {string.Join(", ", stackDailyCalories)} calories.");
            }
            else if (stackDailyCalories.Count <= 0)
            {
                Console.WriteLine($"John ate enough, he had {mealsCount} meals.");
                Console.WriteLine($"Meals left: {string.Join(", ", queueMeals)}.");
            }


        }
    }
}
