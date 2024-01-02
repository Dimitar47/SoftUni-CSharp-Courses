namespace _03.Stack
{
    public class Program
    {
        static void Main(string[] args)
        {
            string command = "";
            CustomStack<int> customStack = new CustomStack<int>();

            while((command=Console.ReadLine())!="END")
            {
                string[] tokens = command.Split(new string[] { " ", "," }, StringSplitOptions.RemoveEmptyEntries);

                if (tokens[0] == "Push")
                {
                    int[] numbersToPush = tokens.Skip(1).Select(int.Parse).ToArray();
                    for (int i = 0; i < numbersToPush.Length; i++)
                    {
                        customStack.Push(numbersToPush[i]);
                    }
                }
                else
                {
                    try
                    {
                        customStack.Pop();
                    }
                    catch(InvalidOperationException e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }
                
            }
            Console.WriteLine(string.Join(Environment.NewLine,customStack));
            Console.WriteLine(string.Join(Environment.NewLine,customStack));
        }
    }
}