using System;

using System.Linq;

namespace ladyBugs
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            int fieldSize = int.Parse(Console.ReadLine());
            int[] field = new int[fieldSize];
            int[] IndexesWeHaveLadybugs = Console.ReadLine().Split().Select(int.Parse).ToArray();

            for (int i = 0; i < IndexesWeHaveLadybugs.Length; i++)
            {
                if (IndexesWeHaveLadybugs[i] >= 0 && IndexesWeHaveLadybugs[i] <= fieldSize - 1) // cheker if indexes are in the field
                {
                    int currentField = IndexesWeHaveLadybugs[i];
                    field[currentField] = 1; // we  have ladybug on current index in the field
                }
            }

            string command = string.Empty;

            while ((command = Console.ReadLine()) != "end")
            {
                string[] commandArray = command.Split();
                int startIndex = int.Parse(commandArray[0]);
                string direction = commandArray[1];
                int flyLength = int.Parse(commandArray[2]);

                if (startIndex >= 0 && startIndex <= fieldSize - 1 && field[startIndex] == 1)
                {
                    field[startIndex] = 0; // we have fly and ladybug is in the air


                    if (direction == "right")
                    {
                        int landIndex = startIndex + flyLength;
                        if (landIndex >= fieldSize)
                        {
                            continue;
                        }

                        if (field[landIndex] == 1)  // we have another ladybug on this landIndex
                        {
                            while (field[landIndex] == 1) // we have to found landIndex without another ladybug
                            {
                                landIndex = landIndex + flyLength;
                                if (landIndex >= fieldSize) // we have landIndex out of range
                                {
                                    break;
                                }
                            }
                        }

                        if (landIndex < fieldSize)
                        {
                            field[landIndex] = 1; // ladybug is land on this index
                        }

                    }

                    else if (direction == "left")
                    {
                        int landIndex = startIndex - flyLength;

                        if (landIndex < 0)
                        {
                            continue;
                        }

                        if (field[landIndex] == 1)  // we have another ladybug on this landIndex
                        {
                            while (field[landIndex] == 1) // we have to found landIndex without another ladybug
                            {
                                landIndex = landIndex - flyLength;
                                if (landIndex < 0) // we have landIndex out of range
                                {
                                    break;
                                }
                            }
                        }

                        if (landIndex >= 0)
                        {
                            field[landIndex] = 1; // ladybug is land on this index
                        }
                    }
                }

                else
                {
                    continue;
                }

            }

            Console.WriteLine(string.Join(" ", field));
        }
    }
}
