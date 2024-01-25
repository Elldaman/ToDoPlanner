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
using System.Collections.ObjectModel;
using DataStore;

namespace ToDoPlanner
{
    /// <summary>
    /// Interaction logic for Dashboard.xaml
    /// </summary>
    public partial class Dashboard : Page
    {
        private Planner mPlannerPage;
        private Calendar mCalendarPage;
        private DataStore.DataStore mData;
        public Dashboard()
        {
            InitializeComponent();
            mData = new DataStore.DataStore();
            mPlannerPage = new Planner(this, mData);
            mCalendarPage = new Calendar(this);

            dailyList.ItemsSource = mData.mTaskList;
            pointsList.ItemsSource = mData.mTaskList;
        }
        
        private void ViewPlanner(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(mPlannerPage);
        }

        private void ViewCalendar(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(mCalendarPage);
        }
    }
}
