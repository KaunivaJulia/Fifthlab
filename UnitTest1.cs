
using NUnit.Framework;

namespace TestProject2
{

    public class CalendarCalculatorTests
    {
        [Fact]
        public void CalculateNumDays_ReturnsCorrectNumberOfDays()
        {

            Day day1 = new Day(new Week(new Month(2022, 1), 1), 1);
            Day day2 = new Day(new Week(new Month(2022, 1), 1), 10);
            int numDays = CalendarCalculator.CalculateNumDays(day1, day2);

          
            Assert.Equal(9, numDays);
        }

        [Fact]
        public void IsLeapYear_ReturnsTrueForLeapYear()
        {
           
            int leapYear = 2020;
            bool result = CalendarCalculator.IsLeapYear(leapYear);

            Assert.True(result);
        }

        [Fact]
        public void IsLeapYear_ReturnsFalseForNonLeapYear()
        {
   
            int nonLeapYear = 2021;

            bool result = CalendarCalculator.IsLeapYear(nonLeapYear);

            Assert.False(result);
        }
    }
}
