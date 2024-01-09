using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace yulia5
{
    internal class CalendarCalculator
    {

        public static int CalculateNumDays(Day day1, Day day2)
        {
            DateTime datetime1 = new DateTime(day1.Week.Month.Year, day1.Week.Month.MonthNumber, day1.DayNumber);
            DateTime datetime2 = new DateTime(day2.Week.Month.Year, day2.Week.Month.MonthNumber, day2.DayNumber);
            return (datetime2 - datetime1).Days;
        }

        public static bool IsLeapYear(int year)
        {
            return DateTime.IsLeapYear(year);
        }
    }
}
