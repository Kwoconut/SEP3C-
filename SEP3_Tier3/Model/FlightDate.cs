using System;
using System.Collections.Generic;
using System.Text;

namespace SEP3_TIER3.Model
{
    public class FlightDate: Timer
    {
        public int Day { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }

        public FlightDate(int day, int month, int year, int hour, int minutes, int seconds) : base(seconds, minutes, hour)
        {
            Day = day;
            Month = month;
            Year = year;
        }

        public override string ToString()
        {
            return $"Day: {Day}\nMonth:{Month}\nYear:{Year}\n{base.ToString()}";
        }
    }
}
