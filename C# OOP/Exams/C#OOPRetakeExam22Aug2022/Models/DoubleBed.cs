using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingApp.Models
{
    public class DoubleBed : Room
    {
        private const int doubleBedCap = 2;
        public DoubleBed() : base(doubleBedCap)
        {
        }
    }
}
