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
        private TaskType mListFocus;
   
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
            dailyList.ItemsSource = Data.DailyTaskList;
            longTermList.ItemsSource = Data.LongTermTaskList;
            mPlannerPage = new Planner(this, Data);
            mCalendarPage = new Calendar(this);
            mListFocus = TaskType.Daily;
            dailyList.AddHandler(MouseUpEvent, new RoutedEventHandler(DailyListClick));
            longTermList.AddHandler(MouseUpEvent, new RoutedEventHandler(LongTermListClick));
        }

        private void DailyListClick(object sender, RoutedEventArgs e) 
        {
            mListFocus = TaskType.Daily;
        }

        private void LongTermListClick(object sender, RoutedEventArgs e)
        {
            mListFocus = TaskType.LongTerm;
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
            MyTask.MyTask task;
            if (mListFocus == TaskType.Daily)
            {
                if (dailyList.SelectedItem == null)
                    return;
                task = (MyTask.MyTask)dailyList.SelectedItem;
            }
            else
            {
                if (longTermList.SelectedItem == null)
                    return;
                task = (MyTask.MyTask)longTermList.SelectedItem;
            }

            MyTask.TaskManager.CompleteTask(task, Data);
        }
    }
}
