namespace _03.Telephony
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] phones = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            SmartPhone smartphone = new SmartPhone();
            StationaryPhone stationaryPhone = new StationaryPhone();

            foreach (string phone in phones)
            {
                if (!phone.All(char.IsDigit))
                {
                    Console.WriteLine("Invalid number!");
                    continue;
                }

                if (phone.Length == 10)
                {
                    smartphone.Call(phone);
                }
                else if (phone.Length == 7)
                {
                    stationaryPhone.Call(phone);
                }
            }


            string[] websites = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            foreach (string website in websites)
            {
                if (website.Any(char.IsDigit))
                {
                    Console.WriteLine("Invalid URL!");
                    continue;
                }

                smartphone.Browse(website);
            }
        }
    }
}
