namespace _01._Climb_The_Peaks
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] foodPortions = Console.ReadLine().Split(", ",StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int[] stamina = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            Stack<int> stackFood = new Stack<int>(foodPortions);
            Queue<int> staminaQueue = new Queue<int>(stamina);
   
            Dictionary<int, string> peaks = new Dictionary<int, string>()
            { 
                {80,"Vihren"},
                {90,"Kutelo" },
                {100,"Banski Suhodol" },
                {60,"Polezhan" },
                {70,"Kamenitza" }
            

            };
            int index = 0;
            List<string> strings = new List<string>() ;
            List<int> ints = new List<int>() { 80, 90, 100, 60, 70 };
        
            while(stackFood.Count > 0 && staminaQueue.Count>0)
            {
                int currentFoodPortion = stackFood.Pop();
                int currentStamina = staminaQueue.Dequeue();
                int sum = currentFoodPortion + currentStamina;
                
                
                if (index <= 4)
                {
                    if (sum >= ints[index])
                    {
                        int currentNumber = ints[index];
                        strings.Add(peaks[currentNumber]);
                    }
                    
                    else
                    {
                        index--;
                     
                    }
                }
                index++;
                if (strings.Count == 5)
                {
                    break;
                }
                





            }

            if (strings.Count == 5)
            {
                Console.WriteLine("Alex did it! He climbed all top five Pirin peaks in one week -> @FIVEinAWEEK");
            }
            else
            {
                Console.WriteLine("Alex failed! He has to organize his journey better next time -> @PIRINWINS");
            }
            if (strings.Count > 0)
            {
                Console.WriteLine("Conquered peaks:");
                Console.WriteLine(string.Join(Environment.NewLine,strings));
            }
        }
    }
}