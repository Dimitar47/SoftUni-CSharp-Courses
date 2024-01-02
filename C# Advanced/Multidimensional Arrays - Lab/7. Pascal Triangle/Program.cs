namespace _7._Pascal_Triangle
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            if (n == 1)
            {
                Console.WriteLine(1);
                return;
            }
            long[][] jaggedArray = new long[n][];
            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < 1; col++)
                {
                    jaggedArray[row] = new long[row+1];
                    
                }
            }
            for (long row = 0; row < n; row++)
            {
                for (long col = 0; col < jaggedArray[row].Length; col++)
                {
                    if (row == 0)
                    {
                        jaggedArray[row][col] = 1;
                        break;
                    }
                    if(row == 1)
                    {
                        jaggedArray[row][col] = 1;
                        
                    }
                    if (row > 1)
                    {
                        if (row-1>=1 && col-1>=0 && col - 1 < jaggedArray[row - 1].Length && col < jaggedArray[row-1].Length)
                        {
                            jaggedArray[row][col] = jaggedArray[row - 1][col - 1] + jaggedArray[row - 1][col];
                        }
                        else
                        {
                            jaggedArray[row][col] = 1;
                        }
                    }
                }
            }
            for (long row = 0; row < jaggedArray.Length; row++)
            {
                for (long col = 0; col < jaggedArray[row].Length; col++)
                {
                    Console.Write($"{jaggedArray[row][col]} ");
                }
                Console.WriteLine();
            }
        }
    }
}