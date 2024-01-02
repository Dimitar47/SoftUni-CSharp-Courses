using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.DateModifier
{
    public class DateModifier
    {
        public int CalculateDifference(string startDate,string endDate)
        {
            DateTime dateTime1 = DateTime.Parse(startDate);
            DateTime dateTime2 = DateTime.Parse(endDate);
            TimeSpan timeSpan = dateTime1 - dateTime2;

            return timeSpan.Days;
        }
    }
}
