using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using System.Windows.Shapes;
using ToDoPlanner;
using MyTask;
using System.Text.RegularExpressions;

namespace ToDoPlanner
{
    /// <summary>
    /// Interaction logic for EditItem.xaml
    /// </summary>
    public partial class EditTask : Window
    {
        private ToDoPlanner.DataStore mData;
        private MyTask.MyTask mSelectedTask;
        private string NameData
        {
            get { return nameField.Text; }
        }
        private int PointsData
        {
            get { return Int32.Parse(pointsField.Text); }
        }

        public EditTask(ToDoPlanner.DataStore data, MyTask.MyTask selectedTask)
        {
            InitializeComponent();
            mData = data;
            mSelectedTask = selectedTask;
            nameField.Text = mSelectedTask.TaskName;
            pointsField.Text = (mSelectedTask.Points).ToString();
        }

        public void EditTaskInfo(object sender, RoutedEventArgs e)
        {
            if (InputsInvalid(nameField.Text, pointsField.Text))
                return;
            string taskName = NameData;
            int taskPoints = PointsData;
            Debug.WriteLine("Calling data function");
            TaskManager.EditTask(taskName, taskPoints, mSelectedTask);
            this.Close();
        }

        public bool InputsInvalid(string taskName, string pointsString)
        {
            if (taskName == "")
            {
                MessageBox.Show("Task name cannot be left blank", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return true;
            }
            if (pointsString == "" || Int32.Parse(pointsField.Text) == 0)
            {
                MessageBox.Show("Points cannot be left blank or equal to 0", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return true;
            }
            return false;
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}
