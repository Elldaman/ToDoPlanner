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
using DataStore;

namespace ToDoPlanner
{
    /// <summary>
    /// Interaction logic for Planner.xaml
    /// </summary>
    public partial class Planner : Page
    {
        private Dashboard mPrevPage;
        private DataStore.DataStore mData;
        public Planner(Dashboard prevPage, DataStore.DataStore data)
        {
            InitializeComponent();
            mPrevPage = prevPage;
            mData = data;
        }

        private void ViewDashboard(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(mPrevPage);
        }

        private void AddTask(object sender, RoutedEventArgs e)
        {
            string testName = "Hello World";
            int testPoints = 999;
            Task.Task testTask = new(testName, testPoints);
            mData.TrackTask(testTask);
        }
    }
}
