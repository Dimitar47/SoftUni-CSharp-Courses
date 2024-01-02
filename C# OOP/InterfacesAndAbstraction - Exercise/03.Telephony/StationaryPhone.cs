using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Telephony
{
    public class StationaryPhone : ICallable
    {


        public void Call(string phoneNumber)
        {
            if (!IsValidNumber(phoneNumber))
            {
                throw new ArgumentException("Invalid number!");
            }
            Console.WriteLine($"Dialing... {phoneNumber}");

        }
        private bool IsValidNumber(string phoneNumber)
        {
            return phoneNumber.All(x => char.IsDigit(x));
        }
        
    }
}
