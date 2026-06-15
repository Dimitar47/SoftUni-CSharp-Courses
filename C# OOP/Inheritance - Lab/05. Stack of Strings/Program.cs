namespace CustomStack
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            



        }
    }
    public class StackOfStrings : Stack<string>
    {
        public bool IsEmpty()
        {
            return this.Count == 0;

        }

        public void AddRange()
        {
            foreach(var el in this)
            {
                this.Push(el);
            }
        }


    }
}
