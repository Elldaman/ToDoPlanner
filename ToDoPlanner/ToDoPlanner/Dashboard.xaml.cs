using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Task;

namespace ToDoPlanner
{
    /// <summary>
    /// Interaction logic for Dashboard.xaml
    /// </summary>
    public partial class Dashboard : Page
    {
        private Planner mPlannerPage;
        private Calendar mCalendarPage;
        private List<Task.Task> mTaskList;
        public Dashboard()
        {
            InitializeComponent();
            mPlannerPage = new Planner(this);
            mCalendarPage = new Calendar(this);
            mTaskList = new List<Task.Task>();
        }
        
        private void ViewPlanner(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(mPlannerPage);
        }

        private void ViewCalendar(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(mCalendarPage);
        }

        public void TrackTask(Task.Task task)
        {
            this.mTaskList.Add(task);
        }
    }
}
