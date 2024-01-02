
namespace GenericCountMethodString
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Box<double>> boxes = new List<Box<double>>();
            int numberOfEntries = int.Parse(Console.ReadLine());
            for (int i = 0; i < numberOfEntries; i++)
            {
                boxes.Add(new Box<double>(double.Parse(Console.ReadLine())));
            }
            double item = double.Parse(Console.ReadLine());
            Console.WriteLine(Box<double>.GetCountOfLargerElements(boxes, item));
        }
    }
}