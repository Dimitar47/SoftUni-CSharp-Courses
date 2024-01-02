namespace GenericBoxOfString
{
    internal class StartUp
    {
        static void Main(string[] args)
        {
            int numberOfBoxes = int.Parse(Console.ReadLine());
            for (int i = 0; i < numberOfBoxes; i++)
            {
                var input = int.Parse(Console.ReadLine());
                Box<int> box = new Box<int>(input);
                Console.WriteLine(box.ToString());
            }
        }
    }
}