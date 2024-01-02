namespace GenericScale
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            EqualityScale<int> equalityScale = new EqualityScale<int>(2,2);
            Console.WriteLine(equalityScale.AreEqual());
        }
    }
}