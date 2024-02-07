using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using ToDoPlanner;
using System.Windows.Input;
using System.Diagnostics;

namespace ToDoPlanner
{
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
            dailyList.ItemsSource = Data.mTaskList;
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
            Data.CompleteTask(task);
        }
    }
}
