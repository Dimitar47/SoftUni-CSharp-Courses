using System;
using System.Linq;



namespace Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            int fieldSize = int.Parse(Console.ReadLine());
            int[] field = new int[fieldSize];
            int[] indexesWeHaveLadyBugs = Console.ReadLine().Split().Select(int.Parse).ToArray();

            for (int i = 0; i < indexesWeHaveLadyBugs.Length; i++)
            {
                if (indexesWeHaveLadyBugs[i] >= 0 && indexesWeHaveLadyBugs[i] <= fieldSize - 1)
                {
                    int currentIndex = indexesWeHaveLadyBugs[i];
                    field[currentIndex] = 1;
                }
            }

            string command = "";
            while ((command = Console.ReadLine()) != "end")
            {
                string[] elements = command.Split();
                int ladyBugIndex = int.Parse(elements[0]);
                string direction = elements[1];
                int flyLength = int.Parse(elements[2]);

                if (ladyBugIndex >= 0 && ladyBugIndex <= fieldSize - 1 && field[ladyBugIndex] == 1)
                {
                    field[ladyBugIndex] = 0;

                    if (direction == "right")
                    {
                        int landIndex = ladyBugIndex + flyLength;
                        if (landIndex > fieldSize - 1)
                        {
                            continue;
                        }
                        if (field[landIndex] == 1)
                        {
                            while (field[landIndex] == 1)
                            {
                                landIndex += flyLength;
                                if (landIndex > fieldSize - 1)
                                {
                                    break;
                                    
                                }
                            }
                        }

                        if (landIndex <= fieldSize - 1)
                        {
                            field[landIndex] = 1;
                        }
                    }
                    else if (direction == "left")
                    {
                        int landIndex = ladyBugIndex - flyLength;
                        if (landIndex < 0)
                        {
                            continue;
                        }
                        if (field[landIndex] == 1)
                        {
                            while (field[landIndex] == 1)
                            {
                                landIndex -= flyLength;
                                if (landIndex <0)
                                {
                                    break;

                                }
                            }
                        }

                        if (landIndex >=0)
                        {
                            field[landIndex] = 1;
                        }
                    }
                }
            }

            Console.WriteLine(string.Join(" ",field));

        }
    }
}












