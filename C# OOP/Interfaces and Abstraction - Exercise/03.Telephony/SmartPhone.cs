namespace _03.Telephony
{
    public class SmartPhone : ICallable, IBrowsable
    {

        

        public void Call(string number)
        {
            Console.WriteLine($"Calling... {number}");
        }
        public void Browse(string site)
        {
            Console.WriteLine($"Browsing: {site}!");
        }
    }
}
