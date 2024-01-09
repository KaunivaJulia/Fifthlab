using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace yulia5
{
    /// <summary>
    /// Логика взаимодействия для CreateMonthDialog.xaml
    /// </summary>
    public partial class CreateMonthDialog : Window
    {

        private enum ValidationError
        {
            NOTANUMBER, NOTAYEAR, NOTAMONTH, YEAROUTOFRANGE
        }
        public CreateMonthDialog()
        {
            InitializeComponent();
        }

        private ValidationError? Validate()
        {
            if(!(int.TryParse(this.Year.Text, out var year) && int.TryParse(this.Month.Text, out var month))) {
                return ValidationError.NOTANUMBER;
            }
            if(year < 0)
            {
                return ValidationError.NOTAYEAR;
            }
            if (year < 1 || year > 9999)
            {
                return ValidationError.YEAROUTOFRANGE;
            }
            if (month < 1 || month > 12)
            {
                return ValidationError.NOTAMONTH;
            }
            return null;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ValidationError? error = Validate();
            if (error != null)
            {
                this.DialogResult = false;
                string errMessage;
                switch (error)
                {
                    case ValidationError.NOTANUMBER:
                        errMessage = "Введенные данные не являются числами";
                        break;
                    case ValidationError.NOTAYEAR:
                        errMessage = "Введенный год не является годом григорианского календаря";
                        break;
                    case ValidationError.YEAROUTOFRANGE:
                        errMessage = "Введенный год не может быть обработан.";
                        break;
                    case ValidationError.NOTAMONTH:
                        errMessage = "Введенный месяц не является месяцем григорианского календаря";
                        break;
                    default:
                        errMessage = "Неизвестная ошибка: " + error.ToString();
                        break;
                }
                MessageBox.Show(this, errMessage, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                this.DialogResult = true;
                this.Close();
            }
        }

        public Month ResultMonth
        {
            get
            {
                Month month = new Month() { Year = int.Parse(this.Year.Text), MonthNumber = int.Parse(this.Month.Text) };
                int days = DateTime.DaysInMonth(month.Year, month.MonthNumber);
                DateTime dt = new DateTime(month.Year, month.MonthNumber, 1);
                Week curWeek = new Week() { Month = month, WeekNumber = 1 };
                while (dt.Month == month.MonthNumber)
                {
                    curWeek.Days.Add(new Day() { Week = curWeek, DayNumber = dt.Day });
                    if(dt.DayOfWeek == DayOfWeek.Sunday)
                    {
                        month.Weeks.Add(curWeek);
                        curWeek = new Week() { Month = month, WeekNumber = curWeek.WeekNumber + 1 };
                    }
                    dt = dt.AddDays(1);
                }
                if (curWeek.Days.Count > 0)
                {
                    month.Weeks.Add(curWeek);
                }
                return month;
            }
        }
    }
}
