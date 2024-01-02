namespace _01.SquareRoot
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            try
            {
            int number = int.Parse(Console.ReadLine());
            int squared = SquareRoot.Square(number);
            Console.WriteLine(squared);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.WriteLine("Goodbye.");
            }
        }
    }
    public class SquareRoot
    {
        public static int Square(int x)
        {
            if (x < 0)
            {
                throw new ArgumentException("Invalid number.");
            }
            return (int)Math.Sqrt(x);
        }
    }
}