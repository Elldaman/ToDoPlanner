using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using ToDoPlanner;

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
            _Data = new DataStore();
            mPlannerPage = new Planner(this, _Data);
            mCalendarPage = new Calendar(this);
            DataContext = Data;
        }
        
        private void ViewPlanner(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(mPlannerPage);
        }

        private void ViewCalendar(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(mCalendarPage);
        }

        private void DoubleClickTask(object sender, RoutedEventArgs e)
        {
            MyTask.MyTask task = (MyTask.MyTask)dailyList.SelectedItem;
            _Data.CompleteTask(task);
        }
    }
}
