namespace _03.Telephony
{
    public class StationaryPhone : ICallable
    {
        public void Call(string number)
        {

            Console.WriteLine($"Dialing... {number}");
        }
    }
}
