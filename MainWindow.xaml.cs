using System.Collections.ObjectModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using System.Numerics;

namespace yulia5
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly ApplicationContext _context = new ApplicationContext();

        public ObservableCollection<Month> MonthsObservable = new ObservableCollection<Month>();

        public MainWindow()
        {
            _context.Database.EnsureCreated();
            _context.Months.Load();
            InitializeComponent();
            //_context.Months.RemoveRange(_context.Months);
            //_context.Months.Add(m);
            //_context.SaveChanges();

            //// bind to the source
            MonthsObservable = _context.Months.Local.ToObservableCollection();
            mainTreeView.ItemsSource = MonthsObservable;
        }

        private void MenuAddMonth_Click(object sender, RoutedEventArgs e)
        {
            CreateMonthDialog dialog = new CreateMonthDialog();
            if (dialog.ShowDialog() ?? false)
            {
                _context.Months.Add(dialog.ResultMonth);
                _context.SaveChanges();
            }
        }

        private void MenuCalculateDiff_Click(object sender, RoutedEventArgs e)
        {
            Day day1 = mainTreeView.SelectedItems[0] as Day;
            Day day2 = mainTreeView.SelectedItems[1] as Day;
            int answer = CalendarCalculator.CalculateNumDays(day1, day2);
            string answerS = DeclensionGenerator.Generate(answer, "день", "дня", "дней");
            MessageBox.Show(this, $"Разница между двумя днями {answer} {answerS}", "Результат", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void MenuCheckLeap_Click(object sender, RoutedEventArgs e)
        {
            Month m = mainTreeView.SelectedItems[0] as Month;
            bool answer = CalendarCalculator.IsLeapYear(m.Year);
            string result = answer ? "является" : "не является";
            MessageBox.Show(this, $"{m.Year} {result} високосным годом", "Результат", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void mainTreeView_SelectionChanged(object sender, EventArgs e)
        {
            MenuCalculateDiff.IsEnabled = true;
            var selected = mainTreeView.SelectedItems;
            int numDays = 0;
            foreach (var obj in selected)
            {
                if (obj is Day)
                {
                    numDays++;
                }
                else
                {
                    MenuCalculateDiff.IsEnabled = false;
                }
            }
            if(numDays != 2)
            {
                MenuCalculateDiff.IsEnabled = false;
            }
            MenuCheckLeap.IsEnabled = selected.Count == 1 && selected[0] is Month;
        }
    }
}