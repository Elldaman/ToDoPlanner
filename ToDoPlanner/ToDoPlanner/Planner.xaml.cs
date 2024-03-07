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
using ToDoPlanner;
using MyTask;

namespace ToDoPlanner
{
    /// <summary>
    /// Interaction logic for Planner.xaml
    /// </summary>
    public partial class Planner : Page
    {
        private Dashboard mPrevPage;
        private ToDoPlanner.DataStore mData;
        public Planner(Dashboard prevPage, ToDoPlanner.DataStore data)
        {
            InitializeComponent();
            mPrevPage = prevPage;
            mData = data;
            plannerList.ItemsSource = mData.TaskList;
        }

        private void ViewDashboard(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(mPrevPage);
        }

        private void OpenAddTaskWindow(object sender, RoutedEventArgs e)
        {
            AddTask addTaskWindow = new AddTask(mData);
            addTaskWindow.Show();
        }

        private void DeleteTask(object sender, RoutedEventArgs e)
        {
            TaskManager.DeleteTask((MyTask.MyTask)plannerList.SelectedItem, mData);
        }

        private void EditTask(object sender, RoutedEventArgs e)
        {
            EditTask editTaskWindow = new EditTask(mData, (MyTask.MyTask)plannerList.SelectedItem);
            editTaskWindow.Show();
        }
    }
}
