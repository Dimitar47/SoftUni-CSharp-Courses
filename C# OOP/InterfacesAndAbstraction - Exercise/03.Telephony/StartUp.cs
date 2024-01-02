namespace _03.Telephony
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] phoneNumbers = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string[] websites = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            foreach(var  phone in phoneNumbers)
            {
                try
                {
                    if (phone.Length == 10)
                    {
                        Smartphone smartphone = new Smartphone();
                        smartphone.Call(phone);
                    }
                    else
                    {
                        StationaryPhone stationaryPhone = new StationaryPhone();
                        stationaryPhone.Call(phone);
                    }
                }
                catch(ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            foreach(var url in websites)
            {
                try
                {
                    Smartphone smartphone = new Smartphone();
                    smartphone.Browse(url);
                }
                catch(ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}