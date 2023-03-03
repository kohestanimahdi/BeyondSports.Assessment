using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeyondSports.Assessment.Domain.Common
{
    public static class DateTimeHelper
    {
        public static int GetYears(DateTime begin, DateTime to)
        {
            var zeroTime = new DateTime(1, 1, 1);


            TimeSpan span = to - begin;
            // Because we start at year 1 for the Gregorian
            // calendar, we must subtract a year here.
            return (zeroTime + span).Year - 1;
        }
    }
}
