namespace _01.SquareRoot
{
    public class Program
    {
        public static void Main(string[] args)
        {

            try
            {

                int n = int.Parse(Console.ReadLine());
                if (n < 0)
                {
                    throw new ArgumentException("Invalid number.");
                }
                Console.WriteLine(Math.Sqrt(n));

            }
            catch(ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.WriteLine("Goodbye.");
            }

            
        }
    }
}
