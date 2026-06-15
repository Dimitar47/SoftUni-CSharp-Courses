using System;
using System.Collections.Generic;
using System.Text;

namespace ChristmasPastryShop.Models
{
    public class Stolen : Delicacy
    {
        private const double stolenPrice = 3.50;
        public Stolen(string name) : base(name, stolenPrice)
        {
        }
    }
}
