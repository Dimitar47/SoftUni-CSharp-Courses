using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingApp.Models
{
    public class Studio : Room
    {

        private const int studioBedCap = 4;
        public Studio() : base(studioBedCap)
        {
        }
    }
}
