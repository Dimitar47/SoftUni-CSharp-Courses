using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Telephony
{
    public class Smartphone : ICallable, IBrowsable
    {

        public void Call(string phoneNumber)
        {
            if (!IsValidNumber(phoneNumber))
            {
                throw new ArgumentException("Invalid number!");
            }
            Console.WriteLine($"Calling... {phoneNumber}");

        }

        private bool IsValidNumber(string phoneNumber)
        {
            return phoneNumber.All(x => char.IsDigit(x));
        }

        public void Browse(string url)
        {
            if (!IsValidUrl(url))
            {
                throw new ArgumentException("Invalid URL!");
            }
            Console.WriteLine($"Browsing: {url}!");

        }

        private bool IsValidUrl(string url)
        {
            return url.All(x => !char.IsDigit(x));
        }



    }
}
