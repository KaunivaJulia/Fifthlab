using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace yulia5
{
    public class Month
    {
        public int MonthId {  get; set; }
        public int Year { get; set; }
        public int MonthNumber { get; set; }

        public virtual ObservableCollection<Week> Weeks { get; set; } = new();
    }

    public class Week
    {
        public int WeekId { get; set; }
        public int WeekNumber { get; set; }

        public virtual ObservableCollection<Day> Days { get; set; } = new();

        public virtual Month? Month { get; set; }

    }
    public class Day
    {
        public int DayId {  get; set; }
        public int DayNumber { get; set; }

        public virtual Week? Week { get; set; }
    }
}
