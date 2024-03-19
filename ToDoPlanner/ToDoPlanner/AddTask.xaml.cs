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
using System.Windows.Shapes;
using ToDoPlanner;
using MyTask;
using System.Text.RegularExpressions;

namespace ToDoPlanner
{
    /// <summary>
    /// Interaction logic for AddTask.xaml
    /// </summary>
    public partial class AddTask : Window
    {
        private ToDoPlanner.DataStore mData;
        private string NameData
        {
            get { return nameField.Text; }
        }
        private int PointsData
        {
            get { return Int32.Parse(pointsField.Text); }
        }

        public AddTask(ToDoPlanner.DataStore data)
        {
            InitializeComponent();
            mData = data;
        }

        public void SendTaskInfo(object sender, RoutedEventArgs e)
        {
            DateOnly defaultDate = new DateOnly();
            if (InputsInvalid(nameField.Text, pointsField.Text, typeField.SelectedItem))
                return;
            string taskName = NameData;
            int taskPoints = PointsData;
            TaskType type;
            ComboBoxItem selectedType = (ComboBoxItem)typeField.SelectedItem;
            string typeString = (selectedType.Content).ToString();
            if (typeString == "Daily")
                type = TaskType.Daily;
            else
                type = TaskType.LongTerm;
            MyTask.TaskManager.TrackTask(taskName, taskPoints, type, false, defaultDate);
            this.Close();
        }

        public bool InputsInvalid(string taskName, string pointsString, object taskType)
        {
            if (taskName == "")
            {
                MessageBox.Show("Task name cannot be left blank", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return true;
            }

            if(pointsString == "" || Int32.Parse(pointsField.Text) == 0)
            {
                MessageBox.Show("Points cannot be left blank or equal to 0", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return true;
            }

            if(taskType == null)
            {
                MessageBox.Show("A task length must be selected", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
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
