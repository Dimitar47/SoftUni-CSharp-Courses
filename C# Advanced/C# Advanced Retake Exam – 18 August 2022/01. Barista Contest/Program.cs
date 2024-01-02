namespace _01._Barista_Contest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] quantitiesCoffee = Console.ReadLine().Split(", ",StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int[] quantitiesMilk = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            Queue<int> queueCoffee = new Queue<int>(quantitiesCoffee);
            Stack<int> stackMilk = new Stack<int>(quantitiesMilk);
            Dictionary<int, string> values = new()
            {
                {50,"Cortado" },
                {75,"Espresso" },
                {100,"Capuccino" },
                {150,"Americano" },
                {200,"Latte" }
            };
            Dictionary<string, int> drinks = new();
           
            while(queueCoffee.Count > 0 && stackMilk.Count > 0) 
            {
                int currentCoffee = queueCoffee.Dequeue();
                int currentMilk = stackMilk.Pop();
                int sum = currentCoffee + currentMilk;
                if (values.ContainsKey(sum))
                {
                    string currentDrink = values[sum];
                    if (!drinks.ContainsKey(currentDrink))
                    {
                        drinks.Add(currentDrink, 0);
                    }
                    drinks[currentDrink]++;
                }
                else
                {
                    currentMilk -= 5;
                    stackMilk.Push(currentMilk);
                }
            }

            if(queueCoffee.Count==0 && stackMilk.Count == 0)
            {
                Console.WriteLine($"Nina is going to win! She used all the coffee and milk!");
            }
            else
            {
                Console.WriteLine("Nina needs to exercise more! She didn't use all the coffee and milk!");
            }
            if (queueCoffee.Count == 0)
            {
                Console.WriteLine("Coffee left: none");
            }
            else
            {
                Console.WriteLine($"Coffee left: {string.Join(", ",queueCoffee)}");
            }
            if(stackMilk.Count == 0)
            {
                Console.WriteLine("Milk left: none");
            }
            else
            {
                Console.WriteLine($"Milk left: {string.Join(", ", stackMilk)}");
            }
            foreach(var drink in drinks.OrderBy(x=>x.Value).ThenByDescending(x=>x.Key))
            {
                Console.WriteLine($"{drink.Key}: {drink.Value}");
            }
        } 
    }
}