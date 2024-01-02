namespace _01._FirstTask
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] tools = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();
            int[] substances = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();
            List<int> challenges = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToList();
            
            Queue<int> toolsQueue = new Queue<int>(tools);
            Stack<int> stackSubstance = new Stack<int>(substances);
            while(toolsQueue.Count>0 && stackSubstance.Count > 0)
            {
                int currentTool = toolsQueue.Dequeue();
                int currentSubstance = stackSubstance.Pop();
                int result = currentTool * currentSubstance;
                bool isEqual = false;
                for (int i = 0; i < challenges.Count; i++)
                {
                    if (result == challenges[i])
                    {
                        challenges.RemoveAt(i);
                        isEqual = true;
                        i--;
                      
                        break;
                    }
                }
                if(!isEqual)
                {
                  
                    currentTool++;
                    toolsQueue.Enqueue(currentTool);
                    currentSubstance--;
                    if (currentSubstance > 0)
                    {
                        stackSubstance.Push(currentSubstance);
                    }
                    
                }
            }

            if((stackSubstance.Count<=0 || toolsQueue.Count<=0)  && challenges.Count <= 0)
            {
                Console.WriteLine($"Harry found an ostracon, which is dated to the 6th century BCE.");
                
            }
            else if ((stackSubstance.Count <= 0 || toolsQueue.Count <= 0) && challenges.Count > 0)
            {
                Console.WriteLine($"Harry is lost in the temple. Oblivion awaits him.");
            }
            if (toolsQueue.Count > 0)
            {
                Console.WriteLine($"Tools: {string.Join(", ", toolsQueue)}");
            }
            if (stackSubstance.Count > 0)
            {
                Console.WriteLine($"Substances: {string.Join(", ", stackSubstance)}");
            }
            if (challenges.Count > 0)
            {
                Console.WriteLine($"Challenges: {string.Join(", ", challenges)}");
            }


        }
    }
}