using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Handball.Models
{
    public class ForwardWing : Player
    {
        private const double initialRating = 5.5;
        public ForwardWing(string name) : base(name, initialRating)
        {
        }
        public override void IncreaseRating()
        {
            Rating += 1.25;
        }
        public override void DecreaseRating()
        {
            Rating -= 0.75;

        }

    }
}
