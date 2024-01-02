namespace _02.EnterNumbers
{
    public class Program
    {
        static void Main()
        {
            List<int> numbersCollection = new List<int>();
            while (numbersCollection.Count < 10)
            {
                try
                {
                    if (!numbersCollection.Any())
                    {
                        numbersCollection.Add(ReadNumber(1, 100));
                    }
                    else
                    {
                        numbersCollection.Add(ReadNumber(numbersCollection.Max(), 100));
                    }
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (FormatException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            Console.WriteLine(string.Join(", ",numbersCollection));


        }
        static int ReadNumber(int start,int end)
        {
            string input = Console.ReadLine();
            int number;
            try
            {
                 number = int.Parse(input);
            }
            catch(FormatException)
            {
                throw new FormatException("Invalid Number!");
            }
            if(number<=start || number >= end)
            { throw new ArgumentException($"Your number is not in range {start} - {end}!"); }
            return number;
        }

    }
}