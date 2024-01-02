namespace _8._Bombs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int sizeOfSquareMatrix = int.Parse(Console.ReadLine());
            int[,] matrix = new int[sizeOfSquareMatrix,sizeOfSquareMatrix];
            for (int row = 0; row < matrix.GetLength(0) ; row++)
            {
                int[] innerMatrix = Console.ReadLine()
                      .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                      .Select(int.Parse)
                      .ToArray();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {

                    
                    matrix[row, col] = innerMatrix[col];
                }
            }
        }
    }
}