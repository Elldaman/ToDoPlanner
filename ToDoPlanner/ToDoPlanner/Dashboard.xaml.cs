using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using ToDoPlanner;
using System.Windows.Input;
using System.Diagnostics;
using System.Windows.Data;
using System.Globalization;
using System.Windows.Media;
using System;
using System.Threading.Tasks;
using MyTask;

namespace ToDoPlanner
{
    public class CompletedToColourConverter : IValueConverter
    {
        public object Convert(object isCompleted, Type targetType, object parameter, CultureInfo culture)
        {
            return (bool)isCompleted ? new SolidColorBrush(Colors.SpringGreen) : new SolidColorBrush(Colors.White);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new InvalidOperationException("This is a one-way conversion.");
        }
    }

    public partial class Dashboard : Page
    {
        private Planner mPlannerPage;
        private Calendar mCalendarPage;
   
        private DataStore _Data;

        public DataStore Data
        {
            get { return _Data; }
            set { _Data = value; }
        }

        public Dashboard()
        {
            InitializeComponent();
            Data = new DataStore();
            this.DataContext = Data;
            dailyList.ItemsSource = Data.TaskList;
            mPlannerPage = new Planner(this, Data);
            mCalendarPage = new Calendar(this);
        }
        
        private void ViewPlanner(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(mPlannerPage);
        }

        private void ViewCalendar(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(mCalendarPage);
        }

        private void CompleteTaskButtonClick(object sender, RoutedEventArgs e)
        {
            MyTask.MyTask task = (MyTask.MyTask)dailyList.SelectedItem;
            MyTask.TaskManager.CompleteTask(task, Data);
        }
    }
}
